using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    //public BallSpawn BallSpawner;
    private Vector3 direction;
    public float forwardSpeed, maxSpeed, tempSpeed;

    private int desiredLane = 1;      //0:left, 1:middle, 2:right
    public float laneDistance = 2.0f;    //The distance between two lanes

    private Animation anim;
    public GameObject Player, FireButton, BaseBallBtn;
    public Material Character_Blur, Character;
    public TrackSpawnManager TrackSpawnManager;
    public List<GameObject> TempCoinsHideShow = new List<GameObject>();
    public List<GameObject> FireBallHideShow = new List<GameObject>();
    public List<GameObject> BoxesShow = new List<GameObject>();
     public List<GameObject> CoinShow = new List<GameObject>();

    public bool movement, gameEnd, gamePause;
    public static int score;  
    public static int resetTrack;
    public static float FireBall, FireBall_1,FireBall_2, FireBall_3;
    public Vector3 startPosition, yPos;

    public static int collisionCount, life;//Counting Ball hits
    public static bool restartTemp;
    public static int[] collisionCounts = new int[9];
    GameObject[] Coins;
    GameObject TempRoad;

    //Ball Spawn
    Renderer Mainrend;
    public GameObject SpawnBall;
    public Material Fire_Mat;
    public Material Ball_Mat;

    float seconds;
    public static int tempBall, FireBallActive;
    // public Slider mainSlider;
    // public GameObject mainSliderBar;

 
    void Awake()
    {
        startPosition = transform.position;
        yPos.y = startPosition.y;
        FireBallActive = 0;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();    

        Time.timeScale = 1.2f;
  
        anim = Player.GetComponent<Animation>();
        gameEnd = false;
        gamePause = false;
        resetTrack = 0;
        // speedCount = 0;
        anim.Play("Idle");

        Mainrend = SpawnBall.GetComponent<Renderer>();  

        for(int i = 0; i < collisionCounts.Length; i++)
        {
            collisionCounts[i] = 0;
        }

        Coins = GameObject.FindGameObjectsWithTag("Coin");
         BallSpawn.Ball_Mat =  Ball_Mat;
         seconds = 6.0f;
      //  mainSlider.maxValue = 1.0f;

    }

    void Update()
    {
        TrackSpawnManager.playerPosZ = transform.position.z;  // for obstacles
          tempSpeed = forwardSpeed;


        yPos.x = transform.position.x;  // fixed player's position at y 
        yPos.z = transform.position.z;
        transform.position = yPos;

         if(gamePause == true)
         {
            anim.Play("Idle");
         }

             //Speed increase in each second   // forwardSpeed < maxSpeed &&
         if(forwardSpeed < maxSpeed && movement == true && Game_Manager.restart == false && life == 0 && gameEnd == false && gamePause == false)
         {
                  forwardSpeed += 0.5f * Time.deltaTime; 
                //   anim.speed = anim.speed + 0.1f;
         }
        
        if(Game_Manager.restart == true)
        {
            transform.position = startPosition;

            resetTrack = 1;
            desiredLane = 1;
            forwardSpeed = 13.0f;  //13
            SwipeManager.startTouch = SwipeManager.swipeDelta = Vector2.zero;
            SwipeManager.isDraging = false;

            TrackSpawnManager.TextureUpdate();  // To  update boxes texture 
            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            }
             for (int i = 0; i <  TempCoinsHideShow.Count; i++)
             {
                TempCoinsHideShow[i].SetActive(true);
             }
         
            for (int i = 0; i < FireBallHideShow.Count; i++)
             {
                 FireBallHideShow[i].SetActive(true);
             }
            Game_Manager.restart = false;
        }

        if(Game_Manager.reset == true)
        {
            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            }
            Game_Manager.reset = false;
        }
        //Debug.Log("forwardSpeed = " + forwardSpeed);

        if(life == 1)
        {
            Vector3 tempPosition = transform.position;
            tempPosition.z = tempPosition.z - 8f;
            transform.position = tempPosition;

            for(int i = 0; i < collisionCounts.Length; i++)
            {
               collisionCounts[i] = 0;
            //   Debug.Log("player=>  collisionCounts = " + collisionCounts[i]);
            }
            
           TrackSpawnManager.TextureUpdate();   // To  update boxes texture
            forwardSpeed = tempSpeed;
            // Debug.Log("forwardSpeedlife = " + forwardSpeed);

            Debug.Log("tempRoad" + TempRoad);
         
            Transform[] allChildren = TempRoad.transform.GetComponentsInChildren<Transform>(true);  // Hide Coins
            for(int i=0; i<allChildren.Length; i++)
            {
                Debug.Log("tagObj = " + allChildren[i].gameObject);
                
                if(allChildren[i].gameObject.tag == "Coin" || allChildren[i].gameObject.tag == "Fire1" || allChildren[i].gameObject.tag == "Fire2" || allChildren[i].gameObject.tag == "Fire3")
                {
                    allChildren[i].gameObject.SetActive(false);  
                     Debug.Log("tag = " + allChildren[i].gameObject.tag);
                }
            }
            life = 0;
        }

       Movement();
      
        
        //  while (tempBall != 0)
        //  {
        //      StartCoroutine(FireBallTimerCoroutine()); 
        //      tempBall--;
        //  }

        while (tempBall != 0)
         {
           // mainSlider.value= mainSlider.maxValue;
             StartCoroutine(FireBallTimerCoroutine()); 
           
              tempBall--;
         }

         if(FireBall == 0)
         {
            seconds = 0.0f;
         }
               
    
     
       StartCoroutine(RestartTimerCoroutine());
    }

   private void Movement()
   {
            if(movement != false)
            {
                anim.Play("Run");
            
                direction.z =  forwardSpeed;   
                //Gather the inputs on which lane we should be
                if (SwipeManager.swipeRight)
                {
                    desiredLane++;
                    if (desiredLane == 3)
                        desiredLane = 2;
                }
                if (SwipeManager.swipeLeft)
                {
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                }

                //Calculate where we should be in the future
                Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
                if (desiredLane == 0)
                    targetPosition += Vector3.left * laneDistance;
                else if (desiredLane == 2)
                    targetPosition += Vector3.right * laneDistance;


                if (transform.position != targetPosition)
                {
                    Vector3 diff = targetPosition - transform.position;
                    Vector3 moveDir = diff.normalized * 30.0f * Time.deltaTime; // 30
                    if (moveDir.sqrMagnitude < diff.magnitude)
                        controller.Move(moveDir);
                    else
                        controller.Move(diff);
                }

                controller.Move(direction * Time.deltaTime);
          }
   }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
            if(hit.transform.tag == "Box_1" || hit.transform.tag == "Box_2" || hit.transform.tag == "Box_3" || hit.transform.tag == "Box_4" || hit.transform.tag == "Box_5" ||
            hit.transform.tag == "Box_6" || hit.transform.tag == "Box_7" || hit.transform.tag == "Box_8" || hit.transform.tag == "Box_9" || hit.transform.tag == "Box_10" )
            {
                movement = false;
                gameEnd = true;
       
                if(PlayerPrefs.GetInt("Audio") ==  1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("GameOver"); 
                }
                else{
                    FindObjectOfType<AudioManager>().StopSound("GameOver"); 
                }
                anim.Play("Dizzy");
                TempRoad = hit.transform.parent.gameObject;
                
           }
          
    }
    
    
     // To spawn Track
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SpawnTriger")
        {
             for (int i = 0; i <  TempCoinsHideShow.Count; i++)
             {
                TempCoinsHideShow[i].SetActive(true);
             }
         
            for (int i = 0; i < FireBallHideShow.Count; i++)
             {
                 FireBallHideShow[i].SetActive(true);
             }

            if(TempRoad != null)
            {
                  Transform[] allChildren = TempRoad.transform.GetComponentsInChildren<Transform>(true);
                for(int i=0; i<allChildren.Length; i++)
                {
                    if(allChildren[i].gameObject.tag == "Coin")
                    {
                        allChildren[i].gameObject.SetActive(true);  
                    }
                }
                TempRoad = null;
            }
            
            TrackSpawnManager.TrackSpawnerTriggerEntered();
        }
        else if(other.gameObject.tag == "Coin")
        {
            TempCoinsHideShow.Add(other.gameObject); 
       
                 if(PlayerPrefs.GetInt("Audio") ==  1)
                {
                    FindObjectOfType<AudioManager>().PlaySound("CoinPickUp"); 
                }
                else{
                    FindObjectOfType<AudioManager>().StopSound("CoinPickUp"); 
                }
            other.gameObject.SetActive(false);
            score ++;    
        }
         else if(other.gameObject.tag == "Fire1" || other.gameObject.tag == "Fire2" || other.gameObject.tag == "Fire3")  
        {
            FireBallHideShow.Add(other.gameObject);
            other.gameObject.SetActive(false);
            // FireBall =  FireBall + 1.0f;   
            //  FireBall++;
            //  Debug.Log("FireBall = " + FireBall);
            tempBall++;

             if(other.gameObject.tag == "Fire1")
             {
                     FireBall++; 
                     FireBall_1 ++;
                     // Debug.Log("FireBall_1 = " + FireBall);
             }else if(other.gameObject.tag == "Fire2")
             {
                 FireBall++; 
                 FireBall_2++;
                  //Debug.Log("FireBall_2 = " + FireBall);

             }else if(other.gameObject.tag == "Fire3")
             {
                  FireBall++; 
                  FireBall_3++;
                 // Debug.Log("FireBall_3 = " + FireBall);
             }
             
            // tempBall = Mathf.RoundToInt(FireBall);
             Debug.Log(" FireBallC0 = " +  FireBall);


        }
    }

    // FireBall for spawn for 8 secs


    private IEnumerator FireBallTimerCoroutine()
    {
    
               Mainrend.material = Fire_Mat;
                FireBallActive = 1;
              
                FireButton.SetActive(true);
              //  mainSliderBar.SetActive(true);
                BaseBallBtn.SetActive(false);
    
                //yield return new WaitForSeconds(6.0f);  //1

            seconds = FireBall  * 5.0f;

            for(int i=0; i< seconds; i++)
            {
                yield return new WaitForSeconds(1f);  //1
                //  mainSlider.value -= 0.23f;

                //   if(seconds != 0)
                //   {
                //          mainSlider.value= mainSlider.maxValue;
                //   }

                // if( mainSlider.value <= mainSlider.maxValue)
                // {
                     
               // }

               // seconds = FireBall  * 6.0f;
            }
         
     
            Mainrend.material = Ball_Mat;
             
            FireButton.SetActive(false);
            BaseBallBtn.SetActive(true);
           //  mainSliderBar.SetActive(false);
            FireBallActive = 0;
           // mainSlider.value= mainSlider.maxValue;
  
    }

    private IEnumerator RestartTimerCoroutine()
    {
        if(restartTemp == true)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            for (int i = 0; i <  BoxesShow.Count; i++)
            { 
                BoxesShow[i].GetComponent<BoxCollider>().enabled = false;   
            }
    
            yield return new WaitForSeconds(1); //2  // 2

            for (int i = 0; i <  BoxesShow.Count; i++)  
            { 
                BoxesShow[i].GetComponent<BoxCollider>().enabled = true;   
            }
        }

        restartTemp = false;
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

}

