using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

#if UNITY_EDITOR
public class SaveAssetBundles : EditorWindow
{
    [MenuItem("Window/Save AssetBundles")]

    public static void Open()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        AssetDatabase.Refresh();
    }
}
#endif