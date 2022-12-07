using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
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

    public void OnEnable()
    {
        // need to change the active map to the menus map and then also make the gamplay stop
        playerInput.SwitchCurrentActionMap("Menus_Map"); // default = Player_Map
        Time.timeScale = 0f;
    }

    public void Update()
    {
        if (Up.action.WasPressedThisFrame() && curSelected > 0)
            curSelected--;
        else if (Down.action.WasPressedThisFrame() && curSelected < 2)
            curSelected++;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void resumeButton()
    {
        playerInput.SwitchCurrentActionMap("Player_Map");
        GetComponent<inGameManager>().closePauseMenu();
        Time.timeScale = 1f;
    }
    public void menuButton()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("MANAGER").GetComponent<GameManager>().gameObject);
        SceneManager.LoadScene(0);
    }
    public void exitButton()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
