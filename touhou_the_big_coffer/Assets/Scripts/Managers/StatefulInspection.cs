using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulInspection : MonoBehaviour
{
    public GameObject player;
    public GameObject bubble;
    public bool isStarPlatinum = false;
    public float SPlast = 7.5f;
    public float SPtime = 0;
    PlayerMoving playerMoving;
    GameOver gameOver;
    PlayerControl playerControl;
    public float realtime = 0f;
    private float extratime;
    public float realtimefixed;
    //修改******
    public bool touchStarPlatinum = false;
    //******修改

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerMoving = player.GetComponent<PlayerMoving>();
            playerControl = player.GetComponent<PlayerControl>();
        }
        gameOver = GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStarplatinum();
        UpdateState();
    }

    public void Starplatinum()
    {
        isStarPlatinum = true;
        SPtime = Time.time;
        realtimefixed = Time.time;
    }

    public void UpdateStarplatinum()
    {
        //修改*****
        extratime = (Time.time - SPtime) * playerControl.timeSpeed;
        realtime = realtime + extratime;
        SPtime = Time.time;
        if (isStarPlatinum == true && realtime - realtimefixed >= 7.5f)
        {
            isStarPlatinum = false;
        }
        if (touchStarPlatinum == true)
        {
            realtime = realtimefixed;
            Instantiate(bubble, new Vector3(player.transform.position.x, player.transform.position.y, 0), gameObject.transform.rotation);
            touchStarPlatinum = false;
        }
    }

    public void UpdateState()
    {
        if (playerMoving.isPlayerBlocked == true && playerMoving.isPlayerdown == true && playerMoving.isPlayerUp == true)
            gameOver.Over();
    }
}
