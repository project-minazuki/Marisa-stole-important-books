using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallMove : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x -20f, 0, transform.position.z);
    }
 
}
