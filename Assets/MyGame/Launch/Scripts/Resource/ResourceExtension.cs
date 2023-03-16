using System.Collections.Generic;
using System.IO;
using GameFramework.Resource;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = MyGame.Launch.GameEntry;

namespace MyGame.Lanuch
{
    public static class ResourceExtension
    {
        private static string m_PackageVersionListPath=>Path.Combine(GameEntry.Resource.ReadOnlyPath,"GameFrameworkVersion.dat");
        private static string m_UpdatableVersionListPath => Path.Combine(GameEntry.Resource.ReadWritePath,"GameFrameworkVersion.dat");
        
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
                    if (!File.Exists(m_PackageVersionListPath))
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
    }
}