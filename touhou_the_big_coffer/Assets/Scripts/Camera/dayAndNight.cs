using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayAndNight : MonoBehaviour
{
    public Color[] colors;
    public GameObject moon;
    public GameObject moon2;
    public GameObject sun;
    public GameObject warm;
    public GameObject cold1;
    public GameObject cold2;
    public Vector2 time;
    public string colorText;

    PlayerControl playerControl;

    private float timeSpeed;
    private int second = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = new Vector2(17, 0);
        colors = new Color[7];
        ColorUtility.TryParseHtmlString("#FF9010", out colors[0]);//16-18
        ColorUtility.TryParseHtmlString("#3333AE", out colors[1]);//18-20 cold2
        ColorUtility.TryParseHtmlString("#44567F", out colors[2]);//20-24
        ColorUtility.TryParseHtmlString("#1C3575", out colors[3]);//24-4
        ColorUtility.TryParseHtmlString("#44467F", out colors[4]);//4-8 cold1
        ColorUtility.TryParseHtmlString("#69D3FF", out colors[5]);//8-12 cold1
        ColorUtility.TryParseHtmlString("#90D880", out colors[6]);//12-16 cold1
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        refreshTime();
    }

    private void refreshTime()
    {
        timeSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().timeSpeed;
        second += (int)(1.2 * timeSpeed);
        if (second >= 60)
        {
            second -= 60;
            refreshColor();
            time.y++;
        }
        if (time.y >= 60)
        {
            time.y -= 60;
            time.x++;
        }
        if (time.x >= 24)
        {
            time.x -= 24;
        }
    }

    private void refreshColor()
    {
        int hour = (int)time.x;
        if (17 <= hour && hour < 19) changeColor(0,2);
        if (19 <= hour && hour < 22) changeColor(1, 3);
        if (22 <= hour || hour < 2) changeColor(2, 4);
        if (2 <= hour && hour < 6) changeColor(3, 4);
        if (6 <= hour && hour < 10) changeColor(4, 4);
        if (10 <= hour && hour < 14) changeColor(5, 4);
        if (14 <= hour && hour < 17) changeColor(6, 3);
        if (hour == 19)
        {
            moon.GetComponent<Image>().enabled = true;
            moon2.GetComponent<Image>().enabled = true;
            sun.GetComponent<Image>().enabled = false;
            cold2.GetComponent<Image>().enabled = false;
        }
        if (hour == 4)
        {
            moon.GetComponent<Image>().enabled = false;
            moon2.GetComponent<Image>().enabled = false;
            sun.GetComponent<Image>().enabled = true;
            cold1.GetComponent<Image>().enabled = true;
        }
        if (hour == 16)
        {
            warm.GetComponent<Image>().enabled = true;
            cold1.GetComponent<Image>().enabled = false;
        }
        if (hour == 18)
        {
            warm.GetComponent<Image>().enabled = false;
            cold2.GetComponent<Image>().enabled = true;
        }
    }

    private void changeColor(int begin,int deltaTime)
    {
        int tmp = 1;
        if (begin == 6) tmp = -6;
        timeSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().timeSpeed;
        gameObject.GetComponent<Camera>().backgroundColor += timeSpeed * (colors[begin + tmp] - colors[begin]) / (60 * deltaTime);
        colorText = ColorUtility.ToHtmlStringRGB(gameObject.GetComponent<Camera>().backgroundColor);
    }
}
