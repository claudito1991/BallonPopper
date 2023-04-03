using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI scoreValue;
    [SerializeField]
    int initialScore=0;
    int currentScore=0;

    [SerializeField]
    int scorePerBallon=1;

    [SerializeField] private ResetGame resetGame;
    // Start is called before the first frame update

    void Start()
    {
        initialScore = 0;
        scoreValue.text = "000";
        
        
    }
    void OnEnable()
    {
        BallonControler.BallonPoped += UpdateScore;
        resetGame.ResetTheGame += ResetScoreVal;
    }

    private void ResetScoreVal()
    {
        initialScore = 0;
        scoreValue.text = "000";
    }

    void OnDisable()
    {
        BallonControler.BallonPoped -= UpdateScore;
        resetGame.ResetTheGame -= ResetScoreVal;

    }

        private void UpdateScore()
    {
        currentScore += scorePerBallon;
        scoreValue.text = currentScore.ToString();
        
    }

}
