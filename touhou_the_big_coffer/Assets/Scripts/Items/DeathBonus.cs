using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathBonus : MonoBehaviour
{
    Score SCORE;
    private float Createtime;
    private float speed = 1f;
    private float positionx;
    private float positiony;
    private float randomx;
    private float randomy;
    
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null)
        {
            SCORE = gameControllerObject.GetComponent<Score>();
        }
        Createtime = Time.time;
        randomy = Random.Range(0, 40) * 0.1f;
        randomx = Random.Range(0, 80) * 0.1f;
        positionx = gameObject.transform.position.x;
        positiony = gameObject.transform.position.y;
        //rb = GetComponent<Rigidbody2D>();
        //GetComponent<Rigidbody2D>().velocity = new Vector2(7.0f * (Createtime + 5.0f - Time.time), Random.Range(-20, 20) * 0.1f * (Createtime + 5.0f - Time.time)) * speed;
        //rb.AddForce(new Vector2(Random.Range(50,80),Random.Range(0,40))*speed);
    }

    void Update()
    {

        //GetComponent<Rigidbody2D>().velocity = new Vector2(7.0f * (Createtime+5.0f-Time.time), Random.Range(-20, 20) * 0.1f* (Createtime + 5.0f - Time.time))*speed;
        transform.position = new Vector2(positionx+(10.0f+randomx) * ( Time.time- Createtime)-2.0f*(Time.time - Createtime)*(Time.time - Createtime), positiony-(randomy-2.0f)* (Time.time - Createtime)) * speed;
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time-Createtime>=1f&& collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            SCORE.addScore(20);
            Debug.Log("eat");
        }
    }
}
