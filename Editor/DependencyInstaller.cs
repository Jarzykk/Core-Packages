using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace TestCore.Editor
{
    [InitializeOnLoad]
    public static class DependencyInstaller
    {
        private static readonly Dictionary<string, string> RequiredDependencies = new Dictionary<string, string>
        {
            { "com.cysharp.unitask", "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask" },
            { "com.svermeulen.extenject", "https://github.com/Mathijs-Bakker/Extenject.git?path=UnityProject/Assets/Plugins/Zenject/Source" },
            { "com.unity.nuget.newtonsoft-json", "3.2.1" },
            { "com.google.firebase.analytics", "12.10.1" },
            { "com.google.firebase.app", "12.10.1" },
            { "com.google.firebase.crashlytics", "12.10.1" },
            { "com.google.firebase.remote-config", "12.10.1" },
            { "com.unity.addressables", "2.7.3" }
        };

        private const string INSTALLED_FLAG_KEY = "TestCore.DependenciesInstalled";

        static DependencyInstaller()
        {
            // Check if we've already installed dependencies in this session
            if (SessionState.GetBool(INSTALLED_FLAG_KEY, false))
            {
                return;
            }

            // Delay execution to ensure Unity is fully initialized
            EditorApplication.delayCall += CheckAndInstallDependencies;
        }

        private static void CheckAndInstallDependencies()
        {
            var manifestPath = Path.Combine(Application.dataPath, "..", "Packages", "manifest.json");
            
            if (!File.Exists(manifestPath))
            {
                Debug.LogError("[TestCore] Could not find manifest.json at: " + manifestPath);
                return;
            }

            try
            {
                var manifestContent = File.ReadAllText(manifestPath);
                
                bool modified = false;
                List<string> addedDependencies = new List<string>();

                foreach (var dependency in RequiredDependencies)
                {
                    // Check if dependency already exists using simple string search
                    string searchPattern = $"\"{dependency.Key}\"";
                    if (!manifestContent.Contains(searchPattern))
                    {
                        addedDependencies.Add(dependency.Key);
                        modified = true;
                    }
                }

                if (modified)
                {
                    // Find the dependencies section
                    var dependenciesMatch = Regex.Match(manifestContent, @"""dependencies""\s*:\s*\{([^}]*)\}", RegexOptions.Singleline);
                    
                    if (!dependenciesMatch.Success)
                    {
                        Debug.LogError("[TestCore] Could not find dependencies section in manifest.json");
                        return;
                    }

                    string dependenciesContent = dependenciesMatch.Groups[1].Value;
                    string newDependencies = dependenciesContent;

                    // Add new dependencies
                    foreach (var dep in addedDependencies)
                    {
                        string value = RequiredDependencies[dep];
                        string newEntry = $",\n    \"{dep}\": \"{value}\"";
                        
                        // Add before the last entry or at the end
                        if (string.IsNullOrWhiteSpace(newDependencies.Trim()))
                        {
                            newDependencies = $"\n    \"{dep}\": \"{value}\"\n  ";
                        }
                        else
                        {
                            newDependencies = newDependencies.TrimEnd() + newEntry;
                        }
                    }

                    // Replace the old dependencies section with the new one
                    string updatedManifest = manifestContent.Replace(
                        dependenciesMatch.Groups[0].Value,
                        $"\"dependencies\": {{{newDependencies}\n  }}"
                    );

                    File.WriteAllText(manifestPath, updatedManifest);

                    Debug.Log($"[TestCore] Added {addedDependencies.Count} missing dependencies to manifest.json:");
                    foreach (var dep in addedDependencies)
                    {
                        Debug.Log($"  - {dep}: {RequiredDependencies[dep]}");
                    }
                    
                    Debug.Log("[TestCore] Unity will now reload packages. This may take a moment...");
                    
                    // Trigger package resolve
                    AssetDatabase.Refresh();
                }
                else
                {
                    Debug.Log("[TestCore] All required dependencies are already installed.");
                }

                // Mark as installed for this session
                SessionState.SetBool(INSTALLED_FLAG_KEY, true);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[TestCore] Failed to update manifest.json: {e.Message}");
            }
        }

        [MenuItem("Tools/TestCore/Install Dependencies")]
        public static void ManualInstallDependencies()
        {
            SessionState.SetBool(INSTALLED_FLAG_KEY, false);
            CheckAndInstallDependencies();
        }

        [MenuItem("Tools/TestCore/Check Dependencies")]
        public static void CheckDependencies()
        {
            var manifestPath = Path.Combine(Application.dataPath, "..", "Packages", "manifest.json");
            
            if (!File.Exists(manifestPath))
            {
                Debug.LogError("[TestCore] Could not find manifest.json");
                return;
            }

            try
            {
                var manifestContent = File.ReadAllText(manifestPath);

                List<string> installedDeps = new List<string>();
                List<string> missingDeps = new List<string>();

                foreach (var dependency in RequiredDependencies)
                {
                    string searchPattern = $"\"{dependency.Key}\"";
                    if (manifestContent.Contains(searchPattern))
                    {
                        installedDeps.Add(dependency.Key);
                    }
                    else
                    {
                        missingDeps.Add(dependency.Key);
                    }
                }

                Debug.Log($"[TestCore] Dependency Check Results:");
                Debug.Log($"  Installed: {installedDeps.Count}/{RequiredDependencies.Count}");
                
                if (installedDeps.Count > 0)
                {
                    Debug.Log("  Installed packages:");
                    foreach (var dep in installedDeps)
                    {
                        Debug.Log($"    ✓ {dep}");
                    }
                }

                if (missingDeps.Count > 0)
                {
                    Debug.LogWarning("  Missing packages:");
                    foreach (var dep in missingDeps)
                    {
                        Debug.LogWarning($"    ✗ {dep}");
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[TestCore] Failed to check dependencies: {e.Message}");
            }
        }
    }
}