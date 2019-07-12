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

        highscoreText.text = highscore.ToString();
        highmoveText.text = ((int)highmove).ToString();
        AllTimesMoveText.text =((int)AllTimesMove).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
