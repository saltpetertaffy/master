using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(currentSceneIndex + 1);
    }

    public void DelayedLoadScene(int sceneIndex, float waitTime) {
        StartCoroutine(LoadAfterWait(sceneIndex, waitTime));
    }

    private IEnumerator LoadAfterWait(int sceneIndex, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        LoadScene(sceneIndex);
    }
}
