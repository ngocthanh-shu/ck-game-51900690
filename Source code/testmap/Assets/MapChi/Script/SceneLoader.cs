using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    public GameObject Obj;
    public int level;

    public void LoadScene(int levelIndex){
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone){
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
    public void OnTriggerEnter2D(Collider2D other){
        Obj.SetActive(false);
    }
    public void OnTriggerExit2D(Collider2D other){
        if(level > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", level);
        }
        StartCoroutine(LoadSceneAsynchronously(level));
    }
}
