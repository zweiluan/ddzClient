namespace MyGame
{
    public static class AssetUtility
    {
        public static string GetUIFormAssetPath(string name)
        {
            return $"Assets/MyGame/UI/UIForms/{name}UIForm.prefab";
        }

        public static string GetConfigAssetPath(string name)
        {
            return $"Assets/MyGame/Configs/{name}.txt";
        }

        public static string GetSuitAssetPath(string name)
        {
            return "";
        }
    }
}