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
    public class MyGameAIComponentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MyGame.AIComponent);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReqMaster", _m_ReqMaster);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Begin", _m_Begin);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Play", _m_Play);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowCards", _m_ShowCards);
			
			
			
			
			
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
					
					var gen_ret = new MyGame.AIComponent();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.AIComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReqMaster(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.AIComponent gen_to_be_invoked = (MyGame.AIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<string> _callback = translator.GetDelegate<System.Action<string>>(L, 2);
                    
                    gen_to_be_invoked.ReqMaster( _callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Begin(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.AIComponent gen_to_be_invoked = (MyGame.AIComponent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<MyGame.Card[]>(L, 2)&& translator.Assignable<MyGame.SingleGameComponent>(L, 3)) 
                {
                    MyGame.Card[] _cards = (MyGame.Card[])translator.GetObject(L, 2, typeof(MyGame.Card[]));
                    MyGame.SingleGameComponent __game = (MyGame.SingleGameComponent)translator.GetObject(L, 3, typeof(MyGame.SingleGameComponent));
                    
                    gen_to_be_invoked.Begin( _cards, __game );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<MyGame.SingleGameComponent>(L, 2)&& translator.Assignable<MyGame.PlayerUIData>(L, 3)) 
                {
                    MyGame.SingleGameComponent __game = (MyGame.SingleGameComponent)translator.GetObject(L, 2, typeof(MyGame.SingleGameComponent));
                    MyGame.PlayerUIData _playerData = (MyGame.PlayerUIData)translator.GetObject(L, 3, typeof(MyGame.PlayerUIData));
                    
                    gen_to_be_invoked.Begin( __game, _playerData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MyGame.AIComponent.Begin!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Play(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.AIComponent gen_to_be_invoked = (MyGame.AIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<string> _callback = translator.GetDelegate<System.Action<string>>(L, 2);
                    
                    gen_to_be_invoked.Play( _callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowCards(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MyGame.AIComponent gen_to_be_invoked = (MyGame.AIComponent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ShowCards(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
