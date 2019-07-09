using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float timeSpeed = 0f;
    public float dashSpeed;
    public float leftClimbingTime = 15;
    public float range = 10f;
    public float test = 0f;

    PlayerMoving playerMoving;
    new Rigidbody2D rigidbody2D;
    Ray dashRay = new Ray();
    RaycastHit rayHit;
    ParticleSystem rayParticles;
    LineRenderer line;
    int dashableMask = 0;
    CameraFollow cameraFollow;

    private float gravity;
    private bool theWorldStart = false;
    private bool theWorldEnd = false;
    private RaycastHit hit;
    private Ray ray;
    private float keyHoldTime = 0;
    private GameObject particle;
    Score score;

#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR  //if current platform is mobile,

    private Vector2 startPosition;
    private float screenWidth;
    private Vector2 touchPosition;

#endif

    void Awake()
    {
        particle = gameObject.transform.GetChild(0).gameObject;
        // Set up the references.
        rayParticles = particle.GetComponent<ParticleSystem>();
        line = particle.GetComponent<LineRenderer>();
        //faceLight = GetComponentInChildren<Light> ();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            score = gameControllerObject.GetComponent<Score>();
        }
        if (score == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GameObject cameraFollowObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraFollowObject != null)
        {
            cameraFollow = cameraFollowObject.GetComponent<CameraFollow>();
        }
        if (cameraFollowObject == null)
        {
            Debug.Log("Cannot find 'cameraFollow' script");
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
        gravity = rigidbody2D.gravityScale;
        playerMoving = GetComponent<PlayerMoving>();

#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR //if current platform is mobile,

        screenWidth = Screen.width;

#endif

    }

    // Update is called once per frame
    void Update()
    {
        test = getVelocityX(); 
#if UNITY_IOS || UNITY_ANDROID || UNITY_EDITOR //if current platform is mobile, 

        bool flag1 = false;

#if UNITY_IOS || UNITY_ANDROID

        if (Input.touchCount > 0 && !playerMoving.isPlayerDashing)//判断是否有触摸信息
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];//将触摸信息传递给touch

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended)//touch.phase是触摸的相位信息，通过TouchPhase枚举中来确定当前的状态，Began：一个手指开始接触；Moved：一个手指发生了移动；Stationary：一个手指接触了屏幕但是没有发生移动；Ended:一个手指离开屏幕，也是最后的状态；Cnaceled：系统取消对触摸监听，如用户把屏幕放到他脸上或超过五个接触同时发生
                {
                    touchPosition = touch.position;//获取触摸的位置信息，该坐标与屏幕坐标一致
                    if (touchPosition.x < screenWidth / 3)//screenWidth在Start中已经赋值=>screenWidth = Screen.width
                    {
                        if (playerMoving.isPlayerJumped == false && GetComponent<Rigidbody2D>().velocity.y >= -0.5 * timeSpeed)
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8 * timeSpeed);
                            playerMoving.isPlayerJumped = true;
                        }
                        if (playerMoving.isPlayerClimbing == false && playerMoving.isPlayerBlocked == true && (playerMoving.isPlayerJumped == true || GetComponent<Rigidbody2D>().velocity.y < -0.5 * timeSpeed))
                        {
                            if (playerMoving.isPlayerClimbing == false)
                            {
                                playerMoving.isPlayerClimbing = true;
                                playerMoving.isPlayerJumped = true;
                                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f * timeSpeed);
                            }
                        }
                    }
                    if (touchPosition.x > screenWidth * 2 / 3)//screenWidth在Start中已经赋值=>screenWidth = Screen.width;
                    {
                        if (touch.phase == TouchPhase.Stationary || Vector2.Distance(startPosition, touchPosition) < 50)
                        {
                            keyHoldTime++;
                        }
                        if (touch.phase == TouchPhase.Began)
                        {
                            startPosition = touchPosition;
                        }
                        if ((touch.phase == TouchPhase.Stationary || theWorldStart) && keyHoldTime >= 10)
                        {
                            cameraFollow.zoomIn();
                            flag1 = true;
                            if (Vector2.Distance(startPosition, touchPosition) > 50 && playerMoving.isPlayerDashed == false && startPosition.x < touchPosition.x)
                            {
                                Line();
                            }
                            else
                            {
                                DisableEffects();
                            }
                            if (!theWorldStart)
                            {
                                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 0.05f);
                                theWorldStart = true;
                            }
                            theWorldEnd = false;
                            timeSpeed = 0.05f;
                            rigidbody2D.gravityScale = 0.0025f * gravity;
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            keyHoldTime = 0;                         
                            if (Vector2.Distance(startPosition, touchPosition) > 50 && playerMoving.isPlayerDashed == false && startPosition.x < touchPosition.x)
                            {
                                dash();
                            }
                            startPosition = Vector2.zero;
                        }
                    }
                  
                }
            }
        }

#endif

#if UNITY_EDITOR

        if (Input.GetButton("Fire1") && !playerMoving.isPlayerDashing)
        {
            if (playerMoving.isPlayerJumped == false && GetComponent<Rigidbody2D>().velocity.y >= -0.5 * timeSpeed)
            {
                playerMoving.isPlayerDashed = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8 * timeSpeed);
                playerMoving.isPlayerJumped = true;
            }
        }
        if (Input.GetButton("Fire2") && !playerMoving.isPlayerDashing)
        {
            keyHoldTime++;
            if(keyHoldTime >= 10)
            {
                //Debug.Log("TimeStop");
                //if (Vector2.Distance(new Vector2(Input.mousePosition.x,Input.mousePosition.y) ,new Vector2(transform.position.x ,transform.position.y))>100)
                //{
                //    Line();    //显示指示线
                //}
                cameraFollow.zoomIn();
                flag1 = true;
                if (!theWorldStart)
                {
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 0.05f);
                    theWorldStart = true;
                }
                theWorldEnd = false;
                timeSpeed = 0.05f;
                rigidbody2D.gravityScale = 0.0025f * gravity;
            }
        }

        if (Input.GetButtonUp("Fire2") && !playerMoving.isPlayerDashing)
        {
            keyHoldTime = 0;
            if (playerMoving.isPlayerDashed == false )//&& (Vector2.Distance(new Vector2(Input.mousePosition.x, Input.mousePosition.y), new Vector2(transform.position.x, transform.position.y)) > 100))
            {
                playerMoving.isPlayerDashed = true;
                Debug.Log("Dash");
                DisableEffects();
                //dash();
            }  
        }
        if (playerMoving.isPlayerClimbing == false && playerMoving.isPlayerBlocked == true && (playerMoving.isPlayerJumped == true || GetComponent<Rigidbody2D>().velocity.y < -0.5 * timeSpeed))
        {
            if (Input.GetButton("Fire1") && playerMoving.isPlayerClimbing == false && !playerMoving.isPlayerDashing)
            {
                playerMoving.isPlayerClimbing = true;
                playerMoving.isPlayerJumped = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 8f * timeSpeed);
            }
        }

#endif

        if (flag1 == false)
        {
            cameraFollow.zoomOut();
            if (!theWorldEnd)
            {
                if(!playerMoving.isPlayerDashing) rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y * 20f);
                theWorldEnd = true;
                
            }
            theWorldStart = false;
            timeSpeed = 1.0f;
            GetComponent<Rigidbody2D>().gravityScale = gravity;
        }
        if (playerMoving.isPlayerClimbing == true)
        {
            if ((leftClimbingTime -= (timeSpeed)) <= 0 || playerMoving.isPlayerDashing) endClimb();
        }

#endif

    }

    //修改******
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RefleshJump")
        {
            playerMoving.isPlayerDashed = false;
            playerMoving.isPlayerJumped = false;
        }
        if (collision.gameObject.name == "ClimbPoint")
        {
            playerMoving.isPlayerBlocked = true;
        }
        if (collision.gameObject.name == "Down")
        {
            playerMoving.isPlayerdown = true;
        }
        if (collision.gameObject.name == "Up")
        {
            playerMoving.isPlayerUp = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ClimbPoint")
        {
            playerMoving.isPlayerBlocked = false;
        }
        if (collision.gameObject.name == "Down")
        {
            playerMoving.isPlayerdown = false;
        }
        if (collision.gameObject.name == "Up")
        {
            playerMoving.isPlayerUp = false;
        }
    }
    //******修改

    private void endClimb()
    {
        leftClimbingTime = 18;
        if (!playerMoving.isPlayerDashing) GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
        playerMoving.isPlayerClimbing = false;
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        line.enabled = false;
    }

    private void dash()
    {
        playerMoving.isPlayerDashing = true;
        playerMoving.isPlayerDashed = true;
        DisableEffects();

#if UNITY_IOS || UNITY_ANDROID

        GetComponent<Rigidbody2D>().velocity = new Vector2(touchPosition.x - startPosition.x, touchPosition.y - startPosition.y).normalized * 12;

#endif

        Invoke("endDash", 1/6f);

    }

    private void endDash()
    {
        leftClimbingTime = 18;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0f);
        playerMoving.isPlayerDashing = false;
    }

    private void Line()
    {
        // Stop the particles from playing if they were, then start the particles.
        rayParticles.Stop();
        rayParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
        line.enabled = true;
        line.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        dashRay.origin = transform.position;

#if UNITY_EDITOR

        dashRay.direction = new Vector3(Input.mousePosition.x - transform.position.x,Input.mousePosition.y - transform.position.y, 0);

#endif

#if UNITY_IOS || UNITY_ANDROID

        dashRay.direction = new Vector3(touchPosition.x - startPosition.x, touchPosition.y - startPosition.y, 0);

#endif

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(dashRay, out rayHit, range, dashableMask))
        {
            // Set the second position of the line renderer to the point the raycast hit.
            line.SetPosition(1, rayHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            line.SetPosition(1, dashRay.origin + dashRay.direction * range);
        }
    }

    public float getVelocityX()
    {
        float tmp = 0f;
        if (!playerMoving.isPlayerBlocked) tmp = timeSpeed * 3 * Time.deltaTime;

        return (tmp + rigidbody2D.velocity.x/60) ;
    }
}
