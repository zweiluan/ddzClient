using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using DG.Tweening;
using GameFramework.Resource;

#if UNITY_EDITOR
using UnityEditor;   
#endif
using UnityEngine;
using UnityGameFramework.Runtime;
using XLua;

namespace MyGame
{


    [AddComponentMenu("xLua")]
    public class XluaComponent : GameFrameworkComponent
    {
        // [ReadOnly]
        // [ShowInInspector]
        private Dictionary<string, byte[]> m_luaScripts;
        private Action m_LuaInitCallback;
        public bool Ready
        {
            get
            {
                if (m_Ready)
                {
                    return true;
                }
                foreach (var script in m_luaScripts)
                {
                    if (script.Value==null)
                    {
                        return false;
                    }
                }

                m_Ready = true;
                return true;
            }
        }

        private bool m_Ready;

        public LuaEnv LuaEnv
        {
            get
            {
                if (m_LuaEnv == null)
                {
                    m_LuaEnv=new LuaEnv();
                }

                return m_LuaEnv;
            }
        }

        private LuaEnv m_LuaEnv;

        /// <summary>
        /// xlua环境初始化
        /// </summary>
        public void Init(Action callback)
        {
            if (callback!=null)
            {
                m_LuaInitCallback = callback;
            }
            this.LuaEnv.AddLoader(CustomLoader);
            m_Ready = false;
            m_luaScripts=new Dictionary<string, byte[]>();
            PreLoadLua();
            
        }

        byte[] CustomLoader(ref string filename)
        {
            
            string filePath=  filename.Replace(".","/");
            return m_luaScripts[$"Assets/MyGame/LuaScripts/Lualibs/{filePath}.lua.txt"];
        }

        private void Update()
        {
            if (this.LuaEnv != null)
            {
                this.LuaEnv.Tick();
            }
        }

        private void OnDestroy()
        {
            this.LuaEnv.Dispose();
        }

        void PreLoadLua()
        {
            Regex m_Regex=new Regex(@"^Assets/MyGame/LuaScripts/Lualibs/\w*.lua.txt$");
                foreach (var path in GameEntry.Resource.GetAllAssetPaths())
                {
                    // Debug.Log(path);
                    // if (path.Contains(".lua.txt"))
                    if(m_Regex.IsMatch(path))
                    {
                        Debug.Log(path);
                        m_luaScripts.Add(path,null);
                        GameEntry.Resource.LoadAsset(path,new LoadAssetCallbacks(LoadLuaAssetSuccess));
                    }
                        
                }

                StartCoroutine(CheckPreloadFinish());
        }
        IEnumerator CheckPreloadFinish()
        {
            yield return new WaitUntil(()=>Ready);
            if(m_LuaInitCallback!=null)
            {
                m_LuaInitCallback();
                m_LuaInitCallback = null;
            }
        }
        void LoadLuaAssetSuccess(string assetName, object asset, float duration, object userData)
        {
            TextAsset textAsset=asset as  TextAsset;
            // Debug.Log(textAsset.text);
            if (m_luaScripts.ContainsKey(assetName))
            {
                m_luaScripts[assetName] = System.Text.Encoding.UTF8.GetBytes(textAsset.text);
            }
            else
            {
                Debug.Log($"m_luaScripts not contains {assetName}");
            }
            
        }
    }
}
