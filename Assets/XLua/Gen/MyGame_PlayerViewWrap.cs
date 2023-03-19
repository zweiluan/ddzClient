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
    public class MyGamePlayerViewWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.PlayerView);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 9, 9);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSelectedCards", _m_SetSelectedCards);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelectedCards", _m_GetSelectedCards);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetScore", _m_SetScore);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTip", _m_SetTip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetName", _m_SetName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetStatus", _m_SetStatus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowCard", _m_ShowCard);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetHandleCard", _m_SetHandleCard);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "cardShow", _g_get_cardShow);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cardHandle", _g_get_cardHandle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cardNumber", _g_get_cardNumber);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playerName", _g_get_playerName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playerScore", _g_get_playerScore);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "playerStatus", _g_get_playerStatus);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tip", _g_get_tip);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "peasant", _g_get_peasant);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "landlord", _g_get_landlord);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "cardShow", _s_set_cardShow);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cardHandle", _s_set_cardHandle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cardNumber", _s_set_cardNumber);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playerName", _s_set_playerName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playerScore", _s_set_playerScore);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "playerStatus", _s_set_playerStatus);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tip", _s_set_tip);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "peasant", _s_set_peasant);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "landlord", _s_set_landlord);
            
			
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
					
					var gen_ret = new MyGame.PlayerView();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.PlayerView constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSelectedCards(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _st = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.SetSelectedCards( _st );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelectedCards(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetScore(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetScore( _i );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _st = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.SetTip( _st );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.SetName( _name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetStatus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _isPeasant = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.SetStatus( _isPeasant );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowCard(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _st = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.ShowCard( _st );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHandleCard(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _st = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.SetHandleCard( _st );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cardShow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cardShow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cardHandle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cardHandle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cardNumber(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cardNumber);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playerName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.playerName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playerScore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.playerScore);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_playerStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.playerStatus);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tip);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_peasant(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.peasant);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_landlord(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.landlord);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cardShow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cardShow = (MyGame.CardShow)translator.GetObject(L, 2, typeof(MyGame.CardShow));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cardHandle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cardHandle = (MyGame.CardShow)translator.GetObject(L, 2, typeof(MyGame.CardShow));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cardNumber(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cardNumber = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playerName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playerName = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playerScore(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playerScore = (UnityEngine.UI.Text)translator.GetObject(L, 2, typeof(UnityEngine.UI.Text));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_playerStatus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.playerStatus = (UnityEngine.UI.Image)translator.GetObject(L, 2, typeof(UnityEngine.UI.Image));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tip = (TMPro.TextMeshProUGUI)translator.GetObject(L, 2, typeof(TMPro.TextMeshProUGUI));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_peasant(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.peasant = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_landlord(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                MyGame.PlayerView gen_to_be_invoked = (MyGame.PlayerView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.landlord = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
