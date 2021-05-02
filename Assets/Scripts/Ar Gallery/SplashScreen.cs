using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(loadScene());
    }
    
    IEnumerator loadScene()
    {
        
        AsyncOperation scene = SceneManager.LoadSceneAsync("Menu Scene");
        scene.allowSceneActivation = false;

        while (!scene.isDone)
        {
            yield return new WaitForSeconds(3f);
            scene.allowSceneActivation = true;
        }
    }
}
