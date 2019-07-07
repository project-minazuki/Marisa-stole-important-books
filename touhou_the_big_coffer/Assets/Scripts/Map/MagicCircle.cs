using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    StatefulInspection statefulInspection;
    GameOver gameOver;
    private GameObject MCBlue;
    private GameObject MCWhite;
    private GameObject MCBlue0;
    private GameObject MCWhite0;
    private GameObject MCBlue1;
    private GameObject MCWhite1;
    //
    public bool isBlue;
    public float MCtime = 0;
    private GameObject player;

    float MCchange = 2f;
    void Start()
    {
       GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            statefulInspection = gameControllerObject.GetComponent<StatefulInspection>();
            gameOver = gameControllerObject.GetComponent<GameOver>();
        }
        MagicCircleStart();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        UpdateMagicCircle();
        UpdateDistance();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            if (isBlue == true && statefulInspection.isStarPlatinum == false)
            {
                gameOver.Over();
            }
        }
    }
    public void UpdateMagicCircle()
    {
        if (Time.time >= MCtime + MCchange)
        {
            isBlue = !isBlue;
            MagicCircleChange();
        }
        if (isBlue == true)
        {
            MCBlue = gameObject.transform.GetChild(0).gameObject;
            MCWhite = gameObject.transform.GetChild(1).gameObject;
            MCBlue.GetComponent<SpriteRenderer>().enabled = true;
            MCWhite.GetComponent<SpriteRenderer>().enabled = false;
            MCBlue0 = MCBlue.transform.GetChild(0).gameObject;
            MCBlue1 = MCBlue.transform.GetChild(1).gameObject;
            MCWhite0 = MCWhite.transform.GetChild(0).gameObject;
            MCWhite1 = MCWhite.transform.GetChild(1).gameObject;
            MCBlue0.GetComponent<SpriteRenderer>().enabled = true;
            MCBlue1.GetComponent<SpriteRenderer>().enabled = true;
            MCWhite0.GetComponent<SpriteRenderer>().enabled = false;
            MCWhite1.GetComponent<SpriteRenderer>().enabled = false;
            //MCBlue.transform.position = new Vector3(MCBlue.transform.position.x, MCBlue.transform.position.y, 0f);
            //MCWhite.transform.position = new Vector3(MCWhite.transform.position.x, MCWhite.transform.position.y, -20f);
        }
        if (isBlue == false)
        {
            MCBlue = gameObject.transform.GetChild(0).gameObject;
            MCWhite = gameObject.transform.GetChild(1).gameObject;
            MCBlue.GetComponent<SpriteRenderer>().enabled = false;
            MCWhite.GetComponent<SpriteRenderer>().enabled = true;
            MCBlue0 = MCBlue.transform.GetChild(0).gameObject;
            MCBlue1 = MCBlue.transform.GetChild(1).gameObject;
            MCWhite0 = MCWhite.transform.GetChild(0).gameObject;
            MCWhite1 = MCWhite.transform.GetChild(1).gameObject;
            MCBlue0.GetComponent<SpriteRenderer>().enabled = false;
            MCBlue1.GetComponent<SpriteRenderer>().enabled = false;
            MCWhite0.GetComponent<SpriteRenderer>().enabled = true;
            MCWhite1.GetComponent<SpriteRenderer>().enabled = true;
            //MCBlue.transform.position = new Vector3(MCBlue.transform.position.x, MCBlue.transform.position.y, -20f);
            //MCWhite.transform.position = new Vector3(MCWhite.transform.position.x, MCWhite.transform.position.y, 0f);
        }
    }
    public void MagicCircleStart()
    {
        MCtime = Time.time;
        if (Random.Range(0, 100) <= 50)
            isBlue = true;
        else isBlue = false;
    }

    public void MagicCircleChange()
    {
        MCtime = Time.time;
    }
    private void UpdateDistance()
    {
        if (statefulInspection.isStarPlatinum == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= 1.1)
            Destroy(gameObject);
    }
}
