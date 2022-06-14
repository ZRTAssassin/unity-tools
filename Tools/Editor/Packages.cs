#if UNITY_EDITOR


using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace ZRTAssassin
{
    public static class Packages
    {
        public static async Task ReplacePackagesFromGist(string id, string user = "ZRTAssassin")
        {
            var url = Packages.GetGistUrl(id, user);
            var contents = await Packages.GetContents(url);
            Packages.ReplacePackageFile(contents);
        }
        
        public static string GetGistUrl(string id, string user = "ZRTAssassin") => 
            $"https://gist.github.com/{user}/{id}/raw";

        public static async Task<string> GetContents(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        public static void ReplacePackageFile(string contents)
        {
            var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName)
        {
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }
    }
}
#endif