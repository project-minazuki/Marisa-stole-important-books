using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMusic()
    {
        if (AudioListener.volume == 1) AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }
}
