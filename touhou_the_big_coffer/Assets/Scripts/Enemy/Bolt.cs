using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float speed;

    private float timeSpeed = 1;
    private GameObject player;
    private Vector2 direction;

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
        if (gameObject.tag == "Bolt 1")timeSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().timeSpeed;
        transform.Translate(Vector3.right * speed * timeSpeed * Time.deltaTime, Space.Self);
        UpdateDistance();
    }
    private void UpdateDistance()
    {
        if (statefulInspection.isStarPlatinum == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= 1.1)
            Destroy(gameObject);
    }
}
