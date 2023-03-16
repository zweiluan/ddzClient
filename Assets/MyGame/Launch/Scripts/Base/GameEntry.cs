using UnityEngine;
using UnityGameFramework.Runtime;

namespace MyGame.Launch
{
    public partial class GameEntry : GameFrameworkComponent
    {
        void Start()
        {
            BuildInInit();
            CustomInit();
            Application.runInBackground = true;
            Application.quitting += Quit;
        }

        static void Quit()
        {
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit);
        }
    }
}