using System;
using System.IO;
using System.Linq;
using OneLaneWar.Presentation;
using UnityEditor;
using UnityEditor.Android;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

namespace OneLaneWar.Editor
{
    public static class BuildTools
    {
        public static string Root { get { return Path.GetDirectoryName(Application.dataPath); } }
        [MenuItem("One Lane War/Prepare PH01 project")]
        public static void Prepare()
        {
            if (Application.unityVersion != "6000.3.21f1") throw new BuildFailedException("T001_EDITOR_MISMATCH");
            string source = Path.Combine(Root, "One_Lane_War_Codex_Source_v1.0.0");
            Content.Load(path => File.ReadAllBytes(Path.Combine(source, path)));
            string target = "Assets/OneLaneWar/Resources/Canonical"; Directory.CreateDirectory(target);
            foreach (string name in Content.RegistryNames.Concat(new[] { "SOURCE_MANIFEST" }))
            {
                string path = name == "SOURCE_MANIFEST" ? name + ".json" : "data/" + name + ".json";
                string destination = target + "/" + name + ".json";
                byte[] bytes = File.ReadAllBytes(Path.Combine(source, path));
                if (!File.Exists(destination) || !File.ReadAllBytes(destination).SequenceEqual(bytes)) File.WriteAllBytes(destination, bytes);
            }
            AssetDatabase.Refresh();
            Directory.CreateDirectory("Assets/Scenes");
            var bootstrap = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            new GameObject("Bootstrap").AddComponent<Bootstrap>(); EditorSceneManager.SaveScene(bootstrap, "Assets/Scenes/Bootstrap.unity");
            var battle = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var camera = new GameObject("Camera").AddComponent<Camera>(); camera.orthographic = true; camera.clearFlags = CameraClearFlags.SolidColor; camera.backgroundColor = new Color(0.055f, 0.095f, 0.13f);
            new GameObject("BattleHarness").AddComponent<BattleHarness>(); EditorSceneManager.SaveScene(battle, "Assets/Scenes/Battle.unity");
            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene("Assets/Scenes/Bootstrap.unity", true), new EditorBuildSettingsScene("Assets/Scenes/Battle.unity", true) };
            PlayerSettings.companyName = "One Lane War Development"; PlayerSettings.productName = "One Lane War PH01";
            PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.example.onelanewar.dev");
            PlayerSettings.SetScriptingBackend(NamedBuildTarget.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel28;
            PlayerSettings.Android.targetSdkVersion = (AndroidSdkVersions)36;
            PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.Android, false);
            PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { GraphicsDeviceType.OpenGLES3 });
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;
            PlayerSettings.allowedAutorotateToLandscapeLeft = PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToPortrait = PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
            PlayerSettings.defaultScreenWidth = 1920; PlayerSettings.defaultScreenHeight = 1080;
            PlayerSettings.runInBackground = false;
            PlayerSettings.Android.bundleVersionCode = 1; PlayerSettings.bundleVersion = "0.1.0";
            EditorUserBuildSettings.development = true;
            AssetDatabase.SaveAssets(); Debug.Log("OLW_PREPARE_OK source=" + Content.ManifestHash);
        }
        [MenuItem("One Lane War/Build PH01 Android")]
        public static void Android()
        {
            Directory.CreateDirectory("Builds/Android");
            string android = Path.Combine(EditorApplication.applicationContentsPath, "PlaybackEngines/AndroidPlayer");
            string previousJdk = AndroidExternalToolsSettings.jdkRootPath;
            bool previousEmbeddedJdk = EditorPrefs.GetBool("JdkUseEmbedded", true);
            try
            {
                // This host has a shared custom JDK preference. Use the selected
                // editor's actual bundled binary and restore that preference afterward.
                AndroidExternalToolsSettings.jdkRootPath = Path.Combine(android, "OpenJDK");
                Debug.Log("OLW_T001_JDK=" + AndroidExternalToolsSettings.jdkRootPath);
                if (Path.GetFullPath(AndroidExternalToolsSettings.sdkRootPath) != Path.GetFullPath(Path.Combine(android, "SDK")) ||
                    Path.GetFullPath(AndroidExternalToolsSettings.ndkRootPath) != Path.GetFullPath(Path.Combine(android, "NDK")))
                    throw new BuildFailedException("T001_SDK_NDK_PATH_MISMATCH");
                Build(new BuildPlayerOptions { scenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray(), target = BuildTarget.Android,
                    locationPathName = "Builds/Android/OneLaneWar-PH01.apk", options = BuildOptions.Development | BuildOptions.StrictMode });
            }
            finally { AndroidExternalToolsSettings.jdkRootPath = previousEmbeddedJdk ? string.Empty : previousJdk; }
        }
        public static void Desktop()
        {
            Directory.CreateDirectory("Builds/Desktop");
            Build(new BuildPlayerOptions { scenes = EditorBuildSettings.scenes.Select(x => x.path).ToArray(), target = BuildTarget.StandaloneWindows64,
                locationPathName = "Builds/Desktop/OneLaneWar-PH01.exe", options = BuildOptions.Development | BuildOptions.StrictMode });
        }
        static void Build(BuildPlayerOptions options)
        {
            var report = BuildPipeline.BuildPlayer(options);
            Debug.Log("OLW_BUILD_RESULT=" + report.summary.result + " bytes=" + report.summary.totalSize + " errors=" + report.summary.totalErrors);
            if (report.summary.result != BuildResult.Succeeded) throw new BuildFailedException(report.summary.result.ToString());
        }
    }
    public sealed class ContentBuildGate : IPreprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }
        public void OnPreprocessBuild(BuildReport report)
        {
            if ((report.summary.options & BuildOptions.Development) == 0) throw new BuildFailedException("PH01 developer harness cannot ship as release");
            ContentResources.Load();
            if (Application.unityVersion != "6000.3.21f1") throw new BuildFailedException("T001_EDITOR_MISMATCH");
        }
    }
}
