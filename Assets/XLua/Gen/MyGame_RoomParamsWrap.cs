#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class MyGameRoomParamsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.RoomParams);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 5, 5);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Index1", _g_get_Index1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Index2", _g_get_Index2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Index3", _g_get_Index3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ExtraCard", _g_get_ExtraCard);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Index", _g_get_Index);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Index1", _s_set_Index1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Index2", _s_set_Index2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Index3", _s_set_Index3);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ExtraCard", _s_set_ExtraCard);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Index", _s_set_Index);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new MyGame.RoomParams();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.RoomParams constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Index1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Index2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Index3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtraCard(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ExtraCard);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Index(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Index);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Index1 = (MyGame.PlayerUIData)translator.GetObject(L, 2, typeof(MyGame.PlayerUIData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Index2 = (MyGame.PlayerUIData)translator.GetObject(L, 2, typeof(MyGame.PlayerUIData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Index3 = (MyGame.PlayerUIData)translator.GetObject(L, 2, typeof(MyGame.PlayerUIData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExtraCard(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ExtraCard = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Index(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.RoomParams gen_to_be_invoked = (MyGame.RoomParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Index = (MyGame.PlayerUIData[])translator.GetObject(L, 2, typeof(MyGame.PlayerUIData[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
