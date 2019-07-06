using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public float shadowRate;
    public float shadowDelay;   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shadow", shadowDelay, shadowRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shadow()
    {
        GetComponent<CircleCollider2D>().enabled = !GetComponent<CircleCollider2D>().enabled;
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}
