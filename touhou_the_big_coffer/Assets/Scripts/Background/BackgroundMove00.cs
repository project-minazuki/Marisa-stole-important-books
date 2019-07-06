using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BackgroundMove00 : MonoBehaviour
{
    public int screenWidth;
    public int screenHeight;
    public Image Background;
    public int PlayerPosX;
    public GameObject canvas;

    private GameObject player;

    public float BackgroundSpeed;
    public float YCorrectionValue;
    public float XCorrectionValue;//-1

    Vector3 ExtraVector;
    // Start is called before the first frame update
    void Start()
    {
        GetScreenWH();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.localPosition =new Vector3(XCorrectionValue*screenWidth, YCorrectionValue * screenHeight, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < -screenWidth)
        {
            transform.localPosition = new Vector3(screenWidth - player.GetComponent<PlayerControl>().getVelocityX() * Time.deltaTime, YCorrectionValue * screenHeight, 0);

            if (XCorrectionValue == 0)
                transform.localPosition += new Vector3(player.GetComponent<PlayerControl>().getVelocityX() * -BackgroundSpeed*2, 0, 0);
        }


    }
    private void LateUpdate()
    {
            transform.localPosition += new Vector3(player.GetComponent<PlayerControl>().getVelocityX() * -BackgroundSpeed, 0, 0);
    }
    void GetScreenWH()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }
}
 //transform.localPosition =new Vector3(player.transform.position.x - BackgroundSpeed*Time.time+XCorrectionValue*screenWidth, YCorrectionValue*screenHeight, 0)+ExtraVector;
        //transform.localPosition += new Vector3(BackgroundSpeed * Time.time + XCorrectionValue * screenWidth, YCorrectionValue * screenHeight, 0) + ExtraVector;