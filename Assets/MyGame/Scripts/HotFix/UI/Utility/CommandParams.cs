using System;

namespace MyGame
{
    public class CommandParams
    {
        public int Mode
        {
            get;
            set;
        }

        public object UserData
        {
            get;
            set;
        }

        /// <summary>
        /// 部分回调需要传会参数
        /// </summary>
        public  Action<object> Action1
        {
            get;
            set;
        }

        
        public  Action<object> Action2
        {
            get;
            set;
        }
        public  Action<object> Action3
        {
            get;
            set;
        }
        // public void DoAction1()
        // {
        //     Action1?.Invoke();
        //
        // }
        // public void DoAction2()
        // {
        //     Action2?.Invoke();
        // }
        // public void DoAction3()
        // {
        //     Action3?.Invoke();
        // }
        
    }

    public enum CommandMode
    {
        single_begin=1,
        mult_begin=2,
        req_master=3,
        gen=4,
        chu=5,
        end=6,
    }
}