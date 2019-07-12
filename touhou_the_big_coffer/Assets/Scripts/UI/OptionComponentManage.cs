using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionComponentManage : MonoBehaviour
{
    public Button button_Music;
    public Button button_DeveloperInformation;
    public Image image_highScore;
    public Image image_highMove;
    public Image image_allMove;


    public ScrollRect rect;

    private int screenHigh;
    // Start is called before the first frame update
    void Start()
    {
        screenHigh = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        button_Music.transform.localPosition = new Vector3(-108.1f, rect.horizontalNormalizedPosition * screenHigh*2 + 12.75f, 0);
        button_DeveloperInformation.transform.localPosition = new Vector3(-61.335f, rect.horizontalNormalizedPosition*1.75f * screenHigh, 0);
        image_highScore.transform.localPosition = new Vector3(60, rect.horizontalNormalizedPosition * screenHigh - 75f, 0);
        image_highMove.transform.localPosition = new Vector3(60, rect.horizontalNormalizedPosition * screenHigh*1.5f+15 , 0);
        image_allMove.transform.localPosition = new Vector3(60, rect.horizontalNormalizedPosition * screenHigh*2 + 105f, 0);
    }
}
