using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Turn", deltaTime/2, deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
    }

    private void Turn()
    {
        gameObject.transform.Rotate(Vector3.forward * 90);
    }

}
