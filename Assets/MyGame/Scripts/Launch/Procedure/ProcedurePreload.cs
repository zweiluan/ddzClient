using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using MyGame.Launch;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = MyGame.Launch.GameEntry;

namespace MyGame.Launch
{
    public class ProcedurePreload : ProcedureBase
    {
        Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId,OnLoadConfigSuccess);
            Debug.Log("资源预加载");
            
            LoadConfig();
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId,OnLoadConfigSuccess);
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            foreach (var loadedFlag in m_LoadedFlag)
            {
                if (!loadedFlag.Value)
                {
                    Debug.Log(loadedFlag.Key+"未加载完成");
                    return;
                }
            }
            ChangeState<ProcedureLoadDLL>(procedureOwner);
        }

        void LoadConfig()
        {
            string configAssetName = AssetUtility.GetConfigPath("Default");
            m_LoadedFlag.Add(configAssetName,false);
            GameEntry.Config.ReadData(configAssetName,this);
        }
        private void OnLoadConfigSuccess(object sender, GameEventArgs e)
        {
            LoadConfigSuccessEventArgs ne = (LoadConfigSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            
            m_LoadedFlag[ne.ConfigAssetName] = true;
        }
    }
}