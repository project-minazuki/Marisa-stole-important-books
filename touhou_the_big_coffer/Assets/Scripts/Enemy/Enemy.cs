using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject masterSpark;
    public GameObject shot1;
    public GameObject shot2;
    public float timeBetweenFire;
    public int shotNum;
    public int attackMode;
    public float timer;

    MapCreator mapCreator;

    private float timeSpeed = 1;
    private GameObject player;
    private Score score;
    private int direction;

    //修改******
    public GameObject DeathBonus;
    private float positionx;
    private float positiony;
    int i;
    //******修改

    // Start is called before the first frame update
    void Start()
    {
        attackMode = 1;//Random.Range(1, 3);
        direction = -1;
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
        if (attackMode == 1) AttackMode1();
        if (attackMode == 2) AttackMode2();
        positionx = gameObject.transform.position.x;
        positiony = gameObject.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            score.addScore(50);
            mapCreator.newEnemyx = (int)player.transform.position.x + 300;
            mapCreator.boss = false;
            Destroy(gameObject);
            for (i = 1; i <= 15; i++)
            {
                Instantiate(DeathBonus, new Vector3(positionx, positiony, 0), gameObject.transform.rotation);
            }
        }
    }

    private void Fire()
    {
        int tmp = Random.Range(0, 360);
        for (int i = 0; i < shotNum; i++)
        {
            Instantiate(shot1, transform.position, Quaternion.Euler(0, 0, 360 / shotNum * i + tmp + 180 / shotNum));
            Instantiate(shot2, transform.position, Quaternion.Euler(0, 0, 360 / shotNum * i + tmp));
        }
    }

    private void AttackMode1()
    {
        timer += 20 * timeSpeed;
        if (timer > timeBetweenFire)
        {
            timer = 0;
            Fire();
        }
        if (transform.position.x - 12 < player.transform.position.x)
        {
            if (transform.position.x > player.transform.position.x) transform.position = new Vector3(transform.position.x + timeSpeed * 3f * Time.deltaTime, transform.position.y, 0);
            else transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
        }
    }

    private void AttackMode2()
    {
        if ((timer -= (timeSpeed)) <= 0)
        {
            if (transform.position.y < -3.5) direction = 1;
            if (transform.position.y > 3.5) direction = -1;
            if (transform.position.x - 12 < player.transform.position.x)
            {
                if (transform.position.x > player.transform.position.x) transform.position = new Vector3(transform.position.x + timeSpeed * 4f * Time.deltaTime, transform.position.y + timeSpeed * direction * Time.deltaTime, 0);
                else transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
            }
            if ((int)transform.position.y == (int)player.transform.position.y)
            {
                Invoke("MasterSpark", 1.5f);
                timer = 180;
            }
        }
        
    }
    private void MasterSpark()
    {
        Instantiate(masterSpark, transform.position - new Vector3(12, 0, 0), Quaternion.Euler(0, 0, 180));
    }
   
}
