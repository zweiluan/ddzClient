
using System;
using GameFramework.Event;
using MyGame.Scripts.UI.Utility;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame
{
    /// <summary>
    /// 赋予玩家打牌的能力
    /// </summary>
    public class SingleRoomComponent : AgentBaseComponent
    {
        public BaseAgent[] agents; 
        public int uiformid=0;
        public int commandUIID;

        public RoomParams roomData;
        public Action<RoomParams> RefreshUiAction=(param)=>{
            Debug.Log("C#RefreshUI");
        };

        public string SelectedCards;

        public string GetSelectedCards()
        {
            GetSelectedCardsAction?.Invoke();
            if (string.IsNullOrEmpty(SelectedCards))
            {
                return "pass";
            }
            return SelectedCards;
        }

        public Action GetSelectedCardsAction;
        public Action<string> SetSelectedCardsAction;
        public void RefreshUI(RoomParams data=null)
        {
            if (data==null)
            {
                RefreshUiAction(roomData);
            }
            else
            {
                RefreshUiAction(data);
            }
            
        }
        public void JoinRoom()
        {
            
        }

        public void Ready(bool ready)
        {
            
        }

        public void LeftRoom()
        {
            
        }
        /// <summary>
        /// 游戏准备好后，添加单局游戏组件
        /// </summary>
        public void GameReady()
        {
            GameEntry.UI.CloseUIForm(commandUIID);
            //头家
            agents = new BaseAgent[3];
            this.Agent.AddComponent<SingleGameComponent>().Begin(this);
            
        }

        public override void Init()
        {
            
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);
            var uiForm = GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Room);
            roomData = new RoomParams();
            uiformid=GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path), uiForm.Group,this);
            uiForm=GameEntry.Luban.Tables.TbUIForm.Get((int)UIFormId.Command);
            commandUIID= GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(uiForm.Path), uiForm.Group,new CommandParams()
            {
                Mode = (int)CommandMode.single_begin,
                UserData = this,
                Action1 = (_)=>{GameReady();}
            });
            RefreshUI();

            // uiformid=GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAssetPath(st), "Default",this);
            //打开准备游戏的ui
        }

        public override void Update()
        {
            
        }

        public override void Destroy()
        {
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId,OnOpenUIFormSuccess);
            if (uiformid!=0)
            {
                if (GameEntry.UI.GetUIForm(uiformid).Logic.Visible)
                {
                    GameEntry.UI.CloseUIForm(uiformid);
                }
            }
            if (agents!=null)
            {
                agents[1].Destory();
                agents[2].Destory();
                agents = null;
            }
        }
        
        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            // if (uiformid==ne.Id)
            {
                RefreshUI(roomData);
            }
        }
    }
}