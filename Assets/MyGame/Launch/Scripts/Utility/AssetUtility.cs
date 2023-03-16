namespace MyGame.Launch
{
    public static class AssetUtility
    {
        public static string GetSceneAssetPath(string sceneName)
        {
            return $"Assets/MyGame/Scenes/{sceneName}.unity";
        }
        public static string GetConfigPath(string configName)
        {
            return $"Assets/MyGame/Configs/{configName}Config.txt";
        }
        public static string GetDllPath(string dllName)
        {
            return $"Assets/MyGame/DLL/{dllName}.dll.bytes";
        }
    }
}