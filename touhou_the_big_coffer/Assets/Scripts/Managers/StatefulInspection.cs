using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatefulInspection : MonoBehaviour
{
    public bool isStarPlatinum = false;
    public float SPlast = 7.5f;
    public float SPtime=0;
    // Start is called before the first frame update
    void Start()
    {
       
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
        
    }
}
