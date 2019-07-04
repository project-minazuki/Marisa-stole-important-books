using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class PauseButton : MonoBehaviour
{
    public Button button00;
    public CanvasGroup canvasGroup;
    private bool PauseButtonEnabled=true;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR  //if current platform is mobile,
        PauseButtonEnabled = false;
#endif
        if (!PauseButtonEnabled)
        {
            canvasGroup.alpha = 0;
            button00.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
