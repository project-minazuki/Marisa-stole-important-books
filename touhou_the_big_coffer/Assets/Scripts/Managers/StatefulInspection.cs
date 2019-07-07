using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulInspection : MonoBehaviour
{
    public GameObject player;
    public GameObject bubble;
    public bool isStarPlatinum = false;
    public float SPlast = 7.5f;
    public float SPtime=0;

    //修改******
    public bool touchStarPlatinum = false;
    //******修改
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStarplatinum();
    }
        
    public void Starplatinum()
    {
        isStarPlatinum = true;
        SPtime = Time.time;
    }

    public void UpdateStarplatinum()
    {
        if (isStarPlatinum == true && Time.time >= SPtime + SPlast)
        {
            isStarPlatinum = false;
        }
        if (touchStarPlatinum == true)
        {
            Instantiate(bubble, new Vector3(player.transform.position.x, player.transform.position.y, 0), gameObject.transform.rotation);
            touchStarPlatinum = false;
        }
    }
}
