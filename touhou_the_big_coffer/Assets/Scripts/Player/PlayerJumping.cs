using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    PlayerMoving playerMoving;
    TheWorld theWorld;
#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile,
   
    private float screenWidth;
    private Vector2 touchPosition;

#endif
    // Start is called before the first frame update
    void Start()
    {
        playerMoving = GetComponent<PlayerMoving>();
        theWorld = GetComponent<TheWorld>();
#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile,
        screenWidth = Screen.width;
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

        if (Input.GetButton("Fire1") )
        {
            if (playerMoving.isPlayerJumped == false && GetComponent<Rigidbody2D>().velocity.y >= -0.5 * theWorld.timeSpeed)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,8 * theWorld.timeSpeed);
                playerMoving.isPlayerJumped = true;
            }
        }

#endif

#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 

        if (Input.touchCount > 0)//判断是否有触摸信息
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];//将触摸信息传递给touch

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)//touch.phase是触摸的相位信息，通过TouchPhase枚举中来确定当前的状态，Began：一个手指开始接触；Moved：一个手指发生了移动；Stationary：一个手指接触了屏幕但是没有发生移动；Ended:一个手指离开屏幕，也是最后的状态；Cnaceled：系统取消对触摸监听，如用户把屏幕放到他脸上或超过五个接触同时发生。
                {
                    touchPosition = touch.position;//获取触摸的位置信息，该坐标与屏幕坐标一致。
                    if (touchPosition.x < screenWidth / 4)//screenWidth在Start中已经赋值=>screenWidth = Screen.width;
                    {
                        if (playerMoving.isPlayerJumped == false && GetComponent<Rigidbody2D>().velocity.y >= -0.5 * theWorld.timeSpeed)
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8 * theWorld.timeSpeed);
                            playerMoving.isPlayerJumped = true;
                        }
                    }
                }
            }
        }

#endif
        if (playerMoving.isPlayerClimbing == false && playerMoving.isPlayerBlocked == true && (playerMoving.isPlayerJumped == true || GetComponent<Rigidbody2D>().velocity.y < -0.5 * theWorld.timeSpeed))
        {
            if (Input.GetButton("Fire1") && playerMoving.isPlayerClimbing == false)
            {
                playerMoving.isPlayerClimbing = true;
                playerMoving.isPlayerJumped = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f * theWorld.timeSpeed);
                Invoke("endClimb", 0.25f/theWorld.timeSpeed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RefleshJump" && playerMoving.isPlayerJumped == true)
        {
            playerMoving.isPlayerJumped = false;
        }
        if (collision.gameObject.name == "ClimbPoint" )
        {
            playerMoving.isPlayerBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ClimbPoint")
        {
            playerMoving.isPlayerBlocked = false;
        }
    }

    private void endClimb()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
        playerMoving.isPlayerClimbing = false;
    }
}
