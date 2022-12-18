using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PvP_PauseManager : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference Up;
    public InputActionReference Down;

    [Header("Menu Navigation")]
    public int curSelected = 0;
    public GameObject[] buttons;

    public void OnEnable()
    {
        Time.timeScale = 0f;
        var playerInput = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
        playerInput.P1.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Menus_Map");
        playerInput.P2.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Menus_Map");
    }

    public void OnDisable()
    {
        Time.timeScale = 1f;
        var playerInput = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<PvP_PlayerManager>();
        playerInput.P1.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Player_Map");
        playerInput.P2.GetComponentInChildren<PlayerInput>().SwitchCurrentActionMap("Player_Map");
    }

    public void Update()
    {
        if (Up.action.WasPressedThisFrame() && curSelected > 0)
        {
            curSelected--;
        }
        else if (Down.action.WasPressedThisFrame() && curSelected < 2)
        {
            curSelected++;
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[curSelected]);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        PvP_Movement.paused = false;
    }

    public void menu()
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
    }
  
    public void exit()
    {
        Application.Quit();
    }
}
