using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using MyGame.Launch;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameFramework.Runtime;
using GameEntry = MyGame.Launch.GameEntry;

namespace MyGame.Lanuch
{


    public class ProcedureChangeScene : ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            //1、获得场景资源的索引
            ///2、关闭整个Gameframework框架
            /// 3、启动场景


            var ab= AssetBundle.LoadFromFile(Path.Combine(GameEntry.Resource.ReadOnlyPath, "scene.dat"));
            
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.None);
            SceneManager.LoadSceneAsync(AssetUtility.GetSceneAssetPath(GameEntry.Config.GetString("LaunchScene")),LoadSceneMode.Single);

            
            // GameEntry.Resource.LoadAsset(AssetUtility.GetSceneAssetPath("Main"),new LoadAssetCallbacks(SceneAssetLoadSuccessed));

            Log.Info("切换场景");
        }


    }
}