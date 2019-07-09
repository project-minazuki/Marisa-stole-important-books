using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvasGroup_option;
    public CanvasGroup canvasGroup_playerData;
    public CanvasGroup canvasGroup_about;
    int canvasIndex = 0;//0-option,1-playerData,2-about
    private readonly float smooth = 0.03f;
    void Start()
    {
        canvasGroup_option.alpha = 1;
        canvasGroup_playerData.alpha = canvasGroup_about.alpha= 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (canvasIndex)
        {
            case 0:
                if (canvasGroup_option.alpha < 1 || canvasGroup_about.alpha > 0 || canvasGroup_playerData.alpha > 0)
                {
                    canvasGroup_option.alpha += 2 * smooth;
                    canvasGroup_about.alpha -= smooth;
                    canvasGroup_playerData.alpha -= smooth;
                }
                break;
            case 1:
                if (canvasGroup_option.alpha > 0 || canvasGroup_about.alpha < 0 || canvasGroup_playerData.alpha > 0)
                {
                    canvasGroup_option.alpha -= smooth;
                    canvasGroup_about.alpha -= smooth;
                    canvasGroup_playerData.alpha += 2 * smooth;
                }
                break;
            case 2:
                if (canvasGroup_option.alpha > 0 || canvasGroup_about.alpha < 1 || canvasGroup_playerData.alpha > 0)
                {
                    canvasGroup_option.alpha -= smooth;
                    canvasGroup_about.alpha += 2 * smooth;
                    canvasGroup_playerData.alpha -= smooth;
                }
                break;
        }
    }
    public void LoadOption()
    {
        canvasIndex = 0;
    }
    public void LoadPlayerData()
    {
        canvasIndex = 1;
    }

    public void LoadAbout()
    {
        canvasIndex = 2;
    }

}
