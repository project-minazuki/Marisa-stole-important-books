using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{

    GameOver gameOver;
    //修改*********
    StatefulInspection statefulInspection;
    //修改*********

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in obj)
        {
            if (child.gameObject.name == "GameController")
            {
                gameOver = child.GetComponent<GameOver>();
                break;
            }
        }
        //修改************
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            statefulInspection = gameControllerObject.GetComponent<StatefulInspection>();
        }
        if (statefulInspection == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        //修改*************
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && (collision.GetComponent<PlayerMoving>().isPlayerDashing == false || gameObject.tag == "Death"))
        {
            if(statefulInspection.isStarPlatinum == false)
            Death();
        }
    }

    private void Death()
    {
        gameOver.Over();
    }
}
