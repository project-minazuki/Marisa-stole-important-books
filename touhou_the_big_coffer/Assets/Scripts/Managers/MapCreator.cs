using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject wall;

    private int newWallx = 15;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -6; i <= 15; i += 1)
        {
            Instantiate(wall, new Vector3(i, -4, 0), gameObject.transform.rotation);
        }
        InvokeRepeating("Create", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Create()
    {
        Instantiate(wall, new Vector3(newWallx += 1, Random.Range(-3, 4), 0), gameObject.transform.rotation);
        Instantiate(wall, new Vector3(newWallx, -4, 0), gameObject.transform.rotation);
    }
}
