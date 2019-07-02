﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public bool isPlayerJumped = false;
    public bool isPlayerBlocked = false;
    public bool isPlayerClimbing = false;
    public bool isPlayerDashed = false;
    public bool isPlayerJumpedTwise = false;

    TheWorld theWorld;

    // Start is called before the first frame update
    void Start()
    {
        theWorld = GetComponent<TheWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerBlocked == false)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, transform.position += new Vector3(5, 0, 0),  theWorld.timeSpeed * 2 * Time.deltaTime);
        }
    }
}
