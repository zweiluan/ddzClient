namespace MyGame
{
    public partial class GameEntry
    {
        public static XluaComponent xLua
        {
            get;
            private set;
        }

        public static LubanComponent Luban
        {
            get;
            private set;
        }
        // public static RoomComponent Room
        // {
        //     get;
        //     private set;
        // }

        public static AgentComponent Agent
        {
            get;
            private set;
        }
        void CustomInit()
        {
            xLua = UnityGameFramework.Runtime.GameEntry.GetComponent<XluaComponent>();
            Luban= UnityGameFramework.Runtime.GameEntry.GetComponent<LubanComponent>();
            // Room=UnityGameFramework.Runtime.GameEntry.GetComponent<RoomComponent>();
            Agent=UnityGameFramework.Runtime.GameEntry.GetComponent<AgentComponent>();
        }
    }
}