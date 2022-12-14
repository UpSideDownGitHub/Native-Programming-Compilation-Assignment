using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PvP_StartManager : MonoBehaviour
{
    [Header("Join Bools")]
    public bool p1Joined;
    public bool p2Joined;
    public bool p1Confirmed;
    public bool p2Confirmed;

    [Header("Canvas")]
    public GameObject playerJoinCanvas;
    public GameObject GlobalUI;
    public GameObject P1UI;
    public GameObject P2UI;

    [Header("Text")]
    public GameObject p1waitingText;
    public GameObject p1pressAnyButton;
    public GameObject p1join;
    public GameObject p1ready;
    public GameObject p1confirm;

    public GameObject p2waitingText;
    public GameObject p2pressAnyButton;
    public GameObject p2join;
    public GameObject p2ready;
    public GameObject p2confirm;


    public void OnEnable()
    {
        Time.timeScale = 0f;
    }
    

    public void p1JoinedGame()
    {
        p1Joined = true;
        p1waitingText.SetActive(false);
        p1pressAnyButton.SetActive(false);

        p1join.SetActive(true);
        p1ready.SetActive(true);
    }
    public void p1Ready()
    {
        p1join.SetActive(false);
        p1ready.SetActive(false);

        p1confirm.SetActive(true);
        p1Confirmed = true;
        checkForStart();
    }
    public void p2JoinedGame()
    {
        p2Joined = true;
        p2waitingText.SetActive(false);
        p2pressAnyButton.SetActive(false);

        p2join.SetActive(true);
        p2ready.SetActive(true);
    }
    public void p2Ready()
    {
        p2join.SetActive(false);
        p2ready.SetActive(false);

        p2confirm.SetActive(true);
        p2Confirmed = true;
        checkForStart();
    }

    public void checkForStart()
    {
        if (p2Confirmed && p1Confirmed)
        {
            // start the game
            playerJoinCanvas.SetActive(false);
            Time.timeScale = 1f;

            GlobalUI.SetActive(true);
            P1UI.SetActive(true);
            P2UI.SetActive(true);

            // set all of the UI elements to there initial values
            GameObject.FindGameObjectWithTag("PvP_UIManager").GetComponent<PvP_UIManager>().updateAllUI();
        }
    }
}
