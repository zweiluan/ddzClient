using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using C2SSprotoType;
using GameFramework;
using GameFramework.Event;
using GameFramework.Network;
using Sproto;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class NetworkChannelHelperSimpleSproto: INetworkChannelHelper
    {
        private readonly Dictionary<int,Type> m_ServerToClientPacketTypes = new Dictionary<int, Type>();
        private readonly MemoryStream m_CachedStream = new MemoryStream(1024 * 8);
        private INetworkChannel m_NetworkChannel = null;
        private static ProtocolFunctionDictionary m_C2SProtocol = C2SProtocol.Instance.Protocol;
        private static ProtocolFunctionDictionary m_S2CProtocol = S2CProtocol.Instance.Protocol;
        private Dictionary<long, int> m_SissionTags;
        SprotoRpc client;
        private SprotoRpc host;
        private SprotoRpc.RpcRequest request;
        SprotoRpc service;
        SprotoRpc.RpcRequest clientRequest ;
        private long session = -1;
        public int PacketHeaderLength
        {
            get
            {
                
                return 2 * sizeof(byte);
            }
        }
        public void Initialize(INetworkChannel networkChannel)
        {
            m_NetworkChannel = networkChannel;
            //todo 初始化解析器
             session = 0;
             m_SissionTags=new Dictionary<long, int>();
             client=new SprotoRpc();
             host= new SprotoRpc(S2CProtocol.Instance);
             service=new SprotoRpc(C2SProtocol.Instance);
             clientRequest = client.Attach(C2SProtocol.Instance);
             request = host.Attach(C2SProtocol.Instance);
             //todo 注册handler
             //一个转发事件的handler
             m_NetworkChannel.RegisterHandler(new S2CSprotoPacketHandler());
             m_NetworkChannel.RegisterHandler(new C2SSprotoPacketHandler());
            //todo 绑定事件
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
            // throw new System.NotImplementedException();
        }

        public void Shutdown()
        {
            //todo 注销事件
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkClosedEventArgs.EventId, OnNetworkClosed);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkErrorEventArgs.EventId, OnNetworkError);
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);

            m_NetworkChannel = null;
        }

        public void PrepareForConnecting()
        {
            m_NetworkChannel.Socket.ReceiveBufferSize = 1024 * 64;
            m_NetworkChannel.Socket.SendBufferSize = 1024 * 24;
        }

        public bool SendHeartBeat()
        {
            // throw new System.NotImplementedException();
            // m_NetworkChannel.Send(PacketFactory.CreatPacket<PingPacket>());
            return true;
        }
        /// <summary>
        /// 序列化消息包
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="destination"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Serialize<T>(T packet, Stream destination) where T : Packet
        {
            var packetBase = packet as SprotoPacket;
            byte[] bytes;
            
            // Debug.Log(packetBase.tag);
            if (m_C2SProtocol[packetBase.tag].Response.Value!=null)
            {
                session++;
                // m_SissionTags.Add(session,packetBase.tag);
               bytes = request.Invoke(packetBase.tag,packetBase.requestObj,session);
            }
            else
            {
                bytes = request.Invoke(packetBase.tag,packetBase.requestObj);
            }
            int length = bytes.Length;
            Byte[] lengthBytes=new byte[2];
            //大端保存长度
            //高字节保存低位，低字节保存高位
            lengthBytes[0] = (byte) (length >>8);
            lengthBytes[1] = (byte) length;
            destination.Write(lengthBytes);
            destination.Write(bytes);
            return true;
        }

        public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
        {
            customErrorData = null;
            int length = source.ReadByte() * 256 + source.ReadByte();
            var packHeader = ReferencePool.Acquire<PacketHeaderSproto>();
            packHeader.length = length;
            return packHeader;
        }

        public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
        {
            customErrorData = null;
            ReferencePool.Release(packetHeader as BasePacketHeader);
            byte[] bytes=new byte[source.Length];
            source.Read(bytes);
            var info= host.Dispatch(bytes);
            SprotoPacket packet = null;
            //来自服务器的请求，用服务器的协议解析
            //request  1、request， 2、sproto 3、 msg 4、response
            //response 1、response 2、session 3、msg
            if (info.type==SprotoRpc.RpcType.REQUEST)
            {
                packet=ReferencePool.Acquire<S2CSprotoPacket>();
                packet.tag = info.tag.Value;
                packet.requestObj = info.requestObj;
            }
            else
            {
                packet = ReferencePool.Acquire<C2SSprotoPacket>();
                packet.responseObj = info.responseObj;
            }
            return packet;
        }

        #region 函数
        
        Type GetServerToClientPacketType(int id)
        {
            Type type = null;
            m_ServerToClientPacketTypes.TryGetValue(id, out type);

            return type;

            
        }

        #endregion
        #region 事件
        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkConnectedEventArgs ne = (UnityGameFramework.Runtime.NetworkConnectedEventArgs)e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }
            
            Log.Info ("Network channel '{0}' connected, local address '{1}', remote address '{2}'.", 
                ne.NetworkChannel.Name, 
                ne.NetworkChannel.Socket.LocalEndPoint.ToString(), 
                ne.NetworkChannel.Socket.RemoteEndPoint.ToString());
        }

        private void OnNetworkClosed(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkClosedEventArgs ne = (UnityGameFramework.Runtime.NetworkClosedEventArgs)e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' closed.", ne.NetworkChannel.Name);
        }

        private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs ne = (UnityGameFramework.Runtime.NetworkMissHeartBeatEventArgs)e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' miss heart beat '{1}' times.", ne.NetworkChannel.Name, ne.MissCount.ToString());

            if (ne.MissCount < 2)
            {
                return;
            }

            ne.NetworkChannel.Close();
        }

        private void OnNetworkError(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkErrorEventArgs)e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' error, error code is '{1}', error message is '{2}'.", ne.NetworkChannel.Name, ne.ErrorCode.ToString(), ne.ErrorMessage);

            ne.NetworkChannel.Close();
        }

        private void OnNetworkCustomError(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkCustomErrorEventArgs ne = (UnityGameFramework.Runtime.NetworkCustomErrorEventArgs)e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }
        }
        

        #endregion
       
    }
}