using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadingManager : MonoBehaviour
{
    // singleton
    public static SceneLoadingManager instance;

    // variables
    public GameObject loadingScreen;
    public Slider slider;


    void Awake()
    {
        // create the singletone if there is not already one (if there is already one commit suicide)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(loadingScreen);
        }
        else
            Destroy(gameObject);
    }

    // method to load scenes
    public void loadscene(int scene)
    {
        StartCoroutine(loadSceneAsync(scene));
    }

    IEnumerator loadSceneAsync(int ID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(ID);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progression = Mathf.Clamp01(operation.progress);
            slider.value = progression;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
