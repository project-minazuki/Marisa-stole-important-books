using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByInvisibleWall : MonoBehaviour
{
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Invisible Wall")
        {
            Destroy(gameObject);
        }
    }
    
}
