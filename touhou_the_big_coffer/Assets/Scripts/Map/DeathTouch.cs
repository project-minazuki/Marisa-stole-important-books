using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{

    GameOver gameOver;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Death();
        }
    }

    private void Death()
    {
        gameOver.Over();
    }
}
