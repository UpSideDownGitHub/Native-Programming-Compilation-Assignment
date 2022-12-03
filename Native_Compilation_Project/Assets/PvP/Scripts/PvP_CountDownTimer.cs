using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PvP_CountDownTimer : MonoBehaviour
{
    public float totalTime = 5 * 60;
    public TMP_Text timerText;

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(totalTime / 60);
        float seconds = Mathf.FloorToInt(totalTime % 60);
        float milliSeconds = (totalTime % 1) * 1000;
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
