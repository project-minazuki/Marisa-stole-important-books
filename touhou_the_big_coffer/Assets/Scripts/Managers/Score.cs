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

    void Start()
    {
        score = 0;
        basicScore = 0;
        extraScore = 0;
        test = 0;
        updateScore();
    }

    // Update is called once per frame
    void Update()
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

    void updateScore()
    {
        scoreText.text= "得分：" + score;       
    }
}
