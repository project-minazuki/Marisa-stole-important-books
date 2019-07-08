using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject wall;
    public GameObject stab;
    public GameObject MC;
    public GameObject bonus;
    public GameObject starplatinum;
    public GameObject player;
    public float positionx;
    public int newEnemyx = 100;
    public bool boss = false;

    private int newWallx = 20;    
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = -6; i <= 20; i += 1)
        {
            Instantiate(wall, new Vector3(i, -4, 0), gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        positionx = player.transform.position.x;
        Create();
        CreateEnemy();
    }

    private void Create()
    {
        if (newWallx - positionx <= 20)
        {
            int[] usedY = new int[4];
            usedY[0] = Random.Range(-3, 4);
             
            Instantiate(wall, new Vector3(newWallx += 1, usedY[0], 0), gameObject.transform.rotation);
            Instantiate(wall, new Vector3(newWallx, -4, 0), gameObject.transform.rotation);
            if (Random.Range(0, 100) >= 90 - positionx/100 && usedY[0] != -3) Instantiate(stab, new Vector3(newWallx, -3.35f, 0), gameObject.transform.rotation);
            if (Random.Range(1, 5) == 4) Instantiate(stab, new Vector3(newWallx, usedY[0] + 0.65f, 0), gameObject.transform.rotation);

            if (!boss)
            {
                //生成Bonus******
                usedY[1] = Random.Range(-2, 5);
                if (Random.Range(0, 100) >= 90f) { if (usedY[1] != usedY[0]) { Instantiate(bonus, new Vector3(newWallx, usedY[1], 0), gameObject.transform.rotation); } }
                //******生成Bonus

                //生成Starplatinum******
                usedY[2] = Random.Range(-2, 5);
                if (Random.Range(0, 100) >= 97f) { if (usedY[2] != usedY[0] && usedY[2] != usedY[1]) { Instantiate(starplatinum, new Vector3(newWallx, usedY[2], 0), gameObject.transform.rotation); } }
                //******生成Starplatinum

                //生成MC******
                usedY[3] = Random.Range(-2, 5);
                if (Random.Range(0, 100) >= 95f - positionx / 300 && positionx > 200) { if (usedY[3] != usedY[0] && usedY[3] != usedY[1] && usedY[3] != usedY[2]) { Instantiate(MC, new Vector3(newWallx, usedY[3], 0f), gameObject.transform.rotation); } }
                //******生成MC
            }
        }
    }
    private void CreateEnemy()
    {
        if (newEnemyx - positionx < 1 && !boss)
        {
            Instantiate(enemy, new Vector3(player.transform.position.x + 9, 0, 0), gameObject.transform.rotation);
            boss = true;
        }
    }
}
