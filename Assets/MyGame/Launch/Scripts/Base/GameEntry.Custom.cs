namespace MyGame.Launch
{
    public partial class GameEntry
    {
        public HotFixComponent Hotfix
        {
            get;
            private set;
        }
        void CustomInit()
        {
            Hotfix=UnityGameFramework.Runtime.GameEntry.GetComponent<HotFixComponent>();
        }
    }
}