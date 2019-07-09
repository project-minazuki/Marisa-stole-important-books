using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour
{
    int highscore;
    double highmove;
    double AllTimesMove;

    public Text highscoreText;
    public Text highmoveText;
    public Text AllTimesMoveText;
    // Start is called before the first frame update
    void Start()
    {
        highscore = Savedata.GetHighScore();
        highmove = Savedata.GetHighMove();
        AllTimesMove = Savedata.GetAllTimesMove();

        highscoreText.text = "最高分：" + highscore + "pt";
        highmoveText.text = "最远距离：" + (int)highmove + "km";
        AllTimesMoveText.text = "总距离：" + (int)AllTimesMove + "km";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
