using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;

    public void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void changeScore(int ammount)
    {
        score += ammount;
        scoreText.text = "Score: " + score.ToString();
    }
}
