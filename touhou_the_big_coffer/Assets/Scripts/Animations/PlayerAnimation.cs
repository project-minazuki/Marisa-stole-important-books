using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerControl playerControl;
    PlayerMoving playerMoving;
    Animator animator;
    float timeRect;

    // Start is called before the first frame update
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
        animator = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = playerControl.timeSpeed;
        if (playerMoving.isPlayerDashing) animator.SetBool("Dash", true);
        else animator.SetBool("Dash", false);
        if (playerMoving.isPlayerClimbing) animator.SetBool("Climb", true);
        else animator.SetBool("Climb", false);
    }
}
