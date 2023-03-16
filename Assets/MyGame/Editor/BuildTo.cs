using System.IO;
using HybridCLR.Editor;
using HybridCLR.Editor.Commands;
using MyGame.Lanuch;
using UnityEditor;
using UnityEngine;

namespace MyGame.Editor
{

    public class BuildTo
    {
        #region 编译Dll
        [MenuItem("Tools/MyGame/Build/CompileDllAndCopyToEditorAssets")]
        public static void BuildAndMoveDll()
        {
            BuildTarget target = EditorUserBuildSettings.activeBuildTarget;
            //编译dll
            CompileDllCommand.CompileDll(target);
            //将dll转移到对应的目录中
            CopyHotUpdateDlls(target);
            //打开游戏看看效果
            // UnityGameFramework.Editor.OpenFolder.Execute(
            //     EditorUserBuildSettings.GetBuildLocation(EditorUserBuildSettings.activeBuildTarget));

        }

        static void CopyHotUpdateDlls(BuildTarget target)
        {
            // CopyHotUpdateAssembliesToStreamingAssets();
            // CopyAOTAssembliesToStreamingAssets();
            CopyHotUpdateAssembliesToEditorAssets();
            CopyAOTAssembliesToEditorAssets();

        }

        public static string OutputstreamingAssetsPath
        {
            get
            {
                return Path.Combine(
                    Path.GetDirectoryName(
                        EditorUserBuildSettings.GetBuildLocation(EditorUserBuildSettings.activeBuildTarget))
                    , "project_A_Data/StreamingAssets"
                );
            }
        }

        public static string LocalAssetEditorPath => Path.Combine(Application.dataPath, "MyGame/DLL");

        public static void CopyHotUpdateAssembliesToStreamingAssets()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;
            string hotfixDllSrcDir = SettingsUtil.GetHotUpdateDllsOutputDirByTarget(target);
            string hotfixAssembliesDstDir = OutputstreamingAssetsPath;
            foreach (var dll in ProcedureLoadDLL.s_HotfixAssemblyName)
            {
                string dllPath = $"{hotfixDllSrcDir}/{dll}.dll";
                string dllBytesPath = $"{hotfixAssembliesDstDir}/{dll}.dll.byte";
                File.Copy(dllPath, dllBytesPath, true);
                Debug.Log($"[CopyHotUpdateAssembliesToStreamingAssets] copy hotfix dll {dllPath} -> {dllBytesPath}");
            }
        }

        public static void CopyHotUpdateAssembliesToEditorAssets()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;
            string hotfixDllSrcDir = SettingsUtil.GetHotUpdateDllsOutputDirByTarget(target);
            string hotfixAssembliesDstDir = LocalAssetEditorPath;
            foreach (var dll in ProcedureLoadDLL.s_HotfixAssemblyName)
            {
                string dllPath = $"{hotfixDllSrcDir}/{dll}.dll";
                string dllBytesPath = $"{hotfixAssembliesDstDir}/{dll}.dll.bytes";
                File.Copy(dllPath, dllBytesPath, true);
                Debug.Log($"[CopyHotUpdateAssembliesToEditorAssets] copy hotfix dll {dllPath} -> {dllBytesPath}");
            }
        }

        public static void CopyAOTAssembliesToStreamingAssets()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;

            string aotAssembliesSrcDir = SettingsUtil.GetAssembliesPostIl2CppStripDir(target);
            string aotAssembliesDstDir = OutputstreamingAssetsPath;

            foreach (var dll in ProcedureLoadDLL.s_AotDllList)
            {
                string srcDllPath = $"{aotAssembliesSrcDir}/{dll}.dll";
                if (!File.Exists(srcDllPath))
                {
                    Debug.LogError(
                        $"ab中添加AOT补充元数据dll:{srcDllPath} 时发生错误,文件不存在。裁剪后的AOT dll在BuildPlayer时才能生成，因此需要你先构建一次游戏App后再打包。");
                    continue;
                }

                string dllBytesPath = $"{aotAssembliesDstDir}/{dll}.dll";
                File.Copy(srcDllPath, dllBytesPath, true);
                Debug.Log($"[CopyAOTAssembliesToStreamingAssets] copy AOT dll {srcDllPath} -> {dllBytesPath}");
            }
        }

        public static void CopyAOTAssembliesToEditorAssets()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;

            string aotAssembliesSrcDir = SettingsUtil.GetAssembliesPostIl2CppStripDir(target);
            string aotAssembliesDstDir = LocalAssetEditorPath;

            foreach (var dll in ProcedureLoadDLL.s_AotDllList)
            {
                string srcDllPath = $"{aotAssembliesSrcDir}/{dll}.dll";
                if (!File.Exists(srcDllPath))
                {
                    Debug.LogError(
                        $"ab中添加AOT补充元数据dll:{srcDllPath} 时发生错误,文件不存在。裁剪后的AOT dll在BuildPlayer时才能生成，因此需要你先构建一次游戏App后再打包。");
                    continue;
                }

                string dllBytesPath = $"{aotAssembliesDstDir}/{dll}.dll.bytes";
                File.Copy(srcDllPath, dllBytesPath, true);
                Debug.Log($"[CopyAOTAssembliesToEditorAssets] copy AOT dll {srcDllPath} -> {dllBytesPath}");
            }
        }


        #endregion

        #region 打包为ab



        #endregion

        #region 输出索引



        #endregion

        #region 整理为可用的文件夹格式



        #endregion
    }
}