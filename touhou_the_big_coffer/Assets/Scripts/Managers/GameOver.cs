using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Over()
    {
        score.setExtraScore(-score.basicScore);
        Debug.Log("DieDieDie");
    }
}
