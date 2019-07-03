using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int BasicScore;
    public int ExtraScore;
    public int score;
    public Text scoreText;
    public int test;
    public GameObject player;
    public float positionX;
    void Start()
    {
        score = 0;
        BasicScore = 0;
        ExtraScore = 0;
        test = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        test = 78685;
        if (player != null)
        {
            BasicScore = (int)player.transform.position.x;
            test = 999;
        }
        else
        {
            scoreText.text = "滑稽";
            test = 123;
        }
        score = BasicScore + ExtraScore;
        UpdateScore();
    }
    public void AddScore(int newScoreValue)
    {
        ExtraScore += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text= "得分：" + score;
       
    }
}
