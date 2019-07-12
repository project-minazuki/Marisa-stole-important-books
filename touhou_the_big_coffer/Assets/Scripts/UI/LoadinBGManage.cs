using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadinBGManage : MonoBehaviour
{
    public CanvasGroup BlurBG;
    // Start is called before the first frame update
    void Start()
    {
        BlurBG.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlurBG != null)
        {
            if (BlurBG.alpha < 1)
            {
                BlurBG.alpha += 1 / 21;
            }
        }
    }
}
