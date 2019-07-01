using System.Collections;
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

        if (Input.GetButton("Fire1") && playerMoving.isPlayerJumped == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,8);
            playerMoving.isPlayerJumped = true;
        }

//#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RefleshJump" && playerMoving.isPlayerJumped == true)
        {
            playerMoving.isPlayerJumped = false;
        }
    }
}
