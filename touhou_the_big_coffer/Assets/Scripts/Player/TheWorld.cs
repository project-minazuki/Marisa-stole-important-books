using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    public float timeSpeed = 0f;

    PlayerMoving playerMoving;
    Rigidbody2D rigidbody2D;

    private float gravity;
    private bool theWorldStart = false;
    private bool theWorldEnd = false;

#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile,

    private float screenWidth;
    private Vector2 touchPosition;

#endif

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile,
        screenWidth = Screen.width;
#endif
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

        if (Input.GetButton("Fire2"))
        {
            if (!theWorldStart)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 0.1f);
                theWorldStart = true;
            }
            theWorldEnd = false;
            timeSpeed = 0.1f;
            rigidbody2D.gravityScale = 0.01f * gravity;
        }
        else
        {
            if (!theWorldEnd)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 10f);
                theWorldEnd = true;
            }
            theWorldStart = false;
            timeSpeed = 1.0f;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }

#endif

#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 
        bool flag = false;
        if (Input.touchCount > 0)//判断是否有触摸信息
        {
            
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];//将触摸信息传递给touch

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)//touch.phase是触摸的相位信息，通过TouchPhase枚举中来确定当前的状态，Began：一个手指开始接触；Moved：一个手指发生了移动；Stationary：一个手指接触了屏幕但是没有发生移动；Ended:一个手指离开屏幕，也是最后的状态；Cnaceled：系统取消对触摸监听，如用户把屏幕放到他脸上或超过五个接触同时发生。
                {
                    touchPosition = touch.position;//获取触摸的位置信息，该坐标与屏幕坐标一致。
                    if (touchPosition.x > screenWidth * 3 / 4)//screenWidth在Start中已经赋值=>screenWidth = Screen.width;
                    {
                        flag = true;
                        if (!theWorldStart)
                        {
                            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 0.1f);
                            theWorldStart = true;
                        }
                        theWorldEnd = false;
                        timeSpeed = 0.1f;
                        rigidbody2D.gravityScale = 0.01f * gravity;
                    }
                }
            }
        }
        if (flag == false)
        {
            if (!theWorldEnd)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 10f);
                theWorldEnd = true;
            }
            theWorldStart = false;
            timeSpeed = 1.0f;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }

#endif
    }
}
