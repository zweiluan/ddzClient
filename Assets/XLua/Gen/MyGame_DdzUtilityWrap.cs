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
    public class MyGameDdzUtilityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.DdzUtility);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 17, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCardById", _m_GetCardById_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDisplaySt", _m_GetDisplaySt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSuit", _m_GetSuit_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDisplay", _m_GetDisplay_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLevel", _m_GetLevel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCardType", _m_GetCardType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreatCards", _m_CreatCards_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sort", _m_Sort_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsLegal", _m_IsLegal_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsDan", _m_IsDan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsDuizi", _m_IsDuizi_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsWangZha", _m_IsWangZha_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsZha", _m_IsZha_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsShunzi", _m_IsShunzi_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsLiandui", _m_IsLiandui_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsSanDaiYi", _m_IsSanDaiYi_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "AllCards", _g_get_AllCards);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "MyGame.DdzUtility does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCardById_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = MyGame.DdzUtility.GetCardById( _id );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDisplaySt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = MyGame.DdzUtility.GetDisplaySt( _id );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSuit_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = MyGame.DdzUtility.GetSuit( _id );
                        translator.PushMyGameSuitType(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDisplay_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = MyGame.DdzUtility.GetDisplay( _id );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLevel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = MyGame.DdzUtility.GetLevel( _id );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCardType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.GetCardType( _cards );
                        translator.PushMyGameCardType(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreatCards_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = MyGame.DdzUtility.CreatCards(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sort_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<MyGame.Card[]>(L, 1)) 
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                    MyGame.DdzUtility.Sort( ref _cards );
                    translator.Push(L, _cards);
                        
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<MyGame.Card[]>(L, 1)) 
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.Sort( _cards );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.DdzUtility.Sort!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLegal_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<MyGame.CardGroup>(L, 1)&& translator.Assignable<MyGame.CardGroup>(L, 2)) 
                {
                    MyGame.CardGroup _cards = (MyGame.CardGroup)translator.GetObject(L, 1, typeof(MyGame.CardGroup));
                    MyGame.CardGroup _bottomCards = (MyGame.CardGroup)translator.GetObject(L, 2, typeof(MyGame.CardGroup));
                    
                        var gen_ret = MyGame.DdzUtility.IsLegal( _cards, _bottomCards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<MyGame.CardGroup>(L, 1)&& translator.Assignable<MyGame.Card[]>(L, 2)) 
                {
                    MyGame.CardGroup _cards = (MyGame.CardGroup)translator.GetObject(L, 1, typeof(MyGame.CardGroup));
                    MyGame.Card[] _bottomCards = (MyGame.Card[])translator.GetObject(L, 2, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsLegal( _cards, _bottomCards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<MyGame.Card[]>(L, 1)&& translator.Assignable<MyGame.Card[]>(L, 2)) 
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    MyGame.Card[] _bottomCards = (MyGame.Card[])translator.GetObject(L, 2, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsLegal( _cards, _bottomCards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.DdzUtility.IsLegal!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDan_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsDan( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDuizi_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsDuizi( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsWangZha_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsWangZha( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsZha_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsZha( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsShunzi_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsShunzi( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsLiandui_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsLiandui( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSanDaiYi_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.DdzUtility.IsSanDaiYi( _cards );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllCards(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, MyGame.DdzUtility.AllCards);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
