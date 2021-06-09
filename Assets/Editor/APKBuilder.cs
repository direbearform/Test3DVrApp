using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

class APKBuilder
{
    static void BuildWithKey(String keyName, String appName, String apkName, List<String> customDefines)
    {
        try
        {
            string[] scenes = { "Assets/scenes/SampleScene.unity" };
            string pathToDeploy = "builds/" + apkName;
            PlayerSettings.Android.keystoreName = "TestKeyStores/testuser1.keystore";
            PlayerSettings.Android.keystorePass = "android";
            PlayerSettings.Android.keyaliasName = keyName;
            PlayerSettings.Android.keyaliasPass = "android";
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, appName);
            if (customDefines.Count > 0)
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, String.Join(",", customDefines));
            }
            BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.Android, BuildOptions.None);
        }
        catch (Exception e)
        {
            Debug.Log("Exception during building: \n" + e.ToString());
        }
        finally
        {
            // clean up and restore settings
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.test123.test3dvrapp");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
        }
    }

    static void Build()
    {
        BuildWithKey("test_key_1", "com.test123.test3dvrapp", "test3dvrapp.test_key_1.apk", new List<String>());
        // BuildWithKey("test_key_2", "com.test123.test3dvrapp", "test3dvrapp.test_key_2.apk", new List<String>());
        BuildWithKey("test_key_1", "com.test123.test3dvrapp", "test3dvrapp.test_key_1.demo.apk", new List<String>() { "IS_DEMO_BUILD" });
        BuildWithKey("test_key_1", "com.test123.test3dvrapp.demo", "test3dvrapp.test_key_1.demo.renamed.apk", new List<String>() { "IS_DEMO_BUILD" });
    }
}
