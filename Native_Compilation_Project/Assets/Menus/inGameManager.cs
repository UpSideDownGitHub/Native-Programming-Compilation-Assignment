using System.Collections;
using System.Collections.Generic;
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

    [Header("Scripts")]
    public PauseMenu pauseMenu;

    public void Update()
    {
        if (pauseButton.action.WasPressedThisFrame() && scoreUI.activeInHierarchy)
        {
            scoreUI.SetActive(false);
            pauseUI.SetActive(true);
            pauseMenu.enabled = true;
        }
    }

    public void closePauseMenu()
    {
        scoreUI.SetActive(true);
        pauseUI.SetActive(false);
        pauseMenu.enabled = false;
    }
}
