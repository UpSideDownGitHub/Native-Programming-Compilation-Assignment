using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class inGameManager : MonoBehaviour
{
    [Header("Input")]
    public PlayerInput playerInput;
    public InputActionReference pauseButton;

    [Header("UI's")]
    public GameObject scoreUI;
    public GameObject pauseUI;
    public GameObject endUI;

    [Header("Scripts")]
    public PauseMenu pauseMenu;

    [Header("Controller Disconnected")]
    public GameObject controllerDisconnectedUI;

    public bool canPause;

    public void OnEnable()
    {
        canPause = true;
    }



    public void Update()
    {
        if (pauseButton.action.WasPressedThisFrame() && scoreUI.activeInHierarchy)
        {
            if (canPause)
            {
                openPauseMenu();
            }
        }
    }
    public void controllerConnected()
    {
        Time.timeScale = 1f;
        canPause = true;
        controllerDisconnectedUI.SetActive(false);
    }
    public void controllerDisconnected()
    {
        Time.timeScale = 0f;
        canPause = false;
        controllerDisconnectedUI.SetActive(true);
    }

    public void openPauseMenu()
    {
        scoreUI.SetActive(false);
        pauseUI.SetActive(true);
        pauseMenu.enabled = true;
    }

    public void closePauseMenu()
    {
        scoreUI.SetActive(true);
        pauseUI.SetActive(false);
        pauseMenu.enabled = false;
    }
}
