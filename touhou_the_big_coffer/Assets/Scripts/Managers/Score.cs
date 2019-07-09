using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int basicScore;
    public int extraScore;
    public int score;
    public Text scoreText;
    public int test;
    public GameObject player;
    public float positionX;
    GameOver gameOver;

    void Start()
    {
        score = 0;
        basicScore = 0;
        extraScore = 0;
        test = 0;
        updateScore();
        gameOver = GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.zen == true)
        {
            scoreText.text = "";
        }
        else if (gameOver.zen == false)
        {
            if (player != null)
            {
                basicScore = (int)player.transform.position.x;
            }
            else
            {
                scoreText.text = "滑稽";
            }
            score = basicScore + extraScore;
            updateScore();
        }
    }

    public void addScore(int newScoreValue)
    {
        extraScore += newScoreValue;
        updateScore();
    }

    public void setExtraScore(int newScoreValue)
    {
        extraScore = newScoreValue;
        updateScore();
    }

    public int getScore()
    {
        return score;
    }

    void updateScore()
    {
        scoreText.text= "得分：" + score;       
    }
}
