using System.Collections.Generic;

namespace XLua
{
    public struct GCAction
    {
        public int Reference;
        public bool IsDelegate;
    }
    public enum LuaTypes
    {
        LUA_TNONE = -1,
        LUA_TNIL = 0,
        LUA_TNUMBER = 3,
        LUA_TSTRING = 4,
        LUA_TBOOLEAN = 1,
        LUA_TTABLE = 5,
        LUA_TFUNCTION = 6,
        LUA_TUSERDATA = 7,
        LUA_TTHREAD = 8,
        LUA_TLIGHTUSERDATA = 2
    }

    public enum LuaGCOptions
    {
        LUA_GCSTOP = 0,
        LUA_GCRESTART = 1,
        LUA_GCCOLLECT = 2,
        LUA_GCCOUNT = 3,
        LUA_GCCOUNTB = 4,
        LUA_GCSTEP = 5,
        LUA_GCSETPAUSE = 6,
        LUA_GCSETSTEPMUL = 7,
    }

    public enum LuaThreadStatus
    {
        LUA_RESUME_ERROR = -1,
        LUA_OK = 0,
        LUA_YIELD = 1,
        LUA_ERRRUN = 2,
        LUA_ERRSYNTAX = 3,
        LUA_ERRMEM = 4,
        LUA_ERRERR = 5,
    }

    public sealed class LuaIndexes
    {
        public static int LUA_REGISTRYINDEX
        {
            get
            {
                return InternalGlobals.LUA_REGISTRYINDEX;
            }
            set
            {
                InternalGlobals.LUA_REGISTRYINDEX = value;
            }
        }
    }
    public partial class InternalGlobals
    {
#if !THREAD_SAFE && !HOTFIX_ENABLE
        public static byte[] strBuff = new byte[256];
#endif
        public  static volatile int LUA_REGISTRYINDEX = -10000;
        public static volatile Dictionary<string, string> supportOp = new Dictionary<string, string>()
        {
            { "op_Addition", "__add" },
            { "op_Subtraction", "__sub" },
            { "op_Multiply", "__mul" },
            { "op_Division", "__div" },
            { "op_Equality", "__eq" },
            { "op_UnaryNegation", "__unm" },
            { "op_LessThan", "__lt" },
            { "op_LessThanOrEqual", "__le" },
            { "op_Modulus", "__mod" },
            { "op_BitwiseAnd", "__band" },
            { "op_BitwiseOr", "__bor" },
            { "op_ExclusiveOr", "__bxor" },
            { "op_OnesComplement", "__bnot" },
            { "op_LeftShift", "__shl" },
            { "op_RightShift", "__shr" },
        };
    }
}