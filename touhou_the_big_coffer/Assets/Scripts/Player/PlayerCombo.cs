using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombo : MonoBehaviour
{
    Score score;
    PlayerControl playerControl;
    GameOver gameOver;

    public Text comboText;
    public string comboString;
    public int combo = 0;
    public int totalScore;

    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            score = gameControllerObject.GetComponent<Score>();
            gameOver = gameControllerObject.GetComponent<GameOver>();
        }
        if (score == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.zen == false)
        {
            if (timer > 0) timer -= (int)playerControl.timeSpeed * 20;
            if (timer == 0) calculateCombo();
        }
    }

    public void addCombo(int scoreValue, string comboType)
    {
        if (gameOver.zen == false)
        {
            if (timer > 0) calculateCombo();
            combo += 1;
            totalScore += scoreValue;
            comboString += scoreValue + " " + comboType + "\n";
            updateCombo();
            timer = -1;
        }
    }

    private void updateCombo()
    {
        comboText.text = comboString + combo + " × " + totalScore;
    }
    
    public void finishCombo()
    {
        timer = 1200;
    }

    public void calculateCombo()
    {
        score.addScore(combo * totalScore);
        comboString = null;
        comboText.text = "";
        combo = 0;
        totalScore = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameOver.zen == false)
        {
            if (collision.gameObject.name == "stabComboArea")
            {
                addCombo(10, "躲避尖刺");
            }
            if (collision.gameObject.name == "sawComboArea")
            {
                addCombo(15, "躲避陷阱");
            }
            if (collision.gameObject.name == "boltComboArea")
            {
                addCombo(10, "穿过弹幕");
            }
            if (collision.gameObject.name == "magicCircleArea")
            {
                addCombo(20, "破除魔法");
            }
            if (collision.gameObject.name == "masterSparkComboArea")
            {
                addCombo(50, "避开魔炮");
            }
        }
    }
}
