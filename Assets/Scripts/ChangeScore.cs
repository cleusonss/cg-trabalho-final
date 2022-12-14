using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeScore : MonoBehaviour {

    
    public GameObject Score;
    public GameObject GameOverMsg;
    public GameObject FinalScore;

    int scoreValue = 0;
    bool gameOver;

    //componentes de texto
    TextMeshProUGUI score_text;
    TextMeshProUGUI gameOverMsg_text;
    TextMeshProUGUI finalScore_text;

    void Start() {
        gameOver = false;
        score_text = Score.GetComponent<TextMeshProUGUI>();
        gameOverMsg_text = GameOverMsg.GetComponent<TextMeshProUGUI>();
        finalScore_text = FinalScore.GetComponent<TextMeshProUGUI>();
        gameOverMsg_text.enabled = false;
        finalScore_text.enabled = false;
    }

    void Update() {
        if (!gameOver)
        {
            score_text.text = "Score:" + scoreValue.ToString();
        }
    }

    public int GetScore() {
        return this.scoreValue;
    }

    public void SetScore(int scoreValue) {
        this.scoreValue = scoreValue;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void Defeated()
    {
        gameOver = true;
        score_text.enabled = false;
        gameOverMsg_text.text = "Game Over";
        finalScore_text.text = "Score:" + scoreValue.ToString();
        gameOverMsg_text.enabled = true;
        finalScore_text.enabled = true;
    }
    //1370 ou mais
    public void Victory()
    {
        gameOver = true;
        score_text.enabled = false;
        gameOverMsg_text.text = "Parabens";
        finalScore_text.text = "Score:" + scoreValue.ToString();
        gameOverMsg_text.enabled = true;
        finalScore_text.enabled = true;
    }
}
