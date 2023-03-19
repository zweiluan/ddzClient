using System;
using HybridCLR;
using XLua;

namespace MyGame
{
    delegate int LuaFunction(IntPtr luaState);
    public class MonoPInvokeWrapperPreserves
    {
        [ReversePInvokeWrapperGeneration(2000)]
        [MonoPInvokeCallback(typeof(LuaFunction))]
        public static int LuaCallback(IntPtr luaState)
        {
            return 0;
        }

        [ReversePInvokeWrapperGeneration(100)]
        [MonoPInvokeCallback(typeof(Func<int, int, int>))]
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        [ReversePInvokeWrapperGeneration(100)]
        [MonoPInvokeCallback(typeof(Func<int, int, int>))]
        public static int Sum2(int a, int b)
        {
            return a + b;
        }
        [ReversePInvokeWrapperGeneration(100)]
        [MonoPInvokeCallback(typeof(Func<int, int>))]
        public static int Inc(int a)
        {
            return a + 1;
        }
    }
}