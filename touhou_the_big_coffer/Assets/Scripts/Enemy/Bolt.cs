using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float speed;

    private float timeSpeed = 1;
    private GameObject player;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().timeSpeed;
        GetComponent<Rigidbody2D>().velocity = direction * speed * timeSpeed;
    }
}
