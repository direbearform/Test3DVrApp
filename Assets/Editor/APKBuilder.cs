using UnityEngine;
using UnityEditor;
using System;

class APKBuilder
{
    static void build_with_key(String keyName)
    {
        try
        {
            string[] scenes = { "Assets/scenes/SampleScene.unity" };
            string pathToDeploy = "builds/test3dvrapp." + keyName + ".apk";
            PlayerSettings.Android.keystoreName = "TestKeyStores/testuser1.keystore";
            PlayerSettings.Android.keystorePass = "android";
            PlayerSettings.Android.keyaliasName = keyName;
            PlayerSettings.Android.keyaliasPass = "android";
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.Android, BuildOptions.None);
        }
        catch (Exception e)
        {
            Debug.Log("Exception during building: \n" + e.ToString());
        }
    }

    static void build()
    {
        build_with_key("test_key_1");
        build_with_key("test_key_2");
    }
}
