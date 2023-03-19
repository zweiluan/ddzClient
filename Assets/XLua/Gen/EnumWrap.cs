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
    
    public class DGTweeningAutoPlayWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.AutoPlay), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.AutoPlay), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.AutoPlay), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", DG.Tweening.AutoPlay.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoPlaySequences", DG.Tweening.AutoPlay.AutoPlaySequences);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AutoPlayTweeners", DG.Tweening.AutoPlay.AutoPlayTweeners);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "All", DG.Tweening.AutoPlay.All);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.AutoPlay), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningAutoPlay(L, (DG.Tweening.AutoPlay)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushDGTweeningAutoPlay(L, DG.Tweening.AutoPlay.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoPlaySequences"))
                {
                    translator.PushDGTweeningAutoPlay(L, DG.Tweening.AutoPlay.AutoPlaySequences);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "AutoPlayTweeners"))
                {
                    translator.PushDGTweeningAutoPlay(L, DG.Tweening.AutoPlay.AutoPlayTweeners);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "All"))
                {
                    translator.PushDGTweeningAutoPlay(L, DG.Tweening.AutoPlay.All);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.AutoPlay!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.AutoPlay! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningAxisConstraintWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.AxisConstraint), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.AxisConstraint), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.AxisConstraint), L, null, 6, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", DG.Tweening.AxisConstraint.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "X", DG.Tweening.AxisConstraint.X);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Y", DG.Tweening.AxisConstraint.Y);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Z", DG.Tweening.AxisConstraint.Z);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "W", DG.Tweening.AxisConstraint.W);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.AxisConstraint), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningAxisConstraint(L, (DG.Tweening.AxisConstraint)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushDGTweeningAxisConstraint(L, DG.Tweening.AxisConstraint.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "X"))
                {
                    translator.PushDGTweeningAxisConstraint(L, DG.Tweening.AxisConstraint.X);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Y"))
                {
                    translator.PushDGTweeningAxisConstraint(L, DG.Tweening.AxisConstraint.Y);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Z"))
                {
                    translator.PushDGTweeningAxisConstraint(L, DG.Tweening.AxisConstraint.Z);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "W"))
                {
                    translator.PushDGTweeningAxisConstraint(L, DG.Tweening.AxisConstraint.W);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.AxisConstraint!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.AxisConstraint! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningEaseWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.Ease), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.Ease), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.Ease), L, null, 39, 0, 0);

            Utils.RegisterEnumType(L, typeof(DG.Tweening.Ease));

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.Ease), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningEase(L, (DG.Tweening.Ease)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

                try
				{
                    translator.TranslateToEnumToTop(L, typeof(DG.Tweening.Ease), 1);
				}
				catch (System.Exception e)
				{
					return LuaAPI.luaL_error(L, "cast to " + typeof(DG.Tweening.Ease) + " exception:" + e);
				}

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.Ease! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningLogBehaviourWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.LogBehaviour), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.LogBehaviour), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.LogBehaviour), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Default", DG.Tweening.LogBehaviour.Default);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Verbose", DG.Tweening.LogBehaviour.Verbose);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ErrorsOnly", DG.Tweening.LogBehaviour.ErrorsOnly);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.LogBehaviour), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningLogBehaviour(L, (DG.Tweening.LogBehaviour)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Default"))
                {
                    translator.PushDGTweeningLogBehaviour(L, DG.Tweening.LogBehaviour.Default);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Verbose"))
                {
                    translator.PushDGTweeningLogBehaviour(L, DG.Tweening.LogBehaviour.Verbose);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ErrorsOnly"))
                {
                    translator.PushDGTweeningLogBehaviour(L, DG.Tweening.LogBehaviour.ErrorsOnly);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.LogBehaviour!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.LogBehaviour! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningLoopTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.LoopType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.LoopType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.LoopType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Restart", DG.Tweening.LoopType.Restart);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Yoyo", DG.Tweening.LoopType.Yoyo);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Incremental", DG.Tweening.LoopType.Incremental);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.LoopType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningLoopType(L, (DG.Tweening.LoopType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Restart"))
                {
                    translator.PushDGTweeningLoopType(L, DG.Tweening.LoopType.Restart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Yoyo"))
                {
                    translator.PushDGTweeningLoopType(L, DG.Tweening.LoopType.Yoyo);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Incremental"))
                {
                    translator.PushDGTweeningLoopType(L, DG.Tweening.LoopType.Incremental);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.LoopType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.LoopType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningPathModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.PathMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.PathMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.PathMode), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Ignore", DG.Tweening.PathMode.Ignore);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Full3D", DG.Tweening.PathMode.Full3D);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopDown2D", DG.Tweening.PathMode.TopDown2D);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sidescroller2D", DG.Tweening.PathMode.Sidescroller2D);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.PathMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningPathMode(L, (DG.Tweening.PathMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Ignore"))
                {
                    translator.PushDGTweeningPathMode(L, DG.Tweening.PathMode.Ignore);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Full3D"))
                {
                    translator.PushDGTweeningPathMode(L, DG.Tweening.PathMode.Full3D);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "TopDown2D"))
                {
                    translator.PushDGTweeningPathMode(L, DG.Tweening.PathMode.TopDown2D);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sidescroller2D"))
                {
                    translator.PushDGTweeningPathMode(L, DG.Tweening.PathMode.Sidescroller2D);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.PathMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.PathMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningPathTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.PathType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.PathType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.PathType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Linear", DG.Tweening.PathType.Linear);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CatmullRom", DG.Tweening.PathType.CatmullRom);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CubicBezier", DG.Tweening.PathType.CubicBezier);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.PathType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningPathType(L, (DG.Tweening.PathType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Linear"))
                {
                    translator.PushDGTweeningPathType(L, DG.Tweening.PathType.Linear);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CatmullRom"))
                {
                    translator.PushDGTweeningPathType(L, DG.Tweening.PathType.CatmullRom);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "CubicBezier"))
                {
                    translator.PushDGTweeningPathType(L, DG.Tweening.PathType.CubicBezier);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.PathType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.PathType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningRotateModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.RotateMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.RotateMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.RotateMode), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Fast", DG.Tweening.RotateMode.Fast);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FastBeyond360", DG.Tweening.RotateMode.FastBeyond360);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "WorldAxisAdd", DG.Tweening.RotateMode.WorldAxisAdd);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "LocalAxisAdd", DG.Tweening.RotateMode.LocalAxisAdd);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.RotateMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningRotateMode(L, (DG.Tweening.RotateMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Fast"))
                {
                    translator.PushDGTweeningRotateMode(L, DG.Tweening.RotateMode.Fast);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "FastBeyond360"))
                {
                    translator.PushDGTweeningRotateMode(L, DG.Tweening.RotateMode.FastBeyond360);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "WorldAxisAdd"))
                {
                    translator.PushDGTweeningRotateMode(L, DG.Tweening.RotateMode.WorldAxisAdd);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "LocalAxisAdd"))
                {
                    translator.PushDGTweeningRotateMode(L, DG.Tweening.RotateMode.LocalAxisAdd);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.RotateMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.RotateMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningScrambleModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.ScrambleMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.ScrambleMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.ScrambleMode), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "None", DG.Tweening.ScrambleMode.None);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "All", DG.Tweening.ScrambleMode.All);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Uppercase", DG.Tweening.ScrambleMode.Uppercase);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Lowercase", DG.Tweening.ScrambleMode.Lowercase);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Numerals", DG.Tweening.ScrambleMode.Numerals);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Custom", DG.Tweening.ScrambleMode.Custom);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.ScrambleMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningScrambleMode(L, (DG.Tweening.ScrambleMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "None"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.None);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "All"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.All);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Uppercase"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.Uppercase);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Lowercase"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.Lowercase);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Numerals"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.Numerals);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Custom"))
                {
                    translator.PushDGTweeningScrambleMode(L, DG.Tweening.ScrambleMode.Custom);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.ScrambleMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.ScrambleMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningTweenTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.TweenType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.TweenType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.TweenType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Tweener", DG.Tweening.TweenType.Tweener);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Sequence", DG.Tweening.TweenType.Sequence);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Callback", DG.Tweening.TweenType.Callback);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.TweenType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningTweenType(L, (DG.Tweening.TweenType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Tweener"))
                {
                    translator.PushDGTweeningTweenType(L, DG.Tweening.TweenType.Tweener);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Sequence"))
                {
                    translator.PushDGTweeningTweenType(L, DG.Tweening.TweenType.Sequence);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Callback"))
                {
                    translator.PushDGTweeningTweenType(L, DG.Tweening.TweenType.Callback);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.TweenType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.TweenType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class DGTweeningUpdateTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(DG.Tweening.UpdateType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(DG.Tweening.UpdateType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(DG.Tweening.UpdateType), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Normal", DG.Tweening.UpdateType.Normal);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Late", DG.Tweening.UpdateType.Late);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Fixed", DG.Tweening.UpdateType.Fixed);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Manual", DG.Tweening.UpdateType.Manual);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(DG.Tweening.UpdateType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushDGTweeningUpdateType(L, (DG.Tweening.UpdateType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Normal"))
                {
                    translator.PushDGTweeningUpdateType(L, DG.Tweening.UpdateType.Normal);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Late"))
                {
                    translator.PushDGTweeningUpdateType(L, DG.Tweening.UpdateType.Late);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Fixed"))
                {
                    translator.PushDGTweeningUpdateType(L, DG.Tweening.UpdateType.Fixed);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Manual"))
                {
                    translator.PushDGTweeningUpdateType(L, DG.Tweening.UpdateType.Manual);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for DG.Tweening.UpdateType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for DG.Tweening.UpdateType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGamePlayModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.PlayMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.PlayMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.PlayMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Single", MyGame.PlayMode.Single);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Multi", MyGame.PlayMode.Multi);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.PlayMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGamePlayMode(L, (MyGame.PlayMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Single"))
                {
                    translator.PushMyGamePlayMode(L, MyGame.PlayMode.Single);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Multi"))
                {
                    translator.PushMyGamePlayMode(L, MyGame.PlayMode.Multi);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.PlayMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.PlayMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameGameStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.GameState), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.GameState), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.GameState), L, null, 5, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "begin", MyGame.GameState.begin);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "req", MyGame.GameState.req);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "play", MyGame.GameState.play);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "end", MyGame.GameState.end);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.GameState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameGameState(L, (MyGame.GameState)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "begin"))
                {
                    translator.PushMyGameGameState(L, MyGame.GameState.begin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "req"))
                {
                    translator.PushMyGameGameState(L, MyGame.GameState.req);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "play"))
                {
                    translator.PushMyGameGameState(L, MyGame.GameState.play);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "end"))
                {
                    translator.PushMyGameGameState(L, MyGame.GameState.end);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.GameState!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.GameState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameCardGroupTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.CardGroupType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.CardGroupType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.CardGroupType), L, null, 10, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "nil", MyGame.CardGroupType.nil);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "huojian", MyGame.CardGroupType.huojian);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "zhadan", MyGame.CardGroupType.zhadan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "sanshun", MyGame.CardGroupType.sanshun);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "shuangshun", MyGame.CardGroupType.shuangshun);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "danshun", MyGame.CardGroupType.danshun);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "sanzhang", MyGame.CardGroupType.sanzhang);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "duizi", MyGame.CardGroupType.duizi);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "danzhang", MyGame.CardGroupType.danzhang);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.CardGroupType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameCardGroupType(L, (MyGame.CardGroupType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "nil"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.nil);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "huojian"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.huojian);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "zhadan"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.zhadan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "sanshun"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.sanshun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "shuangshun"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.shuangshun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "danshun"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.danshun);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "sanzhang"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.sanzhang);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "duizi"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.duizi);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "danzhang"))
                {
                    translator.PushMyGameCardGroupType(L, MyGame.CardGroupType.danzhang);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.CardGroupType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.CardGroupType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameSuitTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.SuitType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.SuitType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.SuitType), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Diamond", MyGame.SuitType.Diamond);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Heart", MyGame.SuitType.Heart);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Club", MyGame.SuitType.Club);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Spade", MyGame.SuitType.Spade);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Joker", MyGame.SuitType.Joker);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Null", MyGame.SuitType.Null);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.SuitType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameSuitType(L, (MyGame.SuitType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Diamond"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Diamond);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Heart"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Heart);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Club"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Club);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Spade"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Spade);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Joker"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Joker);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Null"))
                {
                    translator.PushMyGameSuitType(L, MyGame.SuitType.Null);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.SuitType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.SuitType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameCardLevelWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.CardLevel), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.CardLevel), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.CardLevel), L, null, 16, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c3", MyGame.CardLevel.c3);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c4", MyGame.CardLevel.c4);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c5", MyGame.CardLevel.c5);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c6", MyGame.CardLevel.c6);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c7", MyGame.CardLevel.c7);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c8", MyGame.CardLevel.c8);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c9", MyGame.CardLevel.c9);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c10", MyGame.CardLevel.c10);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "cj", MyGame.CardLevel.cj);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "cq", MyGame.CardLevel.cq);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ck", MyGame.CardLevel.ck);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ca", MyGame.CardLevel.ca);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "c2", MyGame.CardLevel.c2);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "cjokerl", MyGame.CardLevel.cjokerl);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "cjoker", MyGame.CardLevel.cjoker);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.CardLevel), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameCardLevel(L, (MyGame.CardLevel)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "c3"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c3);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c4"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c4);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c5"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c5);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c6"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c6);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c7"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c7);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c8"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c8);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c9"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c9);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c10"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c10);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "cj"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.cj);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "cq"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.cq);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ck"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.ck);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ca"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.ca);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "c2"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.c2);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "cjokerl"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.cjokerl);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "cjoker"))
                {
                    translator.PushMyGameCardLevel(L, MyGame.CardLevel.cjoker);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.CardLevel!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.CardLevel! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameCardTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.CardType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.CardType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.CardType), L, null, 9, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "dan", MyGame.CardType.dan);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "duizi", MyGame.CardType.duizi);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "wangzha", MyGame.CardType.wangzha);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "zha", MyGame.CardType.zha);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "shunzi", MyGame.CardType.shunzi);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "sandaiyi", MyGame.CardType.sandaiyi);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "liandui", MyGame.CardType.liandui);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "nil", MyGame.CardType.nil);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.CardType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameCardType(L, (MyGame.CardType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "dan"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.dan);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "duizi"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.duizi);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "wangzha"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.wangzha);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "zha"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.zha);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "shunzi"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.shunzi);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "sandaiyi"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.sandaiyi);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "liandui"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.liandui);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "nil"))
                {
                    translator.PushMyGameCardType(L, MyGame.CardType.nil);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.CardType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.CardType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameUIFormIdWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.UIFormId), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.UIFormId), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.UIFormId), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "SignIn", MyGame.UIFormId.SignIn);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MainMenu", MyGame.UIFormId.MainMenu);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Room", MyGame.UIFormId.Room);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Game", MyGame.UIFormId.Game);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Dialog", MyGame.UIFormId.Dialog);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Command", MyGame.UIFormId.Command);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.UIFormId), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameUIFormId(L, (MyGame.UIFormId)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "SignIn"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.SignIn);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "MainMenu"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.MainMenu);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Room"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.Room);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Game"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.Game);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Dialog"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.Dialog);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Command"))
                {
                    translator.PushMyGameUIFormId(L, MyGame.UIFormId.Command);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.UIFormId!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.UIFormId! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGamePacketTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.PacketType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.PacketType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.PacketType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Undefined", MyGame.PacketType.Undefined);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ClientToServer", MyGame.PacketType.ClientToServer);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ServerToClient", MyGame.PacketType.ServerToClient);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.PacketType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGamePacketType(L, (MyGame.PacketType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Undefined"))
                {
                    translator.PushMyGamePacketType(L, MyGame.PacketType.Undefined);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ClientToServer"))
                {
                    translator.PushMyGamePacketType(L, MyGame.PacketType.ClientToServer);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "ServerToClient"))
                {
                    translator.PushMyGamePacketType(L, MyGame.PacketType.ServerToClient);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.PacketType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.PacketType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameHandlerTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.HandlerType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.HandlerType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.HandlerType), L, null, 4, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Undefined", MyGame.HandlerType.Undefined);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Request", MyGame.HandlerType.Request);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Response", MyGame.HandlerType.Response);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.HandlerType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameHandlerType(L, (MyGame.HandlerType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Undefined"))
                {
                    translator.PushMyGameHandlerType(L, MyGame.HandlerType.Undefined);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Request"))
                {
                    translator.PushMyGameHandlerType(L, MyGame.HandlerType.Request);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Response"))
                {
                    translator.PushMyGameHandlerType(L, MyGame.HandlerType.Response);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.HandlerType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.HandlerType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameCardStateWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.CardState), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.CardState), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.CardState), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Release", MyGame.CardState.Release);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Selecting", MyGame.CardState.Selecting);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.CardState), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameCardState(L, (MyGame.CardState)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Release"))
                {
                    translator.PushMyGameCardState(L, MyGame.CardState.Release);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Selecting"))
                {
                    translator.PushMyGameCardState(L, MyGame.CardState.Selecting);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.CardState!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.CardState! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class MyGameCommandModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(MyGame.CommandMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(MyGame.CommandMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(MyGame.CommandMode), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "single_begin", MyGame.CommandMode.single_begin);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "mult_begin", MyGame.CommandMode.mult_begin);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "req_master", MyGame.CommandMode.req_master);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "gen", MyGame.CommandMode.gen);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "chu", MyGame.CommandMode.chu);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "end", MyGame.CommandMode.end);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(MyGame.CommandMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushMyGameCommandMode(L, (MyGame.CommandMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "single_begin"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.single_begin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "mult_begin"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.mult_begin);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "req_master"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.req_master);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "gen"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.gen);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "chu"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.chu);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "end"))
                {
                    translator.PushMyGameCommandMode(L, MyGame.CommandMode.end);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for MyGame.CommandMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for MyGame.CommandMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}