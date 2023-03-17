using System.Collections.Generic;
using System.Net;
using C2SSprotoType;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Network;
using GameFramework.Procedure;
using MyGame.Scripts.UI.Utility;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class ProcedureSignIn : ProcedureBase
    {
        private bool signinOK;
        
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            signinOK = false;
            GameEntry.Event.Subscribe(PacketHandlerEventArgs.EventId,OnSignInSuccess);
            // connections=new Dictionary<string, bool>();
            // GameEntry.Event.Subscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            var player = new Player();
            procedureOwner.SetData<VarInt32>("PlayerId",player.ID);
            player.AddComponent("NetComponent");
            // GameEntry.UI.OpenDialogUI(new DialogParams()
            // {
            //     Msg = "你好呀"
            // });
        }
        
        
        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            
            // 停止所有声音
            GameEntry.Sound.StopAllLoadingSounds();
            GameEntry.Sound.StopAllLoadedSounds();

            // 隐藏所有实体
            GameEntry.Entity.HideAllLoadingEntities();
            GameEntry.Entity.HideAllLoadedEntities();
            //关闭所有的UI
            GameEntry.UI.CloseAllLoadingUIForms();
            GameEntry.UI.CloseAllLoadedUIForms();
            
            GameEntry.Event.Unsubscribe(PacketHandlerEventArgs.EventId,OnSignInSuccess);
            // GameEntry.Event.Unsubscribe(UnityGameFramework.Runtime.NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (signinOK)
            {
                ChangeState<ProcedureMenu>(procedureOwner);
            }
        }

        void TestNetwork(int n)
        {
            if (n<1)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                var channel=GameEntry.Network.CreateNetworkChannel($"main_{i}", ServiceType.Tcp, new NetworkChannelHelperSproto());
                channel.Connect(IPAddress.Parse("192.168.31.33"),8888);

            }
        }
        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            UnityGameFramework.Runtime.NetworkConnectedEventArgs ne = (UnityGameFramework.Runtime.NetworkConnectedEventArgs)e;

            {

                socketTest(ne.NetworkChannel);   
            }
        }

        private void OnSignInSuccess(object sender, GameEventArgs e)
        {
           
            // if (e is PacketHandlerEventArgs ne)
            // {
            var ne = e as PacketHandlerEventArgs;
            if (ne.responseObj is signin.response {ok:true})
            {
                signinOK = true;
            }
            //在过程中被回收了。
                // Debug.Log($"req0 {ne.requestObj!=null}");
                // Debug.Log($"resp0 {ne.responseObj!=null}");
                // var packet = ne.packet;
                // if (packet.responseObj!=null)
                // {
                //     Debug.Log($"OnSignInSuccess{packet.responseObj.GetType()}");
                // }
                
                // if (packet.responseObj is signin.response r)
                // {
                //     Debug.Log($"登录成功{r.ok}");
                //     // signinOK = true;
                // }
            // }
        }
        void socketTest(INetworkChannel channel)
        {
        }
    }
}