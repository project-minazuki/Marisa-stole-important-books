using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeMusicButton : MonoBehaviour
{
    public Sprite Mysprit;
    private Sprite Defallsprit;
    public bool ischange = false;

    // Use this for initialization
    void Start()
    {
        Defallsprit = transform.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Clicked()
    {
        ischange = !ischange;
        if (ischange)
        {
            ///更改按钮图片
            transform.GetComponent<Image>().sprite = Mysprit;
            if (AudioListener.volume == 1) AudioListener.volume = 0;
            else AudioListener.volume = 1;
        }
        else
        {
            ///还原按钮图片
            transform.GetComponent<Image>().sprite = Defallsprit;
            if (AudioListener.volume == 1) AudioListener.volume = 0;
            else AudioListener.volume = 1;
        }
    }

}
