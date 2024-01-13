using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    //Script which take scene name from inspector and have method to lauch that scene.Unload the current scene and load the new scene.
    public string sceneName;
    public void LaunchScene()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


}
