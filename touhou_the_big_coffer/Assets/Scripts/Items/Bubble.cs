using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bolt"&& other.gameObject.name == "MC")
        {
            Destroy(other);
            Debug.Log("succeed");
        }
    }*/
}
