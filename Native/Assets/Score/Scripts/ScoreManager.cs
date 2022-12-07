
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;

    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MANAGER").GetComponent<GameManager>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void changeScore(int ammount)
    {
        score += ammount;
        scoreText.text = "Score: " + score.ToString();
        gameManager.score = score;
    }
}
