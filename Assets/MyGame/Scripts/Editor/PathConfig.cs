using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

public static class PathConfig 
{
    [BuildSettingsConfigPath]
    public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "MyGame/Configs/BuildSettings.xml"));

    [ResourceCollectionConfigPath]
    public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "MyGame/Configs/ResourceCollection.xml"));

    [ResourceEditorConfigPath]
    public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Mygame/Configs/ResourceEditor.xml"));

    [ResourceBuilderConfigPath]
    public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "Mygame/Configs/ResourceBuilder.xml"));
}
