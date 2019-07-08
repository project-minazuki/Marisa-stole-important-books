using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject player;
    private float Createtime;
    StatefulInspection statefulInspection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            statefulInspection = gameControllerObject.GetComponent<StatefulInspection>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (statefulInspection.realtime - statefulInspection.realtimefixed >= 6.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }
        if (statefulInspection.realtime - statefulInspection.realtimefixed >= 7.5f)
        {
            Destroy(gameObject);
        }
    }
}
