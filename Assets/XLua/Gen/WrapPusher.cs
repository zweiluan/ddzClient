#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class ObjectTranslator
    {
        
        class IniterAdderUnityEngineVector2
        {
            static IniterAdderUnityEngineVector2()
            {
                LuaEnv.AddIniter(Init);
            }
			
			static void Init(LuaEnv luaenv, ObjectTranslator translator)
			{
			
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector2>(translator.PushUnityEngineVector2, translator.Get, translator.UpdateUnityEngineVector2);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector3>(translator.PushUnityEngineVector3, translator.Get, translator.UpdateUnityEngineVector3);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Vector4>(translator.PushUnityEngineVector4, translator.Get, translator.UpdateUnityEngineVector4);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Color>(translator.PushUnityEngineColor, translator.Get, translator.UpdateUnityEngineColor);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Quaternion>(translator.PushUnityEngineQuaternion, translator.Get, translator.UpdateUnityEngineQuaternion);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray>(translator.PushUnityEngineRay, translator.Get, translator.UpdateUnityEngineRay);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Bounds>(translator.PushUnityEngineBounds, translator.Get, translator.UpdateUnityEngineBounds);
				translator.RegisterPushAndGetAndUpdate<UnityEngine.Ray2D>(translator.PushUnityEngineRay2D, translator.Get, translator.UpdateUnityEngineRay2D);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.AutoPlay>(translator.PushDGTweeningAutoPlay, translator.Get, translator.UpdateDGTweeningAutoPlay);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.AxisConstraint>(translator.PushDGTweeningAxisConstraint, translator.Get, translator.UpdateDGTweeningAxisConstraint);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.Ease>(translator.PushDGTweeningEase, translator.Get, translator.UpdateDGTweeningEase);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.LogBehaviour>(translator.PushDGTweeningLogBehaviour, translator.Get, translator.UpdateDGTweeningLogBehaviour);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.LoopType>(translator.PushDGTweeningLoopType, translator.Get, translator.UpdateDGTweeningLoopType);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.PathMode>(translator.PushDGTweeningPathMode, translator.Get, translator.UpdateDGTweeningPathMode);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.PathType>(translator.PushDGTweeningPathType, translator.Get, translator.UpdateDGTweeningPathType);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.RotateMode>(translator.PushDGTweeningRotateMode, translator.Get, translator.UpdateDGTweeningRotateMode);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.ScrambleMode>(translator.PushDGTweeningScrambleMode, translator.Get, translator.UpdateDGTweeningScrambleMode);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.TweenType>(translator.PushDGTweeningTweenType, translator.Get, translator.UpdateDGTweeningTweenType);
				translator.RegisterPushAndGetAndUpdate<DG.Tweening.UpdateType>(translator.PushDGTweeningUpdateType, translator.Get, translator.UpdateDGTweeningUpdateType);
				translator.RegisterPushAndGetAndUpdate<MyGame.PlayMode>(translator.PushMyGamePlayMode, translator.Get, translator.UpdateMyGamePlayMode);
				translator.RegisterPushAndGetAndUpdate<MyGame.GameState>(translator.PushMyGameGameState, translator.Get, translator.UpdateMyGameGameState);
				translator.RegisterPushAndGetAndUpdate<MyGame.CardGroupType>(translator.PushMyGameCardGroupType, translator.Get, translator.UpdateMyGameCardGroupType);
				translator.RegisterPushAndGetAndUpdate<MyGame.SuitType>(translator.PushMyGameSuitType, translator.Get, translator.UpdateMyGameSuitType);
				translator.RegisterPushAndGetAndUpdate<MyGame.CardLevel>(translator.PushMyGameCardLevel, translator.Get, translator.UpdateMyGameCardLevel);
				translator.RegisterPushAndGetAndUpdate<MyGame.CardType>(translator.PushMyGameCardType, translator.Get, translator.UpdateMyGameCardType);
				translator.RegisterPushAndGetAndUpdate<MyGame.UIFormId>(translator.PushMyGameUIFormId, translator.Get, translator.UpdateMyGameUIFormId);
				translator.RegisterPushAndGetAndUpdate<MyGame.PacketType>(translator.PushMyGamePacketType, translator.Get, translator.UpdateMyGamePacketType);
				translator.RegisterPushAndGetAndUpdate<MyGame.HandlerType>(translator.PushMyGameHandlerType, translator.Get, translator.UpdateMyGameHandlerType);
				translator.RegisterPushAndGetAndUpdate<MyGame.CardState>(translator.PushMyGameCardState, translator.Get, translator.UpdateMyGameCardState);
				translator.RegisterPushAndGetAndUpdate<MyGame.CommandMode>(translator.PushMyGameCommandMode, translator.Get, translator.UpdateMyGameCommandMode);
			
			}
        }
        
        static IniterAdderUnityEngineVector2 s_IniterAdderUnityEngineVector2_dumb_obj = new IniterAdderUnityEngineVector2();
        static IniterAdderUnityEngineVector2 IniterAdderUnityEngineVector2_dumb_obj {get{return s_IniterAdderUnityEngineVector2_dumb_obj;}}
        
        
        int UnityEngineVector2_TypeID = -1;
        public void PushUnityEngineVector2(RealStatePtr L, UnityEngine.Vector2 val)
        {
            if (UnityEngineVector2_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector2_TypeID = getTypeId(L, typeof(UnityEngine.Vector2), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 8, UnityEngineVector2_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector2 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector2 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector2");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector2)objectCasters.GetCaster(typeof(UnityEngine.Vector2))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector2(RealStatePtr L, int index, UnityEngine.Vector2 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector2_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector2");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector2 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector3_TypeID = -1;
        public void PushUnityEngineVector3(RealStatePtr L, UnityEngine.Vector3 val)
        {
            if (UnityEngineVector3_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector3_TypeID = getTypeId(L, typeof(UnityEngine.Vector3), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 12, UnityEngineVector3_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector3 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector3 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector3");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector3)objectCasters.GetCaster(typeof(UnityEngine.Vector3))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector3(RealStatePtr L, int index, UnityEngine.Vector3 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector3_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector3");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector3 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineVector4_TypeID = -1;
        public void PushUnityEngineVector4(RealStatePtr L, UnityEngine.Vector4 val)
        {
            if (UnityEngineVector4_TypeID == -1)
            {
			    bool is_first;
                UnityEngineVector4_TypeID = getTypeId(L, typeof(UnityEngine.Vector4), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineVector4_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Vector4 ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Vector4 val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Vector4");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Vector4)objectCasters.GetCaster(typeof(UnityEngine.Vector4))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineVector4(RealStatePtr L, int index, UnityEngine.Vector4 val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineVector4_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Vector4");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Vector4 ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineColor_TypeID = -1;
        public void PushUnityEngineColor(RealStatePtr L, UnityEngine.Color val)
        {
            if (UnityEngineColor_TypeID == -1)
            {
			    bool is_first;
                UnityEngineColor_TypeID = getTypeId(L, typeof(UnityEngine.Color), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineColor_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Color ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Color val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Color");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Color)objectCasters.GetCaster(typeof(UnityEngine.Color))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineColor(RealStatePtr L, int index, UnityEngine.Color val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineColor_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Color");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Color ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineQuaternion_TypeID = -1;
        public void PushUnityEngineQuaternion(RealStatePtr L, UnityEngine.Quaternion val)
        {
            if (UnityEngineQuaternion_TypeID == -1)
            {
			    bool is_first;
                UnityEngineQuaternion_TypeID = getTypeId(L, typeof(UnityEngine.Quaternion), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineQuaternion_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Quaternion ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Quaternion val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Quaternion");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Quaternion)objectCasters.GetCaster(typeof(UnityEngine.Quaternion))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineQuaternion(RealStatePtr L, int index, UnityEngine.Quaternion val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineQuaternion_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Quaternion");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Quaternion ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay_TypeID = -1;
        public void PushUnityEngineRay(RealStatePtr L, UnityEngine.Ray val)
        {
            if (UnityEngineRay_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay_TypeID = getTypeId(L, typeof(UnityEngine.Ray), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineRay_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray)objectCasters.GetCaster(typeof(UnityEngine.Ray))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay(RealStatePtr L, int index, UnityEngine.Ray val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineBounds_TypeID = -1;
        public void PushUnityEngineBounds(RealStatePtr L, UnityEngine.Bounds val)
        {
            if (UnityEngineBounds_TypeID == -1)
            {
			    bool is_first;
                UnityEngineBounds_TypeID = getTypeId(L, typeof(UnityEngine.Bounds), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 24, UnityEngineBounds_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Bounds ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Bounds val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Bounds");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Bounds)objectCasters.GetCaster(typeof(UnityEngine.Bounds))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineBounds(RealStatePtr L, int index, UnityEngine.Bounds val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineBounds_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Bounds");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Bounds ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int UnityEngineRay2D_TypeID = -1;
        public void PushUnityEngineRay2D(RealStatePtr L, UnityEngine.Ray2D val)
        {
            if (UnityEngineRay2D_TypeID == -1)
            {
			    bool is_first;
                UnityEngineRay2D_TypeID = getTypeId(L, typeof(UnityEngine.Ray2D), out is_first);
				
            }
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 16, UnityEngineRay2D_TypeID);
            if (!CopyByValue.Pack(buff, 0, val))
            {
                throw new Exception("pack fail fail for UnityEngine.Ray2D ,value="+val);
            }
			
        }
		
        public void Get(RealStatePtr L, int index, out UnityEngine.Ray2D val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);if (!CopyByValue.UnPack(buff, 0, out val))
                {
                    throw new Exception("unpack fail for UnityEngine.Ray2D");
                }
            }
			else if (type ==LuaTypes.LUA_TTABLE)
			{
			    CopyByValue.UnPack(this, L, index, out val);
			}
            else
            {
                val = (UnityEngine.Ray2D)objectCasters.GetCaster(typeof(UnityEngine.Ray2D))(L, index, null);
            }
        }
		
        public void UpdateUnityEngineRay2D(RealStatePtr L, int index, UnityEngine.Ray2D val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != UnityEngineRay2D_TypeID)
				{
				    throw new Exception("invalid userdata for UnityEngine.Ray2D");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  val))
                {
                    throw new Exception("pack fail for UnityEngine.Ray2D ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningAutoPlay_TypeID = -1;
		int DGTweeningAutoPlay_EnumRef = -1;
        
        public void PushDGTweeningAutoPlay(RealStatePtr L, DG.Tweening.AutoPlay val)
        {
            if (DGTweeningAutoPlay_TypeID == -1)
            {
			    bool is_first;
                DGTweeningAutoPlay_TypeID = getTypeId(L, typeof(DG.Tweening.AutoPlay), out is_first);
				
				if (DGTweeningAutoPlay_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.AutoPlay));
				    DGTweeningAutoPlay_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningAutoPlay_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningAutoPlay_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.AutoPlay ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningAutoPlay_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.AutoPlay val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningAutoPlay_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.AutoPlay");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.AutoPlay");
                }
				val = (DG.Tweening.AutoPlay)e;
                
            }
            else
            {
                val = (DG.Tweening.AutoPlay)objectCasters.GetCaster(typeof(DG.Tweening.AutoPlay))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningAutoPlay(RealStatePtr L, int index, DG.Tweening.AutoPlay val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningAutoPlay_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.AutoPlay");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.AutoPlay ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningAxisConstraint_TypeID = -1;
		int DGTweeningAxisConstraint_EnumRef = -1;
        
        public void PushDGTweeningAxisConstraint(RealStatePtr L, DG.Tweening.AxisConstraint val)
        {
            if (DGTweeningAxisConstraint_TypeID == -1)
            {
			    bool is_first;
                DGTweeningAxisConstraint_TypeID = getTypeId(L, typeof(DG.Tweening.AxisConstraint), out is_first);
				
				if (DGTweeningAxisConstraint_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.AxisConstraint));
				    DGTweeningAxisConstraint_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningAxisConstraint_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningAxisConstraint_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.AxisConstraint ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningAxisConstraint_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.AxisConstraint val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningAxisConstraint_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.AxisConstraint");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.AxisConstraint");
                }
				val = (DG.Tweening.AxisConstraint)e;
                
            }
            else
            {
                val = (DG.Tweening.AxisConstraint)objectCasters.GetCaster(typeof(DG.Tweening.AxisConstraint))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningAxisConstraint(RealStatePtr L, int index, DG.Tweening.AxisConstraint val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningAxisConstraint_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.AxisConstraint");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.AxisConstraint ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningEase_TypeID = -1;
		int DGTweeningEase_EnumRef = -1;
        
        public void PushDGTweeningEase(RealStatePtr L, DG.Tweening.Ease val)
        {
            if (DGTweeningEase_TypeID == -1)
            {
			    bool is_first;
                DGTweeningEase_TypeID = getTypeId(L, typeof(DG.Tweening.Ease), out is_first);
				
				if (DGTweeningEase_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.Ease));
				    DGTweeningEase_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningEase_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningEase_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.Ease ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningEase_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.Ease val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningEase_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.Ease");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.Ease");
                }
				val = (DG.Tweening.Ease)e;
                
            }
            else
            {
                val = (DG.Tweening.Ease)objectCasters.GetCaster(typeof(DG.Tweening.Ease))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningEase(RealStatePtr L, int index, DG.Tweening.Ease val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningEase_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.Ease");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.Ease ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningLogBehaviour_TypeID = -1;
		int DGTweeningLogBehaviour_EnumRef = -1;
        
        public void PushDGTweeningLogBehaviour(RealStatePtr L, DG.Tweening.LogBehaviour val)
        {
            if (DGTweeningLogBehaviour_TypeID == -1)
            {
			    bool is_first;
                DGTweeningLogBehaviour_TypeID = getTypeId(L, typeof(DG.Tweening.LogBehaviour), out is_first);
				
				if (DGTweeningLogBehaviour_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.LogBehaviour));
				    DGTweeningLogBehaviour_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningLogBehaviour_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningLogBehaviour_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.LogBehaviour ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningLogBehaviour_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.LogBehaviour val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningLogBehaviour_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.LogBehaviour");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.LogBehaviour");
                }
				val = (DG.Tweening.LogBehaviour)e;
                
            }
            else
            {
                val = (DG.Tweening.LogBehaviour)objectCasters.GetCaster(typeof(DG.Tweening.LogBehaviour))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningLogBehaviour(RealStatePtr L, int index, DG.Tweening.LogBehaviour val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningLogBehaviour_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.LogBehaviour");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.LogBehaviour ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningLoopType_TypeID = -1;
		int DGTweeningLoopType_EnumRef = -1;
        
        public void PushDGTweeningLoopType(RealStatePtr L, DG.Tweening.LoopType val)
        {
            if (DGTweeningLoopType_TypeID == -1)
            {
			    bool is_first;
                DGTweeningLoopType_TypeID = getTypeId(L, typeof(DG.Tweening.LoopType), out is_first);
				
				if (DGTweeningLoopType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.LoopType));
				    DGTweeningLoopType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningLoopType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningLoopType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.LoopType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningLoopType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.LoopType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningLoopType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.LoopType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.LoopType");
                }
				val = (DG.Tweening.LoopType)e;
                
            }
            else
            {
                val = (DG.Tweening.LoopType)objectCasters.GetCaster(typeof(DG.Tweening.LoopType))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningLoopType(RealStatePtr L, int index, DG.Tweening.LoopType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningLoopType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.LoopType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.LoopType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningPathMode_TypeID = -1;
		int DGTweeningPathMode_EnumRef = -1;
        
        public void PushDGTweeningPathMode(RealStatePtr L, DG.Tweening.PathMode val)
        {
            if (DGTweeningPathMode_TypeID == -1)
            {
			    bool is_first;
                DGTweeningPathMode_TypeID = getTypeId(L, typeof(DG.Tweening.PathMode), out is_first);
				
				if (DGTweeningPathMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.PathMode));
				    DGTweeningPathMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningPathMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningPathMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.PathMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningPathMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.PathMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningPathMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.PathMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.PathMode");
                }
				val = (DG.Tweening.PathMode)e;
                
            }
            else
            {
                val = (DG.Tweening.PathMode)objectCasters.GetCaster(typeof(DG.Tweening.PathMode))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningPathMode(RealStatePtr L, int index, DG.Tweening.PathMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningPathMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.PathMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.PathMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningPathType_TypeID = -1;
		int DGTweeningPathType_EnumRef = -1;
        
        public void PushDGTweeningPathType(RealStatePtr L, DG.Tweening.PathType val)
        {
            if (DGTweeningPathType_TypeID == -1)
            {
			    bool is_first;
                DGTweeningPathType_TypeID = getTypeId(L, typeof(DG.Tweening.PathType), out is_first);
				
				if (DGTweeningPathType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.PathType));
				    DGTweeningPathType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningPathType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningPathType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.PathType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningPathType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.PathType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningPathType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.PathType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.PathType");
                }
				val = (DG.Tweening.PathType)e;
                
            }
            else
            {
                val = (DG.Tweening.PathType)objectCasters.GetCaster(typeof(DG.Tweening.PathType))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningPathType(RealStatePtr L, int index, DG.Tweening.PathType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningPathType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.PathType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.PathType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningRotateMode_TypeID = -1;
		int DGTweeningRotateMode_EnumRef = -1;
        
        public void PushDGTweeningRotateMode(RealStatePtr L, DG.Tweening.RotateMode val)
        {
            if (DGTweeningRotateMode_TypeID == -1)
            {
			    bool is_first;
                DGTweeningRotateMode_TypeID = getTypeId(L, typeof(DG.Tweening.RotateMode), out is_first);
				
				if (DGTweeningRotateMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.RotateMode));
				    DGTweeningRotateMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningRotateMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningRotateMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.RotateMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningRotateMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.RotateMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningRotateMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.RotateMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.RotateMode");
                }
				val = (DG.Tweening.RotateMode)e;
                
            }
            else
            {
                val = (DG.Tweening.RotateMode)objectCasters.GetCaster(typeof(DG.Tweening.RotateMode))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningRotateMode(RealStatePtr L, int index, DG.Tweening.RotateMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningRotateMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.RotateMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.RotateMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningScrambleMode_TypeID = -1;
		int DGTweeningScrambleMode_EnumRef = -1;
        
        public void PushDGTweeningScrambleMode(RealStatePtr L, DG.Tweening.ScrambleMode val)
        {
            if (DGTweeningScrambleMode_TypeID == -1)
            {
			    bool is_first;
                DGTweeningScrambleMode_TypeID = getTypeId(L, typeof(DG.Tweening.ScrambleMode), out is_first);
				
				if (DGTweeningScrambleMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.ScrambleMode));
				    DGTweeningScrambleMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningScrambleMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningScrambleMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.ScrambleMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningScrambleMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.ScrambleMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningScrambleMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.ScrambleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.ScrambleMode");
                }
				val = (DG.Tweening.ScrambleMode)e;
                
            }
            else
            {
                val = (DG.Tweening.ScrambleMode)objectCasters.GetCaster(typeof(DG.Tweening.ScrambleMode))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningScrambleMode(RealStatePtr L, int index, DG.Tweening.ScrambleMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningScrambleMode_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.ScrambleMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.ScrambleMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningTweenType_TypeID = -1;
		int DGTweeningTweenType_EnumRef = -1;
        
        public void PushDGTweeningTweenType(RealStatePtr L, DG.Tweening.TweenType val)
        {
            if (DGTweeningTweenType_TypeID == -1)
            {
			    bool is_first;
                DGTweeningTweenType_TypeID = getTypeId(L, typeof(DG.Tweening.TweenType), out is_first);
				
				if (DGTweeningTweenType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.TweenType));
				    DGTweeningTweenType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningTweenType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningTweenType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.TweenType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningTweenType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.TweenType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningTweenType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.TweenType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.TweenType");
                }
				val = (DG.Tweening.TweenType)e;
                
            }
            else
            {
                val = (DG.Tweening.TweenType)objectCasters.GetCaster(typeof(DG.Tweening.TweenType))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningTweenType(RealStatePtr L, int index, DG.Tweening.TweenType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningTweenType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.TweenType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.TweenType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int DGTweeningUpdateType_TypeID = -1;
		int DGTweeningUpdateType_EnumRef = -1;
        
        public void PushDGTweeningUpdateType(RealStatePtr L, DG.Tweening.UpdateType val)
        {
            if (DGTweeningUpdateType_TypeID == -1)
            {
			    bool is_first;
                DGTweeningUpdateType_TypeID = getTypeId(L, typeof(DG.Tweening.UpdateType), out is_first);
				
				if (DGTweeningUpdateType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(DG.Tweening.UpdateType));
				    DGTweeningUpdateType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, DGTweeningUpdateType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, DGTweeningUpdateType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for DG.Tweening.UpdateType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, DGTweeningUpdateType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out DG.Tweening.UpdateType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningUpdateType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.UpdateType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for DG.Tweening.UpdateType");
                }
				val = (DG.Tweening.UpdateType)e;
                
            }
            else
            {
                val = (DG.Tweening.UpdateType)objectCasters.GetCaster(typeof(DG.Tweening.UpdateType))(L, index, null);
            }
        }
		
        public void UpdateDGTweeningUpdateType(RealStatePtr L, int index, DG.Tweening.UpdateType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != DGTweeningUpdateType_TypeID)
				{
				    throw new Exception("invalid userdata for DG.Tweening.UpdateType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for DG.Tweening.UpdateType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGamePlayMode_TypeID = -1;
		int MyGamePlayMode_EnumRef = -1;
        
        public void PushMyGamePlayMode(RealStatePtr L, MyGame.PlayMode val)
        {
            if (MyGamePlayMode_TypeID == -1)
            {
			    bool is_first;
                MyGamePlayMode_TypeID = getTypeId(L, typeof(MyGame.PlayMode), out is_first);
				
				if (MyGamePlayMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.PlayMode));
				    MyGamePlayMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGamePlayMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGamePlayMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.PlayMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGamePlayMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.PlayMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGamePlayMode_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.PlayMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.PlayMode");
                }
				val = (MyGame.PlayMode)e;
                
            }
            else
            {
                val = (MyGame.PlayMode)objectCasters.GetCaster(typeof(MyGame.PlayMode))(L, index, null);
            }
        }
		
        public void UpdateMyGamePlayMode(RealStatePtr L, int index, MyGame.PlayMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGamePlayMode_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.PlayMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.PlayMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameGameState_TypeID = -1;
		int MyGameGameState_EnumRef = -1;
        
        public void PushMyGameGameState(RealStatePtr L, MyGame.GameState val)
        {
            if (MyGameGameState_TypeID == -1)
            {
			    bool is_first;
                MyGameGameState_TypeID = getTypeId(L, typeof(MyGame.GameState), out is_first);
				
				if (MyGameGameState_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.GameState));
				    MyGameGameState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameGameState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameGameState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.GameState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameGameState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.GameState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameGameState_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.GameState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.GameState");
                }
				val = (MyGame.GameState)e;
                
            }
            else
            {
                val = (MyGame.GameState)objectCasters.GetCaster(typeof(MyGame.GameState))(L, index, null);
            }
        }
		
        public void UpdateMyGameGameState(RealStatePtr L, int index, MyGame.GameState val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameGameState_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.GameState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.GameState ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameCardGroupType_TypeID = -1;
		int MyGameCardGroupType_EnumRef = -1;
        
        public void PushMyGameCardGroupType(RealStatePtr L, MyGame.CardGroupType val)
        {
            if (MyGameCardGroupType_TypeID == -1)
            {
			    bool is_first;
                MyGameCardGroupType_TypeID = getTypeId(L, typeof(MyGame.CardGroupType), out is_first);
				
				if (MyGameCardGroupType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.CardGroupType));
				    MyGameCardGroupType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameCardGroupType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameCardGroupType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.CardGroupType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameCardGroupType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.CardGroupType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardGroupType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardGroupType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.CardGroupType");
                }
				val = (MyGame.CardGroupType)e;
                
            }
            else
            {
                val = (MyGame.CardGroupType)objectCasters.GetCaster(typeof(MyGame.CardGroupType))(L, index, null);
            }
        }
		
        public void UpdateMyGameCardGroupType(RealStatePtr L, int index, MyGame.CardGroupType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardGroupType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardGroupType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.CardGroupType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameSuitType_TypeID = -1;
		int MyGameSuitType_EnumRef = -1;
        
        public void PushMyGameSuitType(RealStatePtr L, MyGame.SuitType val)
        {
            if (MyGameSuitType_TypeID == -1)
            {
			    bool is_first;
                MyGameSuitType_TypeID = getTypeId(L, typeof(MyGame.SuitType), out is_first);
				
				if (MyGameSuitType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.SuitType));
				    MyGameSuitType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameSuitType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameSuitType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.SuitType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameSuitType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.SuitType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameSuitType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.SuitType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.SuitType");
                }
				val = (MyGame.SuitType)e;
                
            }
            else
            {
                val = (MyGame.SuitType)objectCasters.GetCaster(typeof(MyGame.SuitType))(L, index, null);
            }
        }
		
        public void UpdateMyGameSuitType(RealStatePtr L, int index, MyGame.SuitType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameSuitType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.SuitType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.SuitType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameCardLevel_TypeID = -1;
		int MyGameCardLevel_EnumRef = -1;
        
        public void PushMyGameCardLevel(RealStatePtr L, MyGame.CardLevel val)
        {
            if (MyGameCardLevel_TypeID == -1)
            {
			    bool is_first;
                MyGameCardLevel_TypeID = getTypeId(L, typeof(MyGame.CardLevel), out is_first);
				
				if (MyGameCardLevel_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.CardLevel));
				    MyGameCardLevel_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameCardLevel_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameCardLevel_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.CardLevel ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameCardLevel_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.CardLevel val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardLevel_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardLevel");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.CardLevel");
                }
				val = (MyGame.CardLevel)e;
                
            }
            else
            {
                val = (MyGame.CardLevel)objectCasters.GetCaster(typeof(MyGame.CardLevel))(L, index, null);
            }
        }
		
        public void UpdateMyGameCardLevel(RealStatePtr L, int index, MyGame.CardLevel val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardLevel_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardLevel");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.CardLevel ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameCardType_TypeID = -1;
		int MyGameCardType_EnumRef = -1;
        
        public void PushMyGameCardType(RealStatePtr L, MyGame.CardType val)
        {
            if (MyGameCardType_TypeID == -1)
            {
			    bool is_first;
                MyGameCardType_TypeID = getTypeId(L, typeof(MyGame.CardType), out is_first);
				
				if (MyGameCardType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.CardType));
				    MyGameCardType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameCardType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameCardType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.CardType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameCardType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.CardType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.CardType");
                }
				val = (MyGame.CardType)e;
                
            }
            else
            {
                val = (MyGame.CardType)objectCasters.GetCaster(typeof(MyGame.CardType))(L, index, null);
            }
        }
		
        public void UpdateMyGameCardType(RealStatePtr L, int index, MyGame.CardType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.CardType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameUIFormId_TypeID = -1;
		int MyGameUIFormId_EnumRef = -1;
        
        public void PushMyGameUIFormId(RealStatePtr L, MyGame.UIFormId val)
        {
            if (MyGameUIFormId_TypeID == -1)
            {
			    bool is_first;
                MyGameUIFormId_TypeID = getTypeId(L, typeof(MyGame.UIFormId), out is_first);
				
				if (MyGameUIFormId_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.UIFormId));
				    MyGameUIFormId_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameUIFormId_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameUIFormId_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.UIFormId ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameUIFormId_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.UIFormId val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameUIFormId_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.UIFormId");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.UIFormId");
                }
				val = (MyGame.UIFormId)e;
                
            }
            else
            {
                val = (MyGame.UIFormId)objectCasters.GetCaster(typeof(MyGame.UIFormId))(L, index, null);
            }
        }
		
        public void UpdateMyGameUIFormId(RealStatePtr L, int index, MyGame.UIFormId val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameUIFormId_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.UIFormId");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.UIFormId ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGamePacketType_TypeID = -1;
		int MyGamePacketType_EnumRef = -1;
        
        public void PushMyGamePacketType(RealStatePtr L, MyGame.PacketType val)
        {
            if (MyGamePacketType_TypeID == -1)
            {
			    bool is_first;
                MyGamePacketType_TypeID = getTypeId(L, typeof(MyGame.PacketType), out is_first);
				
				if (MyGamePacketType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.PacketType));
				    MyGamePacketType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGamePacketType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGamePacketType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.PacketType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGamePacketType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.PacketType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGamePacketType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.PacketType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.PacketType");
                }
				val = (MyGame.PacketType)e;
                
            }
            else
            {
                val = (MyGame.PacketType)objectCasters.GetCaster(typeof(MyGame.PacketType))(L, index, null);
            }
        }
		
        public void UpdateMyGamePacketType(RealStatePtr L, int index, MyGame.PacketType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGamePacketType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.PacketType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.PacketType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameHandlerType_TypeID = -1;
		int MyGameHandlerType_EnumRef = -1;
        
        public void PushMyGameHandlerType(RealStatePtr L, MyGame.HandlerType val)
        {
            if (MyGameHandlerType_TypeID == -1)
            {
			    bool is_first;
                MyGameHandlerType_TypeID = getTypeId(L, typeof(MyGame.HandlerType), out is_first);
				
				if (MyGameHandlerType_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.HandlerType));
				    MyGameHandlerType_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameHandlerType_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameHandlerType_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.HandlerType ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameHandlerType_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.HandlerType val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameHandlerType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.HandlerType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.HandlerType");
                }
				val = (MyGame.HandlerType)e;
                
            }
            else
            {
                val = (MyGame.HandlerType)objectCasters.GetCaster(typeof(MyGame.HandlerType))(L, index, null);
            }
        }
		
        public void UpdateMyGameHandlerType(RealStatePtr L, int index, MyGame.HandlerType val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameHandlerType_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.HandlerType");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.HandlerType ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameCardState_TypeID = -1;
		int MyGameCardState_EnumRef = -1;
        
        public void PushMyGameCardState(RealStatePtr L, MyGame.CardState val)
        {
            if (MyGameCardState_TypeID == -1)
            {
			    bool is_first;
                MyGameCardState_TypeID = getTypeId(L, typeof(MyGame.CardState), out is_first);
				
				if (MyGameCardState_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.CardState));
				    MyGameCardState_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameCardState_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameCardState_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.CardState ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameCardState_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.CardState val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardState_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.CardState");
                }
				val = (MyGame.CardState)e;
                
            }
            else
            {
                val = (MyGame.CardState)objectCasters.GetCaster(typeof(MyGame.CardState))(L, index, null);
            }
        }
		
        public void UpdateMyGameCardState(RealStatePtr L, int index, MyGame.CardState val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCardState_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CardState");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.CardState ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        int MyGameCommandMode_TypeID = -1;
		int MyGameCommandMode_EnumRef = -1;
        
        public void PushMyGameCommandMode(RealStatePtr L, MyGame.CommandMode val)
        {
            if (MyGameCommandMode_TypeID == -1)
            {
			    bool is_first;
                MyGameCommandMode_TypeID = getTypeId(L, typeof(MyGame.CommandMode), out is_first);
				
				if (MyGameCommandMode_EnumRef == -1)
				{
				    Utils.LoadCSTable(L, typeof(MyGame.CommandMode));
				    MyGameCommandMode_EnumRef = LuaAPI.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
				}
				
            }
			
			if (LuaAPI.xlua_tryget_cachedud(L, (int)val, MyGameCommandMode_EnumRef) == 1)
            {
			    return;
			}
			
            IntPtr buff = LuaAPI.xlua_pushstruct(L, 4, MyGameCommandMode_TypeID);
            if (!CopyByValue.Pack(buff, 0, (int)val))
            {
                throw new Exception("pack fail fail for MyGame.CommandMode ,value="+val);
            }
			
			LuaAPI.lua_getref(L, MyGameCommandMode_EnumRef);
			LuaAPI.lua_pushvalue(L, -2);
			LuaAPI.xlua_rawseti(L, -2, (int)val);
			LuaAPI.lua_pop(L, 1);
			
        }
		
        public void Get(RealStatePtr L, int index, out MyGame.CommandMode val)
        {
		    LuaTypes type = LuaAPI.lua_type(L, index);
            if (type == LuaTypes.LUA_TUSERDATA )
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCommandMode_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CommandMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
				int e;
                if (!CopyByValue.UnPack(buff, 0, out e))
                {
                    throw new Exception("unpack fail for MyGame.CommandMode");
                }
				val = (MyGame.CommandMode)e;
                
            }
            else
            {
                val = (MyGame.CommandMode)objectCasters.GetCaster(typeof(MyGame.CommandMode))(L, index, null);
            }
        }
		
        public void UpdateMyGameCommandMode(RealStatePtr L, int index, MyGame.CommandMode val)
        {
		    
            if (LuaAPI.lua_type(L, index) == LuaTypes.LUA_TUSERDATA)
            {
			    if (LuaAPI.xlua_gettypeid(L, index) != MyGameCommandMode_TypeID)
				{
				    throw new Exception("invalid userdata for MyGame.CommandMode");
				}
				
                IntPtr buff = LuaAPI.lua_touserdata(L, index);
                if (!CopyByValue.Pack(buff, 0,  (int)val))
                {
                    throw new Exception("pack fail for MyGame.CommandMode ,value="+val);
                }
            }
			
            else
            {
                throw new Exception("try to update a data with lua type:" + LuaAPI.lua_type(L, index));
            }
        }
        
        
		// table cast optimze
		
        
    }
	
	public partial class StaticLuaCallbacks
    {
	    internal static bool __tryArrayGet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int index)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.PushUnityEngineVector2(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.PushUnityEngineVector3(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.PushUnityEngineVector4(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.PushUnityEngineColor(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.PushUnityEngineQuaternion(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.PushUnityEngineRay(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.PushUnityEngineBounds(L, array[index]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.PushUnityEngineRay2D(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.AutoPlay[]))
			{
			    DG.Tweening.AutoPlay[] array = obj as DG.Tweening.AutoPlay[];
				translator.PushDGTweeningAutoPlay(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.AxisConstraint[]))
			{
			    DG.Tweening.AxisConstraint[] array = obj as DG.Tweening.AxisConstraint[];
				translator.PushDGTweeningAxisConstraint(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.Ease[]))
			{
			    DG.Tweening.Ease[] array = obj as DG.Tweening.Ease[];
				translator.PushDGTweeningEase(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.LogBehaviour[]))
			{
			    DG.Tweening.LogBehaviour[] array = obj as DG.Tweening.LogBehaviour[];
				translator.PushDGTweeningLogBehaviour(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.LoopType[]))
			{
			    DG.Tweening.LoopType[] array = obj as DG.Tweening.LoopType[];
				translator.PushDGTweeningLoopType(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.PathMode[]))
			{
			    DG.Tweening.PathMode[] array = obj as DG.Tweening.PathMode[];
				translator.PushDGTweeningPathMode(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.PathType[]))
			{
			    DG.Tweening.PathType[] array = obj as DG.Tweening.PathType[];
				translator.PushDGTweeningPathType(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.RotateMode[]))
			{
			    DG.Tweening.RotateMode[] array = obj as DG.Tweening.RotateMode[];
				translator.PushDGTweeningRotateMode(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.ScrambleMode[]))
			{
			    DG.Tweening.ScrambleMode[] array = obj as DG.Tweening.ScrambleMode[];
				translator.PushDGTweeningScrambleMode(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.TweenType[]))
			{
			    DG.Tweening.TweenType[] array = obj as DG.Tweening.TweenType[];
				translator.PushDGTweeningTweenType(L, array[index]);
				return true;
			}
			else if (type == typeof(DG.Tweening.UpdateType[]))
			{
			    DG.Tweening.UpdateType[] array = obj as DG.Tweening.UpdateType[];
				translator.PushDGTweeningUpdateType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.PlayMode[]))
			{
			    MyGame.PlayMode[] array = obj as MyGame.PlayMode[];
				translator.PushMyGamePlayMode(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.GameState[]))
			{
			    MyGame.GameState[] array = obj as MyGame.GameState[];
				translator.PushMyGameGameState(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.CardGroupType[]))
			{
			    MyGame.CardGroupType[] array = obj as MyGame.CardGroupType[];
				translator.PushMyGameCardGroupType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.SuitType[]))
			{
			    MyGame.SuitType[] array = obj as MyGame.SuitType[];
				translator.PushMyGameSuitType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.CardLevel[]))
			{
			    MyGame.CardLevel[] array = obj as MyGame.CardLevel[];
				translator.PushMyGameCardLevel(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.CardType[]))
			{
			    MyGame.CardType[] array = obj as MyGame.CardType[];
				translator.PushMyGameCardType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.UIFormId[]))
			{
			    MyGame.UIFormId[] array = obj as MyGame.UIFormId[];
				translator.PushMyGameUIFormId(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.PacketType[]))
			{
			    MyGame.PacketType[] array = obj as MyGame.PacketType[];
				translator.PushMyGamePacketType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.HandlerType[]))
			{
			    MyGame.HandlerType[] array = obj as MyGame.HandlerType[];
				translator.PushMyGameHandlerType(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.CardState[]))
			{
			    MyGame.CardState[] array = obj as MyGame.CardState[];
				translator.PushMyGameCardState(L, array[index]);
				return true;
			}
			else if (type == typeof(MyGame.CommandMode[]))
			{
			    MyGame.CommandMode[] array = obj as MyGame.CommandMode[];
				translator.PushMyGameCommandMode(L, array[index]);
				return true;
			}
            return false;
		}
		
		internal static bool __tryArraySet(Type type, RealStatePtr L, ObjectTranslator translator, object obj, int array_idx, int obj_idx)
		{
		
			if (type == typeof(UnityEngine.Vector2[]))
			{
			    UnityEngine.Vector2[] array = obj as UnityEngine.Vector2[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector3[]))
			{
			    UnityEngine.Vector3[] array = obj as UnityEngine.Vector3[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Vector4[]))
			{
			    UnityEngine.Vector4[] array = obj as UnityEngine.Vector4[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Color[]))
			{
			    UnityEngine.Color[] array = obj as UnityEngine.Color[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Quaternion[]))
			{
			    UnityEngine.Quaternion[] array = obj as UnityEngine.Quaternion[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray[]))
			{
			    UnityEngine.Ray[] array = obj as UnityEngine.Ray[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Bounds[]))
			{
			    UnityEngine.Bounds[] array = obj as UnityEngine.Bounds[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(UnityEngine.Ray2D[]))
			{
			    UnityEngine.Ray2D[] array = obj as UnityEngine.Ray2D[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.AutoPlay[]))
			{
			    DG.Tweening.AutoPlay[] array = obj as DG.Tweening.AutoPlay[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.AxisConstraint[]))
			{
			    DG.Tweening.AxisConstraint[] array = obj as DG.Tweening.AxisConstraint[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.Ease[]))
			{
			    DG.Tweening.Ease[] array = obj as DG.Tweening.Ease[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.LogBehaviour[]))
			{
			    DG.Tweening.LogBehaviour[] array = obj as DG.Tweening.LogBehaviour[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.LoopType[]))
			{
			    DG.Tweening.LoopType[] array = obj as DG.Tweening.LoopType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.PathMode[]))
			{
			    DG.Tweening.PathMode[] array = obj as DG.Tweening.PathMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.PathType[]))
			{
			    DG.Tweening.PathType[] array = obj as DG.Tweening.PathType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.RotateMode[]))
			{
			    DG.Tweening.RotateMode[] array = obj as DG.Tweening.RotateMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.ScrambleMode[]))
			{
			    DG.Tweening.ScrambleMode[] array = obj as DG.Tweening.ScrambleMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.TweenType[]))
			{
			    DG.Tweening.TweenType[] array = obj as DG.Tweening.TweenType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(DG.Tweening.UpdateType[]))
			{
			    DG.Tweening.UpdateType[] array = obj as DG.Tweening.UpdateType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.PlayMode[]))
			{
			    MyGame.PlayMode[] array = obj as MyGame.PlayMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.GameState[]))
			{
			    MyGame.GameState[] array = obj as MyGame.GameState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.CardGroupType[]))
			{
			    MyGame.CardGroupType[] array = obj as MyGame.CardGroupType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.SuitType[]))
			{
			    MyGame.SuitType[] array = obj as MyGame.SuitType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.CardLevel[]))
			{
			    MyGame.CardLevel[] array = obj as MyGame.CardLevel[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.CardType[]))
			{
			    MyGame.CardType[] array = obj as MyGame.CardType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.UIFormId[]))
			{
			    MyGame.UIFormId[] array = obj as MyGame.UIFormId[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.PacketType[]))
			{
			    MyGame.PacketType[] array = obj as MyGame.PacketType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.HandlerType[]))
			{
			    MyGame.HandlerType[] array = obj as MyGame.HandlerType[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.CardState[]))
			{
			    MyGame.CardState[] array = obj as MyGame.CardState[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
			else if (type == typeof(MyGame.CommandMode[]))
			{
			    MyGame.CommandMode[] array = obj as MyGame.CommandMode[];
				translator.Get(L, obj_idx, out array[array_idx]);
				return true;
			}
            return false;
		}
	}
}