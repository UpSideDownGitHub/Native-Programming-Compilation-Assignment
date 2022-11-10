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

    [Header("Device Connections")]
    public InputDevice activeDevice = null;
    public GameObject controllerDisconnectedWarning;

    public bool canPause;

    public void OnEnable()
    {
        //activeDevice = null;
        activeDevice = Gamepad.current;
        //print(activeDevice);
        InputSystem.onDeviceChange += (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    //Debug.Log("New device added: " + device);
                    activeDevice = device;
                    break;

                case InputDeviceChange.Removed:
                    //Debug.Log("Device removed: " + device);
                    if (device == activeDevice)
                    {
                        if (canPause)
                        {
                            controllerDisconnectedWarning.SetActive(true);
                            openPauseMenu();
                        }
                    }
                    break;
            }
        };
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

    public void openPauseMenu()
    {
        scoreUI.SetActive(false);
        pauseUI.SetActive(true);
        pauseMenu.enabled = true;
    }

    public void closePauseMenu()
    {
        controllerDisconnectedWarning.SetActive(false);
        scoreUI.SetActive(true);
        pauseUI.SetActive(false);
        pauseMenu.enabled = false;
    }
}
