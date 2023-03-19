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
    public class MyGameddzAIWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.ddzAI);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 10, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Split", _m_Split_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetHuoJian", _m_GetHuoJian_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetZhaDan", _m_GetZhaDan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSanShun", _m_GetSanShun_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetShuangShun", _m_GetShuangShun_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDanShun", _m_GetDanShun_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetSan", _m_GetSan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Get2", _m_Get2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Get1", _m_Get1_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new MyGame.ddzAI();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.ddzAI constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Split_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 1, typeof(MyGame.Card[]));
                    
                        var gen_ret = MyGame.ddzAI.Split( _cards );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHuoJian_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetHuoJian( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetZhaDan_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetZhaDan( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSanShun_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetSanShun( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShuangShun_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetShuangShun( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDanShun_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetDanShun( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSan_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.GetSan( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Get2_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.Get2( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Get1_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<MyGame.CardGroup> _ls = (System.Collections.Generic.List<MyGame.CardGroup>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<MyGame.CardGroup>));
                    System.Collections.Generic.List<MyGame.Card> _cards = (System.Collections.Generic.List<MyGame.Card>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<MyGame.Card>));
                    
                    MyGame.ddzAI.Get1( _ls, _cards );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
