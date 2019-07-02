using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    public float timeSpeed = 0f;

    PlayerMoving playerMoving;
    Rigidbody2D rigidbody2D;

    private float gravity;
    private bool theWorldStart = false;
    private bool theWorldEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            if (!theWorldStart)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 0.1f);
                theWorldStart = true;
            }
            theWorldEnd = false;
            timeSpeed = 0.1f;
            rigidbody2D.gravityScale = 0.01f * gravity;
        }
        else
        {
            if (!theWorldEnd)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 10f);
                theWorldEnd = true;
            }
            theWorldStart = false;
            timeSpeed = 1.0f;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
    }
}
