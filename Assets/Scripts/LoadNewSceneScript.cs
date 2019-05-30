using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewSceneScript : MonoBehaviour
{
    // Just a container for calling a new scene
    // more of a workaround tbh

    public void loadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
