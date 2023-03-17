using System.Net;
using C2SSprotoType;
using GameFramework;
using GameFramework.Event;
using GameFramework.Network;
using UnityEngine;

namespace MyGame
{
    public class NetComponent : AgentBaseComponent
    {
        public INetworkChannel channel;
        private int uiformid;
        
        public override void Init()
        {
            channel=GameEntry.Network.CreateNetworkChannel($"Login_{Agent.ID}", ServiceType.Tcp, new NetworkChannelHelperSimpleSproto());
        }
        public override void Start()
        {
            GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            Connect();
            //通过配置打开UI
            string st = GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.SignIn).Path;
            uiformid=GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(st), "Default",this);
        }
        public override void Update()
        {
            
        }

        public override void Destroy()
        {
            GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
        }

        #region 方法
        public void Register(string account, string psw)
        {
            channel.Send(SprotoPacketFactory.CreatRegister(account,psw));
        }

        public void SignIn(string account, string psw)
        {
            channel.Send(SprotoPacketFactory.CreatSignIn(account,psw));
        }
        
        public void SignOut()
        {
            
        }

        public void Skip()
        {
            channel.Close();
            SprotoPacket packet = ReferencePool.Acquire<S2CSprotoPacket>();
            packet.responseObj = new signin.response() { ok = true };
            
            GameEntry.Event.Fire(this,PacketHandlerEventArgs.Create(packet));
        }
        public void Ping()
        {
            channel.Send(SprotoPacketFactory.Ping());
        }
        public void Connect()
        {
            
            string ip= GameEntry.Config.GetString("Login.IP");
            int port=GameEntry.Config.GetInt("Login.Port");
            channel.Connect(IPAddress.Parse("192.168.31.33"),8888);
        }
        #endregion

        #region 事件
        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkConnectedEventArgs ne = (UnityGameFramework.Runtime.NetworkConnectedEventArgs)e;
            if (ne.NetworkChannel==this.channel)
            {
                Ping();
            }
        }
        #endregion
        
       
    }
}