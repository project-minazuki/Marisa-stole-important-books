using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    Score score;
    GameManage gameManage;
    public Text scoreText;
    public Text distanceText;
    public Text record;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        gameManage = GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Over()
    {
        gameManage.GameOver();
        if (Savedata.SaveProcess().IsHighScore()) record.text = "新纪录!";
        scoreText.text = "你的得分:" + score.score+"pt";
        distanceText.text = "行进距离:" + score.basicScore + " m";
    }
}
