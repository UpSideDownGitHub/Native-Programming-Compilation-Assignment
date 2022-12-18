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

    [Header("Text Objects")]
    public TMP_Text kills;
    public TMP_Text shots;
    public TMP_Text accuracy;
    public TMP_Text death;
    public TMP_Text time;
    public TMP_Text score;

    public void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<GameManager>();
        ingamemanager.canPause = false;
        playerInput.SwitchCurrentActionMap("Menus_Map"); // default = Player_Map
        Time.timeScale = 0f;

        // initilse all of the UI componets of the end screen GUI
        kills.text = "Kills: " + gameManager.kills.ToString();
        shots.text = "shots: " + gameManager.shots.ToString();
        if (gameManager.shots == 0)
            accuracy.text = "accuracy: 100%";
        else
            accuracy.text = "accuracy: " + ((gameManager.kills / gameManager.shots) * 100).ToString() + "%";
        death.text = "deaths: " + gameManager.deaths.ToString();
        time.text = "time: " + (gameManager.finishTime - gameManager.startTime).ToString();
        score.text = "score: " + gameManager.score.ToString();
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
