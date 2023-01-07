using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class EndScreen : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference Up;
    public InputActionReference Down;
    public InputActionReference Left;
    public InputActionReference Right;
    public InputActionReference A;
    public InputActionReference B;

    [Header("Menu Navigation")]
    public int curSelected = 0;
    public GameObject[] buttons;

    [Header("Managers")]
    public inGameManager ingamemanager;
    public GameManager gameManager;

    [Header("###########################")]
    [Header("Text Objects")]
    public TMP_Text kills;
    public TMP_Text shots;
    public TMP_Text accuracy;
    public TMP_Text death;
    public TMP_Text time;
    public TMP_Text score;

    [Header("Best's")]
    public TMP_Text bestDeaths;
    public TMP_Text bestScore;
    public TMP_Text bestTime;

    [Header("New Best Messages")]
    public GameObject deathsNewBest;
    public GameObject scoreNewBest;
    public GameObject timeNewBest;

    public void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<GameManager>();
        ingamemanager.canPause = false;
        playerInput.SwitchCurrentActionMap("Menus_Map"); // default = Player_Map
        Time.timeScale = 0f;

        // initilse all of the UI componets of the end screen GUI
        kills.text = gameManager.kills.ToString();
        shots.text = gameManager.shots.ToString();
        if (gameManager.shots == 0 || gameManager.kills == 0)
            accuracy.text = "0%";
        else
            accuracy.text = ((float)((float)gameManager.kills / (float)gameManager.shots) * 100f).ToString() + "%";
        death.text = gameManager.deaths.ToString();
        time.text = (gameManager.finishTime - gameManager.startTime).ToString();
        score.text = gameManager.score.ToString();

        int savedLowestDeaths = PlayerPrefs.GetInt("LowestDeaths" + gameManager.currentSceneIndex, int.MaxValue);
        if (savedLowestDeaths == int.MaxValue)
        {
            PlayerPrefs.SetInt("LowestDeaths" + gameManager.currentSceneIndex, -1);
            savedLowestDeaths = PlayerPrefs.GetInt("LowestDeaths" + gameManager.currentSceneIndex, 0);
        }
        if (savedLowestDeaths < 0)
            bestDeaths.text = "N/A";
        else
            bestDeaths.text = savedLowestDeaths.ToString();

        int savedHighestScore = PlayerPrefs.GetInt("HighestScore" + gameManager.currentSceneIndex, int.MaxValue);
        if (savedHighestScore == int.MaxValue)
        {
            PlayerPrefs.SetInt("HighestScore" + gameManager.currentSceneIndex, -1);
            savedHighestScore = PlayerPrefs.GetInt("HighestScore" + gameManager.currentSceneIndex, 0);
        }
        if (savedHighestScore < 0)
            bestScore.text = "N/A";
        else
            bestScore.text = savedHighestScore.ToString();

        float savedFastestTime = PlayerPrefs.GetFloat("FastestTime" + gameManager.currentSceneIndex, float.MaxValue);
        if (savedFastestTime == float.MaxValue)
        {
            PlayerPrefs.SetFloat("FastestTime" + gameManager.currentSceneIndex, -1);
            savedFastestTime = PlayerPrefs.GetFloat("FastestTime" + gameManager.currentSceneIndex, 0);
        }
        if (savedFastestTime <= 0)
            bestTime.text = "N/A";
        else
            bestTime.text = savedFastestTime.ToString();


        if (gameManager.deaths < savedLowestDeaths || savedLowestDeaths < 0)
        {
            PlayerPrefs.SetInt("LowestDeaths" + gameManager.currentSceneIndex, gameManager.deaths);
            deathsNewBest.SetActive(true);
        }
        if (gameManager.score > savedHighestScore)
        {
            PlayerPrefs.SetInt("HighestScore" + gameManager.currentSceneIndex, gameManager.score);
            scoreNewBest.SetActive(true);
        }
        if ((gameManager.finishTime - gameManager.startTime) < savedFastestTime || savedFastestTime <= 0)
        {
            PlayerPrefs.SetFloat("FastestTime" + gameManager.currentSceneIndex, (gameManager.finishTime - gameManager.startTime));
            timeNewBest.SetActive(true);
        }
    }

    public void Update()
    {
        if (Left.action.WasPressedThisFrame() && curSelected > 0)
            curSelected--;
        else if (Right.action.WasPressedThisFrame() && curSelected < 2)
            curSelected++;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void replayButton()
    {
        playerInput.SwitchCurrentActionMap("Player_Map");
        try
        {
            SceneLoadingManager.instance.loadscene(gameManager.currentSceneIndex);
        }
        catch
        {
            print("Not Started From Main Menu");
        }
        Time.timeScale = 1f;
        Destroy(gameManager.gameObject);
    }
    public void menuButton()
    {
        Time.timeScale = 1f;
        try
        {
            SceneLoadingManager.instance.loadscene(0);
        }
        catch
        {
            print("Not Started From Main Menu");
        }
        Destroy(gameManager.gameObject);
    }
    public void nextButton()
    {
        Time.timeScale = 1f;
        try
        {
            SceneLoadingManager.instance.loadscene(gameManager.currentFloor + gameManager.currentSceneIndex + 1);
        }
        catch
        {
            print("Not Started From Main Menu");
        }
        Destroy(gameManager.gameObject);
    }

}
