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
    public float moveSpeedx;
    public float moveSpeedy;
    public float max;
    public int test; 

    PlayerControl playerControl;

    private float timeSpeed;
    private float second = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = new Vector2(16, 0);
        colors = new Color[7];
        moon.transform.localPosition = new Vector3(max, moon.transform.localPosition.y, 0);
        moon2.transform.localPosition = new Vector3(max, moon2.transform.localPosition.y, 0);
        sun.transform.localPosition = new Vector3(max * -4 / 7, sun.transform.localPosition.y, 0);
        warm.transform.localPosition = new Vector3(max * -4 / 7, warm.transform.localPosition.y, 0);
        cold1.transform.localPosition = new Vector3(max * -4 / 7, cold1.transform.localPosition.y, 0);
        cold2.transform.localPosition = new Vector3(max * -4 / 7, cold2.transform.localPosition.y, 0);
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
        timeSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().timeSpeed;
        refreshTime();
        refreshPosition();
    }

    private void refreshTime()
    {
        second += (60/test * timeSpeed);
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
    }

    private void refreshPosition()
    {
        if (time == new Vector2(19, 0)) //此时太阳从左消失，月亮从右出现
        {
            sun.transform.localPosition = new Vector3(max, sun.transform.localPosition.y, 0);
            warm.transform.localPosition = new Vector3(max, warm.transform.localPosition.y, 0);
            cold1.transform.localPosition = new Vector3(max, cold1.transform.localPosition.y, 0);
            cold2.transform.localPosition = new Vector3(max, cold2.transform.localPosition.y, 0);
            moon2.GetComponent<Image>().enabled = true;
            moon.GetComponent<Image>().enabled = true;
            sun.GetComponent<Image>().enabled = false;
            cold2.GetComponent<Image>().enabled = false;
        }
        if (time == new Vector2(5, 0)) //此时月亮从左消失，太阳从右出现
        {
            moon.transform.localPosition = new Vector3(max, moon.transform.localPosition.y, 0);
            moon2.transform.localPosition = new Vector3(max, moon2.transform.localPosition.y, 0);
            moon.GetComponent<Image>().enabled = false;
            moon2.GetComponent<Image>().enabled = false;
            cold1.GetComponent<Image>().enabled = true;
            sun.GetComponent<Image>().enabled = true;
        }
        if (time == new Vector2(16, 0))
        {
            sun.GetComponent<Image>().enabled = false;
            warm.GetComponent<Image>().enabled = true;
            sun.GetComponent<Image>().enabled = true;
            cold1.GetComponent<Image>().enabled = false;
        }
        if (time == new Vector2(18, 0))
        {
            warm.GetComponent<Image>().enabled = false;
            sun.GetComponent<Image>().enabled = false;
            cold2.GetComponent<Image>().enabled = true;
            sun.GetComponent<Image>().enabled = true;
        }
        if (time.x >= 5 && time.x < 19)
        {
            sun.transform.localPosition += new Vector3(moveSpeedx * timeSpeed/test, (12 - time.x) * moveSpeedy * timeSpeed/test, 0);
            warm.transform.localPosition += new Vector3(moveSpeedx * timeSpeed/test, (12 - time.x) * moveSpeedy * timeSpeed/test, 0);
            cold1.transform.localPosition += new Vector3(moveSpeedx * timeSpeed/test, (12 - time.x) * moveSpeedy * timeSpeed/test, 0);
            cold2.transform.localPosition += new Vector3(moveSpeedx * timeSpeed/test, (12 - time.x) * moveSpeedy * timeSpeed/test, 0);
        }
        if (time.x < 5 || time.x >= 19)
        {
            if (time.x < 5)
            {
                moon.transform.localPosition += new Vector3(moveSpeedx * 7 / 5 * timeSpeed / test, -time.x * moveSpeedy * timeSpeed / test, 0);
                moon2.transform.localPosition += new Vector3(moveSpeedx * 7 / 5 * timeSpeed / test, -time.x * moveSpeedy * timeSpeed / test, 0);
            }
            else
            {
                moon.transform.localPosition += new Vector3(moveSpeedx * 7 / 5 * timeSpeed / test, (24 - time.x) * moveSpeedy * timeSpeed / test, 0);
                moon2.transform.localPosition += new Vector3(moveSpeedx * 7 / 5 * timeSpeed / test, (24 - time.x) * moveSpeedy * timeSpeed / test, 0);
            }
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
