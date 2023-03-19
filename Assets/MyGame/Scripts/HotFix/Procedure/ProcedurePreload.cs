using System;
using System.Collections.Generic;
using System.IO;
using GameFramework.Event;
using GameFramework.FileSystem;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using Mono.CompilerServices.SymbolWriter;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public class ProcedurePreload : ProcedureBase
    {
        public Dictionary<string, bool> m_LoadedFlag;
        private bool m_LuaFinish;
        private bool m_LubanFinish;
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Subscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            m_LoadedFlag=new Dictionary<string, bool>();
            m_LuaFinish = false;
            m_LubanFinish = false;
            Log.Info("资源预加载");
            GameEntry.xLua.Init(LuaInitFinish);
            GameEntry.Luban.Init(LubanInitFinish);
            LoadConfig("DefaultConfig");
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Unsubscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_LuaFinish && m_LubanFinish )
            {
                foreach (var kv in m_LoadedFlag)
                {
                    if (kv.Value==false)
                    {
                       return; 
                    }
                }
                ChangeState<ProcedureSignIn>(procedureOwner);
                // Debug.Log($"0&&1={false&&true},1&&1={true&&true},1&&0={true&&false}");
            }
        }

        #region 函数
        
        void LoadConfig(string name)
        {
            String fullName = AssetUtility.GetConfigAssetPath(name);
            m_LoadedFlag.Add(fullName,false);
            GameEntry.Config.ReadData(fullName,this);
        }
        
        #endregion
        #region 回调
        private void OnLoadConfigSuccess(object sender, GameEventArgs e)
        {
            LoadConfigSuccessEventArgs ne = (LoadConfigSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            
            m_LoadedFlag[ne.ConfigAssetName] = true;
            Log.Info("Load config '{0}' OK.", ne.ConfigAssetName);
            // string[] DataTables=GameEntry.Config.GetString("DataTable").Split(",");
            // string[] DataTablesCSV=GameEntry.Config.GetString("DataTable.CSV").Split(",");
            // foreach (string dataTableName in DataTables)
            // {
            //     LoadDataTable(dataTableName);
            // }
            // foreach (string dataTableName in DataTablesCSV)
            // {
            //     LoadDataTableFormCSV(dataTableName);
            // }
            // PreLoadLuaAfterConfigLoad();
        }

        private void OnLoadConfigFailure(object sender, GameEventArgs e)
        {
            LoadConfigFailureEventArgs ne = (LoadConfigFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load config '{0}' from '{1}' with error message '{2}'.", ne.ConfigAssetName, ne.ConfigAssetName, ne.ErrorMessage);
        }
        
        void LubanInitFinish()
        {
            Log.Info("Luban初始化完毕");
            m_LubanFinish = true;
            
        }

        void LuaInitFinish()
        {
            Log.Info("lua初始化完毕");
            m_LuaFinish = true;
            
        }

        #endregion
        
    
    }
}