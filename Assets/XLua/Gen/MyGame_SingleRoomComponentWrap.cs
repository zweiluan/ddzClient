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
    public class MyGameSingleRoomComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.SingleRoomComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 8, 8);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelectedCards", _m_GetSelectedCards);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RefreshUI", _m_RefreshUI);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "JoinRoom", _m_JoinRoom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Ready", _m_Ready);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LeftRoom", _m_LeftRoom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GameReady", _m_GameReady);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Destroy", _m_Destroy);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "agents", _g_get_agents);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uiformid", _g_get_uiformid);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "commandUIID", _g_get_commandUIID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roomData", _g_get_roomData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RefreshUiAction", _g_get_RefreshUiAction);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SelectedCards", _g_get_SelectedCards);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GetSelectedCardsAction", _g_get_GetSelectedCardsAction);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SetSelectedCardsAction", _g_get_SetSelectedCardsAction);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "agents", _s_set_agents);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uiformid", _s_set_uiformid);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "commandUIID", _s_set_commandUIID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roomData", _s_set_roomData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RefreshUiAction", _s_set_RefreshUiAction);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SelectedCards", _s_set_SelectedCards);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "GetSelectedCardsAction", _s_set_GetSelectedCardsAction);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SetSelectedCardsAction", _s_set_SetSelectedCardsAction);
            
			
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
					
					var gen_ret = new MyGame.SingleRoomComponent();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.SingleRoomComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelectedCards(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetSelectedCards(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RefreshUI(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<MyGame.RoomParams>(L, 2)) 
                {
                    MyGame.RoomParams _data = (MyGame.RoomParams)translator.GetObject(L, 2, typeof(MyGame.RoomParams));
                    
                    gen_to_be_invoked.RefreshUI( _data );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.RefreshUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.SingleRoomComponent.RefreshUI!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_JoinRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.JoinRoom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ready(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _ready = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Ready( _ready );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LeftRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LeftRoom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GameReady(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.GameReady(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_agents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.agents);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uiformid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.uiformid);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_commandUIID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.commandUIID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roomData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roomData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RefreshUiAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RefreshUiAction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectedCards(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SelectedCards);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GetSelectedCardsAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.GetSelectedCardsAction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SetSelectedCardsAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SetSelectedCardsAction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_agents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.agents = (MyGame.BaseAgent[])translator.GetObject(L, 2, typeof(MyGame.BaseAgent[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uiformid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.uiformid = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_commandUIID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.commandUIID = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roomData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roomData = (MyGame.RoomParams)translator.GetObject(L, 2, typeof(MyGame.RoomParams));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RefreshUiAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RefreshUiAction = translator.GetDelegate<System.Action<MyGame.RoomParams>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectedCards(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SelectedCards = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GetSelectedCardsAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GetSelectedCardsAction = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SetSelectedCardsAction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.SingleRoomComponent gen_to_be_invoked = (MyGame.SingleRoomComponent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SetSelectedCardsAction = translator.GetDelegate<System.Action<string>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
