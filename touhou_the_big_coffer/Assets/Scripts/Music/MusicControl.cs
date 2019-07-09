using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    private bool IsMusicOn=true;
    public Text musicSwitchText;
    public GameObject musicManage;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        if(musicManage!=null)
        Audio = musicManage.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartInterfaceMusicSwitch()
    {
        IsMusicOn = !IsMusicOn;
        if (Audio != null)
        {
            if (IsMusicOn)
            {
                musicSwitchText.text = "开";
                Audio.mute = false;
            }
            else
            {
                musicSwitchText.text = "关";
                Audio.mute = true;
            }
        }
    }
}
