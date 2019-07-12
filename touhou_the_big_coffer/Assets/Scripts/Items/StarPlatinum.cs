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
            statefulInspection.touchStarPlatinum = true;
            //statefulInspection.realtimefixed = Time.time;
            //print("StarPlatinum is true");
        }
    }


}
