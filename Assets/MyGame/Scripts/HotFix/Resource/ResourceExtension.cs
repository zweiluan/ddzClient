using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework.Resource;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityGameFramework.Runtime;

namespace MyGame
{
    public static class ResourceExtension
    {
        private static string m_PackageVersionListPath=>Path.Combine(GameEntry.Resource.ReadOnlyPath,"GameFrameworkVersion.dat");
        private static string m_UpdatableVersionListPath => Path.Combine(GameEntry.Resource.ReadWritePath,"GameFrameworkVersion.dat");
            // "GameFrameworkList.dat");
        
        public static string[] GetAllAssetPaths(this ResourceComponent resourceComponent)
        {
#if UNITY_EDITOR
            if (GameEntry.Base.EditorResourceMode)
            {
                return AssetDatabase.GetAllAssetPaths();
            }
#endif
            if (GameEntry.Resource.ResourceMode==ResourceMode.Package)
            {
// #if UNITY_EDITOR_WIN
                    if (!File.Exists(m_PackageVersionListPath))
// #else
                    //安卓模式下也是在这里
                    // if (!File.Exists(m_UpdatableVersionListPath))
// #endif
                    {
                        Debug.Log($"初始化错误{m_PackageVersionListPath}无效");
                        return null;
                    }
                    var assets= GameEntry.Resource.PackageVersionListSerializer.Deserialize(File.Open(m_PackageVersionListPath,
                        FileMode.Open)).GetAssets();
                    if (assets!=null)
                    {
                        List<string> names=new List<string>();
                        foreach (var asset in assets)
                        {
                            names.Add(asset.Name);
                        }
                        return names.ToArray();
                    }
                    return null;
                }

                if (GameEntry.Resource.ResourceMode==ResourceMode.Updatable)
                {
                    if (!File.Exists(m_UpdatableVersionListPath))
                    {
                        Debug.Log($"初始化错误{m_UpdatableVersionListPath}无效");
                        return null;
                    }
                    var assets= GameEntry.Resource.UpdatableVersionListSerializer.Deserialize(File.Open(m_UpdatableVersionListPath,
                        FileMode.Open)).GetAssets();
                    if (assets!=null)
                    {
                        List<string> names=new List<string>();
                        foreach (var asset in assets)
                        {
                            names.Add(asset.Name);
                        }

                        return names.ToArray();
                    }

                    return null;
                }

                return null;
        }
        public static void AllAssetPathsForEach(this ResourceComponent resourceComponent,Action<string> action)
        {
#if UNITY_EDITOR
            if (GameEntry.Base.EditorResourceMode)
            {
                foreach (var asset in AssetDatabase.GetAllAssetPaths())
                {
                    action(asset);
                }
            }
#endif
            if (GameEntry.Resource.ResourceMode==ResourceMode.Package)
            {
                resourceComponent.StartCoroutine(ARequest(m_PackageVersionListPath, (_) =>
                {
                    var assets= GameEntry.Resource.PackageVersionListSerializer.Deserialize(_).GetAssets();
                    if (assets!=null)
                    {
                        foreach (var asset in assets)
                        {
                            action(asset.Name);
                        }
                    }
                })) ;
            }

            if (GameEntry.Resource.ResourceMode==ResourceMode.Updatable)
            {


                var stream = File.Open(m_UpdatableVersionListPath, FileMode.Open);
                var assets = GameEntry.Resource.UpdatableVersionListSerializer.Deserialize(stream).GetAssets();
                if (assets != null)
                {
                    foreach (var asset in assets)
                    {
                        action(asset.Name);
                    }
                }
                // resourceComponent.StartCoroutine(ARequest(m_UpdatableVersionListPath, (_) =>
                // {
                //     var assets = GameEntry.Resource.UpdatableVersionListSerializer.Deserialize(_).GetAssets();
                //     if (assets != null)
                //     {
                //         foreach (var asset in assets)
                //         {
                //             action(asset.Name);
                //         }
                //     }
                // }));
            }
        }

        static void aa()
        {
            
        }
        static IEnumerator ARequest(string url,Action<Stream> action)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                
                yield return webRequest.SendWebRequest();
                Log.Info(url);
                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        action(new MemoryStream(webRequest.downloadHandler.data,false));
                        // Debug.Log( ":\nReceived: " + stream.Length);
                        break;
                }
            
            }
        }
    }
}