using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    
    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadAsynchronously(levelIndex));
    }

    IEnumerator LoadAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .2f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }

    }
    
}
