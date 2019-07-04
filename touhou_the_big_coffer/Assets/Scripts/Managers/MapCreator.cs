using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject wall;
    public GameObject stab;
    public GameObject enemy;

    private int newWallx = 15;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = -6; i <= 15; i += 1)
        {
            Instantiate(wall, new Vector3(i, -4, 0), gameObject.transform.rotation);
        }
        InvokeRepeating("Create", 1, 0.3f);
        InvokeRepeating("CreateEnemy", 9f, 120f);//test
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Create()
    {
        float tmp = Random.Range(-3, 4);
        GameObject wall1 = Instantiate(wall, new Vector3(newWallx += 1,tmp, 0), gameObject.transform.rotation);
        GameObject wall2 = Instantiate(wall, new Vector3(newWallx, -4, 0), gameObject.transform.rotation);
        if (Random.Range(1, 5) == 3 && tmp != -3) Instantiate(stab, new Vector3(newWallx, -3.35f, 0), gameObject.transform.rotation);
        if (Random.Range(1, 5) == 4) Instantiate(stab, new Vector3(newWallx, tmp + 0.65f, 0), gameObject.transform.rotation);
    }

    private void CreateEnemy()
    {
        float tmp = Random.Range(-3, 4);
        GameObject wall1 = Instantiate(enemy, new Vector3(player.transform.position.x + 9, 0, 0), gameObject.transform.rotation);
    }
}
