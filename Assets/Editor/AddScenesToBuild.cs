using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class AddScenesToBuild : EditorWindow
{
    // List of scenes to add
    static List<string> scenesToAdd = new List<string>
    {
        "Packages/com.ajinkya.projectone/Runtime/Scenes/GameScene.unity",
        "Packages/com.ajinkya.projecttwo/Runtime/Scenes/GameScene.unity",
        // Add more scenes here
    };

    [MenuItem("Kiddopia Menu/Add Scenes to Build")]
    static void AddScenes()
    {
        // Retrieve the current list of scenes in the Build Settings
        var originalScenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
        bool added = false;

        foreach (var scenePath in scenesToAdd)
        {
            if (!File.Exists(scenePath))
            {
                Debug.LogWarning("Scene file not found at path: " + scenePath);
                continue;
            }

            // Check if the scene is already in the build settings
            if (!originalScenes.Exists(scene => scene.path == scenePath))
            {
                // Scene not in build settings, add it
                originalScenes.Add(new EditorBuildSettingsScene(scenePath, true));
                added = true;
                Debug.Log("Added scene to Build Settings: " + scenePath);
            }
            else
            {
                Debug.Log("Scene already in Build Settings: " + scenePath);
            }
        }

        // Apply the changes to the Build Settings if any scene was added
        if (added)
        {
            EditorBuildSettings.scenes = originalScenes.ToArray();
        }
    }
}
