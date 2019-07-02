﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    PlayerMoving playerMoving;
    // Start is called before the first frame update
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
    }

    // Update is called once per frame
    void Update()
    {
//#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

        if (Input.GetButton("Fire1") )
        {
            if (playerMoving.isPlayerJumped == false && GetComponent<Rigidbody2D>().velocity.y >= -0.5)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,8);
                playerMoving.isPlayerJumped = true;
            }
        }

//#endif

        if (playerMoving.isPlayerClimbing == false && playerMoving.isPlayerBlocked == true && (playerMoving.isPlayerJumped == true || GetComponent<Rigidbody2D>().velocity.y < -0.5))
        {
            if (Input.GetButton("Fire1") && playerMoving.isPlayerClimbing == false)
            {
                playerMoving.isPlayerClimbing = true;
                playerMoving.isPlayerJumped = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f);
                Invoke("endClimb", 0.25f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RefleshJump" && playerMoving.isPlayerJumped == true)
        {
            playerMoving.isPlayerJumped = false;
        }
        if (collision.gameObject.name == "ClimbPoint" )
        {
            playerMoving.isPlayerBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ClimbPoint")
        {
            playerMoving.isPlayerBlocked = false;
        }
    }

    private void endClimb()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
        playerMoving.isPlayerClimbing = false;
    }
}
