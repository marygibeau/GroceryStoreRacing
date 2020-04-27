using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public int numberOfItemsNeeded;
    public FinalScoreHandler finalScoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numberOfItemsNeeded = 5;
        scoreText.text = "Items: " + score + "/" + numberOfItemsNeeded;
        finalScoreHandler = (FinalScoreHandler)GameObject.FindObjectOfType(typeof(FinalScoreHandler));
    }

    public void IncreaseScore()
    {
        score++;
        if (score == numberOfItemsNeeded)
        {
            finalScoreHandler.GenerateFinalScore();
        }
        scoreText.text = "Items: " + score + "/" + numberOfItemsNeeded;
    }
}
