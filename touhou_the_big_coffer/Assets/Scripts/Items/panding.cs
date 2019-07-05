using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class panding : MonoBehaviour
{
   
    Score SCORE;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            SCORE = gameControllerObject.GetComponent<Score>();
        }
        if (SCORE == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        // GameObject score = GameObject.FindGameObjectWithTag("Score");
        //Score SCORE =  GetComponent<gameControllerObject>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SCORE.addScore(5);
            Destroy(gameObject);
        }
       // if (collision.gameObject.name == "Invisible Wall")
       // {
        //   Destroy(gameObject);
        //}
    }
}
