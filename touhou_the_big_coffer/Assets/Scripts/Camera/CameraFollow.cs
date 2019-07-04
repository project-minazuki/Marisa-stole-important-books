using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private float zoomInNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 4f, transform.position.y, transform.position.z);
    }

    public void zoomIn()
    {
        if (zoomInNum < 11)
        {
            zoomInNum += 1;
            transform.position = new Vector3(transform.position.x, transform.position.y + player.transform.position.y / 10 * (2.1f - zoomInNum/5) + player.GetComponent<Rigidbody2D>().velocity.y/55, transform.position.z + 0.5f * (2.1f - zoomInNum / 5));
        }
        else
        {
            zoomInNum = 11;
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }
    }
    public void zoomOut()
    {
        if (zoomInNum > 0)
        {
            zoomInNum -= 1;
            transform.position = new Vector3(transform.position.x, transform.position.y / 1.3f, transform.position.z - 0.5f * (zoomInNum / 5 - 0.1f));
        }
        else
        {
            zoomInNum = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y/1.2f, -10);
        }
    }
}
