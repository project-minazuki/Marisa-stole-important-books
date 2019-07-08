using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject shot;
    public float timeBetweenFire;

    MapCreator mapCreator;

    private float timeSpeed = 1;
    private GameObject player;
    private Score score;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            score = gameControllerObject.GetComponent<Score>();
            mapCreator = gameControllerObject.GetComponent<MapCreator>();
        }
        if (score == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpeed = player.GetComponent<PlayerControl>().timeSpeed;
        timer += 20*timeSpeed;
        if ( timer > timeBetweenFire)
        {
            timer = 0;
            Fire();
        }
        if (transform.position.x > player.transform.position.x) gameObject.transform.position = new Vector3(transform.position.x + timeSpeed * 3f * Time.deltaTime, 0, 0);
        else transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
        if (transform.position.x + 16 < player.transform.position.x) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            score.addScore(50);
            mapCreator.newEnemyx = (int)player.transform.position.x + 300;
            mapCreator.boss = false;
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
        Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation);
    }
}
