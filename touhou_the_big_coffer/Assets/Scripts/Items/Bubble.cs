using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float lifetime=7.5f;
    public GameObject player;
    private float Createtime;
    //StatefulInspection statefulInspection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, lifetime);
        /*GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
           statefulInspection = gameControllerObject.GetComponent<StatefulInspection>();
         }*/
        Createtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (Time.time - Createtime >= 6.5)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
          /*  if (Time.time % 1 >= 0.5)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                Debug.Log("see");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("unsee");
            }*/
        }
    }
}
