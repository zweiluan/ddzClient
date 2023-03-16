using System;
using DG.Tweening;
using UnityEngine;
using UnityGameFramework.Runtime;
using XLua;

namespace MyGame
{
    [System.Serializable]
    public class Injection
    {
        public string name;
        public GameObject value;
    }

    [LuaCallCSharp]
    public class LuaUIView : UIFormLogic
    {
        public TextAsset luaScript;
        public Injection[] injections;


        
        internal static LuaEnv luaEnv ; //all lua behaviour shared one luaenv only!
        private Action<object> luaInit;
        private Action<object> luaOpen;
        private Action<object> luaClose;
        private Action<float,float> luaUpdate;
        private LuaTable scriptEnv;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            luaEnv = null;
        }

        public void Awake()
        {
            Debug.Log("C# OnInit");
            if (luaEnv==null)
            {
                if (GameEntry.xLua==null)
                {
                    luaEnv=new LuaEnv();
                }
                else
                {
                    luaEnv = GameEntry.xLua.LuaEnv;
                }
            }
            scriptEnv = luaEnv.NewTable();
            // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
            LuaTable meta = luaEnv.NewTable();
            meta.Set("__index", luaEnv.Global);
            scriptEnv.SetMetaTable(meta);
            meta.Dispose();

            scriptEnv.Set("self", this);
            foreach (var injection in injections)
            {
                scriptEnv.Set(injection.name, injection.value);
            }

            luaEnv.DoString(luaScript.text, luaScript.name, scriptEnv);
            scriptEnv.Get("OnInit", out luaInit);
            scriptEnv.Get("OnClose", out luaClose);
            scriptEnv.Get("OnOpen", out luaOpen);
            scriptEnv.Get("OnUpdate", out luaUpdate);
        }

        protected override void OnInit(object userData)
        {
           
            luaInit?.Invoke(userData);
        }
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            Debug.Log("C# OnOpen");
            luaOpen?.Invoke(userData);
        }
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            luaUpdate?.Invoke(elapseSeconds,realElapseSeconds);
        }
        protected override void OnClose(bool isShutdown, object userData)
        {
            Debug.Log("C# OnClose");
            luaClose?.Invoke(userData);
            base.OnClose(isShutdown, userData);
        }
        protected override void OnRecycle()
        {
            Debug.Log("C# OnRecycle");
            base.OnRecycle();
        }

        private void OnDestroy()
        {
            luaInit = null;
            injections = null;
            luaClose = null;
            luaUpdate = null;
            luaOpen = null;
            scriptEnv.Dispose();
        }
    }
}