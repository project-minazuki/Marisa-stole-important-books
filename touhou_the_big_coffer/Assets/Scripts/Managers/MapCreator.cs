using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject wall;
    public GameObject stab;
    //修改******
    public GameObject bonus;
    public GameObject starplatinum;
    public GameObject player;
    public float positionx;
    //******修改
    private int newWallx = 20;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -6; i <= 20; i += 1)
        {
            Instantiate(wall, new Vector3(i, -4, 0), gameObject.transform.rotation);
        }
        InvokeRepeating("Create", 1, 0.3f);
        InvokeRepeating("CreateEnemy", 9f, 120f);//test

    }

    // Update is called once per frame
    void Update()
    {
        positionx = player.transform.position.x;
    }

    private void Create()
    {
        if (newWallx - positionx <= 20)
        {
            float tmp = Random.Range(-3, 4);
           GameObject wall1 = Instantiate(wall, new Vector3(newWallx += 1, tmp, 0), gameObject.transform.rotation);
            GameObject wall2 = Instantiate(wall, new Vector3(newWallx, -4, 0), gameObject.transform.rotation);
            if (Random.Range(1, 5) == 3 && tmp != -3) Instantiate(stab, new Vector3(newWallx, -3.35f, 0), gameObject.transform.rotation);
            if (Random.Range(1, 5) == 4) Instantiate(stab, new Vector3(newWallx, tmp + 0.65f, 0), gameObject.transform.rotation);


            //生成Bonus******
            float posibilitybonus = Random.Range(0, 100);
            float tmpbonus = Random.Range(-2, 5);
            if (posibilitybonus >= 90f) { if (tmpbonus != tmp) { GameObject BONUS = Instantiate(bonus, new Vector3(newWallx, tmpbonus, 0), gameObject.transform.rotation); } }
            //******生成Bonus

            //生成Starplatinum******
            float posibilitystarplatinum = Random.Range(0, 100);
            float tmpStarplatinum = Random.Range(-2, 5);
            if (posibilitystarplatinum >= 97f) { if (tmpStarplatinum != tmp && tmpStarplatinum != tmpbonus) { GameObject STARPLATINUM = Instantiate(starplatinum, new Vector3(newWallx, tmpStarplatinum, 0), gameObject.transform.rotation); } }
            //******生成Starplatinum
        }
    }
    private void CreateEnemy()
    {
        float tmp = Random.Range(-3, 4);
        GameObject wall1 = Instantiate(enemy, new Vector3(player.transform.position.x + 9, 0, 0), gameObject.transform.rotation);
    }
}
