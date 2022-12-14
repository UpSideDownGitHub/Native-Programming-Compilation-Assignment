using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PvP_PauseMaster : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject GlobalUI;
    public GameObject PauseUI;

    private bool _once = true;

    [Header("Controller Disconnected")]
    public GameObject controllerDisconnected1;
    public GameObject controllerDisconnected2;
    private bool _once2 = true;
    private bool _once3 = true;
    private bool _once4 = false;
    void Update()
    {
        if (PvP_Movement.lostP1 && _once2)
        {
            _once4 = true;
            _once2 = false;
            Time.timeScale = 0f;
            controllerDisconnected1.SetActive(true);
        }
        else if (!PvP_Movement.lostP1 && !_once2)
        {
            _once2 = true;
            controllerDisconnected1.SetActive(false);
        }

        if (PvP_Movement.lostP2 && _once3)
        {
            _once4 = true;
            _once3 = false;
            Time.timeScale = 0f;
            controllerDisconnected2.SetActive(true);
        }
        else if (!PvP_Movement.lostP2 && !_once3)
        {
            _once3 = true;
            controllerDisconnected2.SetActive(false);
        }

        if (!PvP_Movement.lostP1 && !PvP_Movement.lostP2 && _once4)
        {
            _once4 = false;
            Time.timeScale = 1f;
        }

        if (PvP_Movement.paused && _once)
        {
            _once = false;
            P1UI.SetActive(false);
            P2UI.SetActive(false);
            GlobalUI.SetActive(false);
            PauseUI.SetActive(true);
        }
        
        if (!PvP_Movement.paused && !_once)
        {
            _once = true;
            P1UI.SetActive(true);
            P2UI.SetActive(true);
            GlobalUI.SetActive(true);
            PauseUI.SetActive(false);
        }
    }
}
