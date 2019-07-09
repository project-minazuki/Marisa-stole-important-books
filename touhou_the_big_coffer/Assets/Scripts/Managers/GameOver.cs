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

    public bool zen = false;
    StatefulInspection statefulInspection;
    public GameObject player;
    private float greentime;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        gameManage = GetComponent<GameManage>();
        statefulInspection = GetComponent<StatefulInspection>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<SpriteRenderer>().color == Color.red && Time.time - greentime >= 0.3f)
        {
            player.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void Over()
    {
        if (zen == false)
        {
            gameManage.GameOver();
            if (Savedata.SaveProcess().IsHighScore()) record.text = "新纪录!";
            scoreText.text = "你的得分:" + score.score + "pt";
            distanceText.text = "行进距离:" + score.basicScore + " m";
        }
        if (zen == true)
        {
            player.GetComponent<SpriteRenderer>().color = Color.red;
            greentime = Time.time;
            if (statefulInspection.kasi == true)
            {
                statefulInspection.kasi = false;
                gameManage.GameOver();
            }
        }
        /*gameManage.GameOver();
        if (Savedata.SaveProcess().IsHighScore()) record.text = "新纪录!";
        scoreText.text = "你的得分:" + score.score+"pt";
        distanceText.text = "行进距离:" + score.basicScore + " m";*/
    }
}
