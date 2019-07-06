using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPlatinum : MonoBehaviour
{
    StatefulInspection statefulInspection;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            statefulInspection = gameControllerObject.GetComponent<StatefulInspection>();
        }
        if (statefulInspection == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            statefulInspection.Starplatinum();
            //print("StarPlatinum is true");
        }
    }


}
