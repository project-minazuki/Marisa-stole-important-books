using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperInformation : MonoBehaviour
{
    public Image image_highScore;
    public Image image_highMove;
    public Image image_allMove;

    bool isDIcalled;

    public Image DeveloperInformation00;
    // Start is called before the first frame update
    void Start()
    {
        isDIcalled = false;
        DeveloperInformation00.color= new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallDeveloperInformation()
    {
        if (!isDIcalled)
        {
            image_highScore.color =
            image_highMove.color =
            image_allMove.color =
            image_highScore.GetComponentInChildren<Text>().color =
            image_highMove.GetComponentInChildren<Text>().color =
            image_allMove.GetComponentInChildren<Text>().color = new Color(0, 0, 0, 0);

            DeveloperInformation00.color = new Color(1,1,1,1);
        }
        else
        {
            image_highScore.color =
            image_highMove.color =
            image_allMove.color = new Color(1, 1, 1, 1);
            image_highScore.GetComponentInChildren<Text>().color =
            image_highMove.GetComponentInChildren<Text>().color =
            image_allMove.GetComponentInChildren<Text>().color = new Color(0,0,0,1);

            DeveloperInformation00.color = new Color(0, 0, 0, 0);
        }
        isDIcalled = !isDIcalled;
    }
}
