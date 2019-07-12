using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManage : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvasGroup;
    public CanvasGroup canvasGroupOver;


    private bool paused;
    public int screenHeight;
    public int screenWidth;
    void Start()
    {
        GameObject[] obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
      
        paused = false ;
        GetScreenWH();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused != true)
            {
                Pause();
            }
        }
    }
    public void OnStartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene");
        canvasGroupOver.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, 0) + new Vector3(0, screenHeight, 0);
        canvasGroup.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, 0) + new Vector3(0, screenHeight, 0);
    }
    public void OnStartGame2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene2");
        canvasGroupOver.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, 0) + new Vector3(0, screenHeight, 0);
        canvasGroup.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, 0) + new Vector3(0, screenHeight, 0);
        

    }
    public void OnExitGame()
    {
        Application.Quit();
    }//Exit the game from the main menu
    public void OnExitGame2()
    {
        if (canvasGroup != null)
        {
            canvasGroup.transform.position += new Vector3(0, screenHeight , 0);
            Time.timeScale = 1;
        }
        SceneManager.LoadScene("Start");
    
    }//Exit the game when playing
    public void OnSetting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void Retry()
    {
        if (canvasGroup != null)
        {
            paused = false;
            canvasGroup.transform.position += new Vector3(0, screenHeight, 0);
            SceneManager.LoadScene("Scene");
            Time.timeScale = 1;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        if (paused == false)
        {
            if (canvasGroup != null)
            {
                canvasGroup.transform.position = new Vector3(screenWidth/2, screenHeight/2, 0);
                paused = true;
            }
        }
    }
    public void Continue()
    {
        if (canvasGroup != null)
        {
            Time.timeScale = 1;
            canvasGroup.transform.position += new Vector3(0, screenHeight, 0);
            paused = false;
        }
    }
    public void GetScreenWH()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        paused = true;
        if (canvasGroupOver != null)
        {
            canvasGroupOver.transform.position = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        }
    }
}
