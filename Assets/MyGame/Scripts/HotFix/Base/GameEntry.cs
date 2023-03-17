using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace MyGame
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