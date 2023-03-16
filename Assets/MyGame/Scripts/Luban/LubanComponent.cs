using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GameFramework.Resource;
using SimpleJSON;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame
{


    [AddComponentMenu("Luban")]
    public class LubanComponent : GameFrameworkComponent
    {
        private cfg.Tables m_Tables;
        public cfg.Tables Tables => m_Tables;
        private Dictionary<string, string> m_DataTableJsons;
        private bool m_Ready;
        Action m_InitCallbcak;
        public bool Ready
        {
            get
            {
                if (m_Ready)
                {
                    return true;
                }
                foreach (var script in m_DataTableJsons)
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
        public void Init(Action callback)
        {
            if (callback!=null)
            {
                m_InitCallbcak = callback;
            }
            // Debug.Log(Time.time);
            m_DataTableJsons=new Dictionary<string, string>();
            PreloadDataTable();
           
        }

        void PreloadDataTable()
        {
            Regex m_Regex=new Regex(@"^Assets/MyGame/DataTable/Luban/\w*.json$");
            foreach (var path in GameEntry.Resource.GetAllAssetPaths())
            {
                if(m_Regex.IsMatch(path))
                {
                    // Debug.Log(path);
                    m_DataTableJsons.Add(path,null);
                    GameEntry.Resource.LoadAsset(path,new LoadAssetCallbacks(LoadJsonAssetSuccess));
                }
            }
            StartCoroutine(BuildInInit());
        }
        IEnumerator BuildInInit()
        {
            yield return new WaitUntil(()=>Ready);
            // Debug.Log(Time.time);

            m_Tables = new cfg.Tables(file =>
                JSON.Parse(m_DataTableJsons[$"Assets/MyGame/DataTable/Luban/{file}.json"])
                );
            m_DataTableJsons.Clear();
            // var itemInfo = m_Tables.TbItem.Get(10002);
            // Debug.Log(string.Format("id:{0} name:{1} desc:{2}", 
            //     itemInfo.Id, itemInfo.Name, itemInfo.Desc));
            // Debug.Log(Time.time);
            if (m_InitCallbcak!=null)
            {
                m_InitCallbcak();
                m_InitCallbcak = null;
            }
        }
        void LoadJsonAssetSuccess(string assetName, object asset, float duration, object userData)
        {
            TextAsset textAsset=asset as  TextAsset;
            // Debug.Log(textAsset.text);
            if (m_DataTableJsons.ContainsKey(assetName))
            {
                m_DataTableJsons[assetName] = textAsset.text;
            }
            else
            {
                Debug.Log($"m_luaScripts not contains {assetName}");
            }
            
        }
    }
}