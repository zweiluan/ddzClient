using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameFramework.Runtime;

namespace MyGame.Launch
{
    
    public class ChangeSceneLoadResourceAgentHelper : DefaultLoadResourceAgentHelper
    {
        public override void LoadAsset(object resource, string assetName, Type assetType, bool isScene)
        {
            AssetBundle assetBundle = resource as AssetBundle;
            if ((!isScene)||assetBundle==null||string.IsNullOrEmpty(assetName))
            {
                //使用基类的错误判断和加载逻辑
                base.LoadAsset(resource,assetName,assetType,false);
                return;
            }
            int sceneNamePositionStart = assetName.LastIndexOf('/');
            int sceneNamePositionEnd = assetName.LastIndexOf('.');
            if (sceneNamePositionStart <= 0 || sceneNamePositionEnd <= 0 ||
                sceneNamePositionStart > sceneNamePositionEnd)
            {
                //使用基类的错误判断
                base.LoadAsset(resource,assetName,assetType,false);
                return;
            }
            string sceneName = assetName.Substring(sceneNamePositionStart + 1, sceneNamePositionEnd - sceneNamePositionStart - 1);
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.None);
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
        
    }
}