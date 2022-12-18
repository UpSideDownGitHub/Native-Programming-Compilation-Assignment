using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Floors")]
    public int currentSceneIndex;
    public int currentFloor;
    public int maxFloor;
    public bool stairsEnabled;

    [Header("Kills")]
    public int[] currentEnemies;

    [Header("End Screen")]
    public GameObject endScreen;
    public GameObject pauseMenu;
    public GameObject inGameUI;

    [Header("Values")]
    public int kills;
    public int shots;
    public int deaths;
    public int score;
    [Header("Time")]
    public float startTime;
    public float finishTime;

    private bool noSuicide;

    public void OnEnable()
    {
        DontDestroyOnLoad(this);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        startTime = Time.time;
        stairsEnabled = false;

        if (GameObject.FindGameObjectsWithTag("MANAGER").Length > 1 && !noSuicide)
            Destroy(gameObject);
        else
            noSuicide = true;

    }

    public void Update()
    {
        if (endScreen == null)
        {
            endScreen = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<inGameManager>().endUI;
            pauseMenu = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<inGameManager>().pauseUI;
            inGameUI = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<inGameManager>().scoreUI;
        }
        // Killed all of the enemies
        if (currentEnemies[currentFloor] <= 0)
        {
            stairsEnabled = true;
        }
    }

    public void stairs()
    {
        if (stairsEnabled)
        {
            // load the next scene if not the last scene if the last scene show the end screen;
            if (currentFloor < maxFloor)
            {
                currentFloor++;
                try
                {
                    SceneLoadingManager.instance.loadscene(currentFloor + currentSceneIndex);
                }
                catch
                {
                    print("Not Started From Main Menu");
                }
            }
            else
            {
                finishTime = Time.time;
                endScreen.SetActive(true);
                pauseMenu.SetActive(false);
                inGameUI.SetActive(false);
            }
        }
    }
}
