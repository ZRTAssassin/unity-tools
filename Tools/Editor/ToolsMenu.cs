#if UNITY_EDITOR
using UnityEditor;



namespace ZRTAssassin
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDirectories("_Project", "Scripts", "Art", "Scenes");
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Setup/Load New Manifest")]
        public static async void LoadNewManifest()
        {
            await Packages.ReplacePackagesFromGist("47d2e57798c4f3d2df95317a9f986310");
        }

        [MenuItem("Tools/Setup/Packages/CineMachine")]
        static void AddCinemachine() => Packages.InstallUnityPackage("cinemachine");

        [MenuItem("Tools/Setup/Packages/New Input System")]
        static void AddNewInputSystem() => Packages.InstallUnityPackage("inputsystem");


        [MenuItem("Tools/Build Settings/Set Build Options for WebGL")]
        public static void SetWebGLBuildSettings()
        {
        }
    }
}
#endif