using System.Collections.Generic;
using System.Reflection;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using HybridCLR;
using MyGame.Launch;
using UnityEngine;

namespace MyGame.Launch
{
    public class ProcedureLoadDLL : ProcedureBase
    {
        public static readonly List<string> s_HotfixAssemblyName= new List<string>
        {
            "Assembly-CSharp",
        };
        public  static readonly List<string> s_AotDllList = new List<string>
        {
            "mscorlib",
            "System",
            "System.Core",
            // "3rd"
        };
        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
        
        
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Debug.Log("加载dll");
            LoadDllAndAOT();
            
        }
        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            foreach (var loadFlag in m_LoadedFlag)
            {
                if (loadFlag.Value!=true)
                {
                    Debug.Log(loadFlag.Key+"正在加载中");
                    return;
                }
            }
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
        #region LoadDLL
        void LoadDllAndAOT()
        {
            LoadMetadataForAOTAssemblies();
            LoadHotfixAssemblies();
            Debug.Log("加载成功");
        }
        void LoadMetadataForAOTAssemblies()
        {
            foreach (var aotDllName in s_AotDllList)
            {
                LoadAOT(aotDllName);
            }
        }

        void LoadHotfixAssemblies()
        {
            foreach (var assembly in s_HotfixAssemblyName)
            {
                LoadDLL(assembly);
            }
        }

        void LoadAOT(string dllName)
        {
            string fullName = AssetUtility.GetDllPath(dllName);
            m_LoadedFlag.Add(fullName,false);
            GameEntry.Resource.LoadAsset(fullName,
                new LoadAssetCallbacks(LoadAotDllAssetSuccess),this);
        }

        void LoadDLL(string dllName)
        {
            string fullName = AssetUtility.GetDllPath(dllName);
            m_LoadedFlag.Add(fullName,false);
            GameEntry.Resource.LoadAsset(fullName,
                new LoadAssetCallbacks(LoadDllAssetSuccess),this);
        }
        void LoadDllAssetSuccess(
            string assetName,
            object asset,
            float duration,
            object userData)
        {
            byte[] assetData = (asset as TextAsset).bytes;
            Assembly.Load(assetData);
            if (userData!=this){return;}
            if (m_LoadedFlag.ContainsKey(assetName))
            {
                m_LoadedFlag[assetName] = true;
            }

            Debug.Log($"dll:{assetName}");
        }
        void LoadAotDllAssetSuccess(
            string assetName,
            object asset,
            float duration,
            object userData)
        {
            HomologousImageMode mode = HomologousImageMode.SuperSet;
            byte[] dllBytes = (asset as TextAsset).bytes;
            LoadImageErrorCode err = RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, mode);
            if (userData!=this){return;}
                if (m_LoadedFlag.ContainsKey(assetName))
            {
                m_LoadedFlag[assetName] = true;
            }
            Debug.Log($"LoadMetadataForAOTAssembly:{assetName}. mode:{mode} ret:{err}");
           
        }
        #endregion
    }
}