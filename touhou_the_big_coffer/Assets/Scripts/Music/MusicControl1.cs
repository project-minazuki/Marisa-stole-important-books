using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl1 : MonoBehaviour
{
    GameOver gameOver;
    //AudioSource[] game= new AudioSource[2];
    AudioSource gameon;
    //AudioSource gameoff;
    //public AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameOver = gameControllerObject.GetComponent<GameOver>();
        }
        gameon = this.GetComponent<AudioSource>();
        //gameon.mute=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.music == true)
        {
            gameon.mute = false;
        }
        if (gameOver.music == false)
        {
            gameon.mute = true;
        }
    }
}
