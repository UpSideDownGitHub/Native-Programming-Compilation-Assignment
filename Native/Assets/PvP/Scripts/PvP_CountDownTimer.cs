using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PvP_CountDownTimer : MonoBehaviour
{
    public float totalTime = 5 * 60;
    public TMP_Text timerText;

    [Header("Main Game Objects")]
    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject globalUI;
    public GameObject endScreen;
    private bool _roundEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (totalTime <= 0 && !_roundEnded) // the round has ended so show the end screen
        {
            Time.timeScale = 0;
            _roundEnded = true;
            P1UI.SetActive(false);
            P2UI.SetActive(false);
            globalUI.SetActive(false);
            endScreen.SetActive(true);

            return;
        }

        if (PvP_Movement.paused || PvP_Movement.lostP1 || PvP_Movement.lostP2)
            return;

        totalTime -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(totalTime / 60);
        float seconds = Mathf.FloorToInt(totalTime % 60);
        float milliSeconds = (totalTime % 1) * 1000;
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
