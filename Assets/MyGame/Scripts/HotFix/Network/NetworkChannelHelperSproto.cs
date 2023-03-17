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
    public class NetworkChannelHelperSproto : INetworkChannelHelper
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
             Type s2cpacketBaseType = typeof(S2CPacketBase);
             Type s2cpacketHandlerBaseType = typeof(PacketRequestHanderBase);
             Type c2spacketBaseType = typeof(C2SPacketBase);
             Type c2spacketHandlerBaseType = typeof(PacketResponseHandlerBase);
             Assembly assembly = Assembly.GetExecutingAssembly();
             Debug.Log(assembly.FullName);
             Type[] types = assembly.GetTypes();
             // Debug.Log(types.Length);
             foreach (var type in types)
             {
                 if ((!type.IsClass)|| type.IsAbstract)
                 {
                     continue;
                 }
             
                 // Debug.Log($"{type.FullName},{type.BaseType}");
                 if (type.BaseType==s2cpacketBaseType||type.BaseType==c2spacketBaseType)
                 {
                     PacketBase packetBase = Activator.CreateInstance(type) as PacketBase;
                     Type packetType = GetServerToClientPacketType(packetBase.Id);
                     if (packetType!=null)
                     {
                         Log.Warning("Already exist packet type '{0}', check '{1}' or '{2}'?.", packetBase.Id.ToString(), packetType.Name, packetBase.GetType().Name);
                         continue;
                     }
                     m_ServerToClientPacketTypes.Add(packetBase.Id, type);
                     // Debug.Log($"添加{packetBase.Id},{type.FullName}");
                 }
                 else if (type.BaseType==s2cpacketHandlerBaseType||type.BaseType==c2spacketHandlerBaseType)
                 {
                     IPacketHandler packetHandler = Activator.CreateInstance(type) as IPacketHandler;
                     m_NetworkChannel.RegisterHandler(packetHandler);
                     // Debug.Log($"注册{packetHandler.Id},{type.FullName}");
                 }
             }
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
            m_NetworkChannel.Send(PacketFactory.CreatPacket<PingPacket>());
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
            var packetBase = packet as C2SPacketBase;
            int tag = packetBase.Id - 10000;
            byte[] bytes;
            if (packetBase.NeedResponese)
            {
                session++;
                m_SissionTags.Add(session,tag);
               bytes = request.Invoke(packetBase.Id-10000,packetBase.requestObj,session);
            }
            else
            {
                bytes = request.Invoke(packetBase.Id-10000,packetBase.requestObj);
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
            // byte[] bytes=new byte[source.Length];
            // source.Read(bytes);
            // StringBuilder st=new StringBuilder();
            // foreach (var by in bytes)
            // {
            //     st.Append((int) by);
            // }
            // source.Position = 0L;
            // Debug.Log($"长度为{source.Length},数据为{st}");
            int length = source.ReadByte() * 256 + source.ReadByte();
            var packheader = ReferencePool.Acquire<PacketHeaderSproto>();
            packheader.length = length;
            return packheader;
        }

        public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
        {
            customErrorData = null;
            ReferencePool.Release(packetHeader as BasePacketHeader);
            byte[] bytes=new byte[source.Length];
            source.Read(bytes);
            // StringBuilder st=new StringBuilder();
            // foreach (var by in bytes)
            // {
            //     st.Append((int) by);
            // }
            //
            // Debug.Log($"长度为{source.Length},数据为{st}");
            var info= host.Dispatch(bytes);
            PacketBase packet = null;
            //来自服务器的请求，用服务器的协议解析
            if (info.type==SprotoRpc.RpcType.REQUEST)
            {
                // info = service.Dispatch(bytes);
                Type type = GetServerToClientPacketType(20000 + info.tag.Value);
                if (type==null)
                {
                    Debug.Log("未获得类型");
                }
                packet=ReferencePool.Acquire(type) as PacketBase;
                packet.requestObj = info.requestObj;
            }
            else
            {
                // Debug.Log("接受到返回包");
                Type type = GetServerToClientPacketType(10000 + m_SissionTags[info.session.Value]);
                m_SissionTags.Remove(info.session.Value);
                packet=ReferencePool.Acquire(type) as PacketBase;
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