using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public bool isPlayerJumped = false;
    public bool isPlayerBlocked = false;
    public bool isPlayerClimbing = false;
    public bool isPlayerDashed = false;
    public bool isPlayerDashing = false;
    public bool isPlayerJumpedTwice = false;

    PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerBlocked == false && !isPlayerDashing)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, transform.position += new Vector3(5, 0, 0),  playerControl.timeSpeed * 3 * Time.deltaTime);
        }
    }
}
