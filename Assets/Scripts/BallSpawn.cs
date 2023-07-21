using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public PlayerController PlayerController;
    [SerializeField] float Force = 50f;   // 45f
    Rigidbody rb;
    Renderer Mainrend;
    public List<Texture> texture;
    public Material Ball_Mat;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Mainrend = rb.GetComponent<Renderer>();
        rb.AddForce(transform.forward * Force, ForceMode.Impulse);
    }

    void Update()
    {
         Time.timeScale = 1.2f;
         if(PlayerController.FireBall == 0)
         {
             Mainrend.material = Ball_Mat;
         }
    }

    void OnCollisionEnter(Collision collision)
    {     
        if(collision.gameObject.tag == "Box_1") 
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

            if(PlayerController.FireBall > 0 )
            {
                FireBoxDestroySound();
            }
            else{
                BoxDestroySound();
            }
            PlayerController.score = PlayerController.score +1;
            PlayerController.collisionCounts[0] = 0;
        }
        else if(collision.gameObject.tag == "Box_2") 
        {
            if( PlayerController.FireBall > 0 )   
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                FireBoxDestroySound();
                PlayerController.collisionCounts[1] = 0;
                PlayerController.score = PlayerController.score +2;
          
            }
            if( PlayerController.FireBall == 0 )   
            {
               
                Renderer rend = collision.gameObject.GetComponent<Renderer>();  
                PlayerController.collisionCounts[1] = PlayerController.collisionCounts[1] + 1; 
        
                rend.material.mainTexture = texture[0];
                if(PlayerController.collisionCounts[1] == 2)
                {
                    collision.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    BoxDestroySound();
                    PlayerController.score = PlayerController.score +2;
                    Debug.Log(PlayerController.score);
                    PlayerController.collisionCounts[1] = 0;
                   
                }
            }

        }
          else if(collision.gameObject.tag == "Box_3") 
        { 
            if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                 FireBoxDestroySound();
                PlayerController.collisionCounts[2] = 0;
                PlayerController.score = PlayerController.score +3;
           }
            if( PlayerController.FireBall == 0 )   
            {
                     Renderer rend = collision.gameObject.GetComponent<Renderer>();
                
                      PlayerController.collisionCounts[2] =  PlayerController.collisionCounts[2] + 1;
            
                     if(PlayerController.collisionCounts[2] == 0)  
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[2] == 1)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[2] == 2)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[2] == 3)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                         BoxDestroySound();
                        PlayerController.score = PlayerController.score +3;
                         PlayerController.collisionCounts[2] =  0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_4") 
        {
           
            if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                 FireBoxDestroySound();
                PlayerController.collisionCounts[3] = 0;
                PlayerController.score = PlayerController.score +4;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                  
                     PlayerController.collisionCounts[3] =  PlayerController.collisionCounts[3] + 1;

                    if(PlayerController.collisionCounts[3] == 0)  
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[3] == 1)
                    {
                        rend.material.mainTexture = texture[2];   
                    }
                    if(PlayerController.collisionCounts[3] == 2)
                    {
                        rend.material.mainTexture = texture[1];   
                    }
                    if(PlayerController.collisionCounts[3] == 3)
                    {
                        rend.material.mainTexture = texture[0];  
                    }

                    if(PlayerController.collisionCounts[3] == 4)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                         BoxDestroySound();
                          PlayerController.score = PlayerController.score +4;
                        PlayerController.collisionCounts[3] = 0;
                    }

           }
    
        }
        else if(collision.gameObject.tag == "Box_5") 
        {

             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                 FireBoxDestroySound();
                PlayerController.collisionCounts[4] = 0;
                PlayerController.score = PlayerController.score + 5;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
            
                      PlayerController.collisionCounts[4] =  PlayerController.collisionCounts[4] + 1;

                    if(PlayerController.collisionCounts[4] == 0)  
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[4] == 1)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[4] == 2)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[4] == 3)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[4] == 4)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[4] == 5)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        BoxDestroySound();
                         PlayerController.score = PlayerController.score + 5;
                        PlayerController.collisionCounts[4] = 0;
                    }

           }
           
        }
        else if(collision.gameObject.tag == "Box_6") 
        {
            
             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                FireBoxDestroySound();
                PlayerController.collisionCounts[5] = 0;
                PlayerController.score = PlayerController.score + 6;
           }
            if( PlayerController.FireBall == 0 )   
            {
                     Renderer rend = collision.gameObject.GetComponent<Renderer>();
                      PlayerController.collisionCounts[5] =   PlayerController.collisionCounts[5] + 1;
                    
                    if(PlayerController.collisionCounts[5] == 0)  
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[5] == 1)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[5] == 2)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[5] == 3)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[5] == 4)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[5] == 5)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[5] == 6)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                         BoxDestroySound();
                         PlayerController.score = PlayerController.score + 6;
                         PlayerController.collisionCounts[5] = 0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_7") 
        {

             
             if( PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                FireBoxDestroySound();
                PlayerController.collisionCounts[6] = 0;
                PlayerController.score = PlayerController.score + 7;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
    
                       PlayerController.collisionCounts[6] =   PlayerController.collisionCounts[6] + 1;
                    
                    if(PlayerController.collisionCounts[6] == 0)  
                    {
                        rend.material.mainTexture = texture[6];
                    }
                    if(PlayerController.collisionCounts[6] == 1)
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[6] == 2)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[6] == 3)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[6] == 4)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[6] == 5)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[6] == 6)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[6] == 7)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                        BoxDestroySound();
                        PlayerController.score = PlayerController.score + 7;
                        PlayerController.collisionCounts[6] = 0;
                    }

           }
        }
        else if(collision.gameObject.tag == "Box_8") 
        {
             if(PlayerController.FireBall > 0)
           {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                FireBoxDestroySound();
                PlayerController.collisionCounts[7] = 0;
                PlayerController.score = PlayerController.score + 8;
           }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                   PlayerController.collisionCounts[7] =  PlayerController.collisionCounts[7] + 1;
                    
                    if(PlayerController.collisionCounts[7] == 0)  
                    {
                        rend.material.mainTexture = texture[7];   // 8
                    }
                    if(PlayerController.collisionCounts[7] == 1)
                    {
                        rend.material.mainTexture = texture[6];  //7 
                    }
                    if(PlayerController.collisionCounts[7] == 2)
                    {
                        rend.material.mainTexture = texture[5];   // 6
                    }
                    if(PlayerController.collisionCounts[7] == 3)
                    {
                        rend.material.mainTexture = texture[4];   // 5
                    }
                    if(PlayerController.collisionCounts[7] == 4)
                    {
                        rend.material.mainTexture = texture[3];  // 4
                    }
                    if(PlayerController.collisionCounts[7] == 5)
                    {
                        rend.material.mainTexture = texture[2]; // 3
                    }
                    if(PlayerController.collisionCounts[7] == 6)
                    {
                        rend.material.mainTexture = texture[1];  // 2
                    }
                    if(PlayerController.collisionCounts[7] == 7)
                    {
                        rend.material.mainTexture = texture[0]; // 1
                    }

                    if(PlayerController.collisionCounts[7] == 8)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                         BoxDestroySound();
                           PlayerController.score = PlayerController.score + 8;
                         PlayerController.collisionCounts[7] = 0;
                    }
           }
           
        }
        else if(collision.gameObject.tag == "Box_9") 
        {
            if( PlayerController.FireBall > 0)
            {
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                 FireBoxDestroySound();
                PlayerController.collisionCounts[8] = 0;
                PlayerController.score = PlayerController.score + 9;
            }
            if( PlayerController.FireBall == 0 )   
            {
                    Renderer rend = collision.gameObject.GetComponent<Renderer>();
                    PlayerController.collisionCounts[8] =  PlayerController.collisionCounts[8] + 1;
                    
                    if(PlayerController.collisionCounts[8] == 0)  
                    {
                        rend.material.mainTexture = texture[8];
                    }
                    if(PlayerController.collisionCounts[8] == 1)
                    {
                        rend.material.mainTexture = texture[7];
                    }
                    if(PlayerController.collisionCounts[8] == 2)
                    {
                        rend.material.mainTexture = texture[6];
                    }
                    if(PlayerController.collisionCounts[8] == 3)
                    {
                        rend.material.mainTexture = texture[5];
                    }
                    if(PlayerController.collisionCounts[8] == 4)
                    {
                        rend.material.mainTexture = texture[4];
                    }
                    if(PlayerController.collisionCounts[8] == 5)
                    {
                        rend.material.mainTexture = texture[3];
                    }
                    if(PlayerController.collisionCounts[8] == 6)
                    {
                        rend.material.mainTexture = texture[2];
                    }
                    if(PlayerController.collisionCounts[8] == 7)
                    {
                        rend.material.mainTexture = texture[1];
                    }
                    if(PlayerController.collisionCounts[8] == 8)
                    {
                        rend.material.mainTexture = texture[0];
                    }

                    if(PlayerController.collisionCounts[8] == 9)
                    {
                        collision.gameObject.SetActive(false);
                        gameObject.SetActive(false);
                         BoxDestroySound();
                        PlayerController.score = PlayerController.score + 9;
                        PlayerController.collisionCounts[8] = 0;
                    }
           }

        }
        // else if(collision.gameObject.tag == "Box_10") 
        // {
        //     if( PlayerController.FireBall > 0)
        //     {
        //         collision.gameObject.SetActive(false);
        //         gameObject.SetActive(false);
        //         FireBoxDestroySound();
        //          PlayerController.collisionCounts[10] = 0;
        //          PlayerController.score = PlayerController.score + 11;
        //     }
        //     if( PlayerController.FireBall == 0 )   
        //     {
        //                Renderer rend = collision.gameObject.GetComponent<Renderer>();
        //                 PlayerController.collisionCounts[10] =  PlayerController.collisionCounts[10] + 1;
                        
        //                 if(PlayerController.collisionCounts[10] == 0)  
        //                 {
        //                     rend.material.mainTexture = texture[10];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 1)
        //                 {
        //                     rend.material.mainTexture = texture[9];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 2)
        //                 {
        //                     rend.material.mainTexture = texture[8];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 3)
        //                 {
        //                     rend.material.mainTexture = texture[7];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 4)
        //                 {
        //                     rend.material.mainTexture = texture[6];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 5)
        //                 {
        //                     rend.material.mainTexture = texture[5];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 6)
        //                 {
        //                     rend.material.mainTexture = texture[4];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 7)
        //                 {
        //                     rend.material.mainTexture = texture[3];
        //                 }
        //                 if(PlayerController.collisionCounts[10] == 8)
        //                 {
        //                     rend.material.mainTexture = texture[2];
        //                 }

        //                 if(PlayerController.collisionCounts[10] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[1];
        //                 }  
        //                  if(PlayerController.collisionCounts[10] == 10)
        //                 {
        //                     rend.material.mainTexture = texture[0];
        //                 }  

        //                 if(PlayerController.collisionCounts[10] == 11)
        //                 {
        //                     collision.gameObject.SetActive(false);
        //                     gameObject.SetActive(false);
        //                     BoxDestroySound();
        //                     PlayerController.score = PlayerController.score + 11;
        //                     PlayerController.collisionCounts[10] = 0;
        //                 }
        //     }
        //}
        // else if(collision.gameObject.tag == "Box_11") //Changes
        // {
        //     if( PlayerController.FireBall > 0)
        //     {
        //         collision.gameObject.SetActive(false);
        //         gameObject.SetActive(false);
        //         FireBoxDestroySound();
        //          PlayerController.collisionCounts[11] = 0;
        //          PlayerController.score = PlayerController.score + 12;
        //     }
        //     if( PlayerController.FireBall == 0 )   
        //     {
        //                Renderer rend = collision.gameObject.GetComponent<Renderer>();
        //                 PlayerController.collisionCounts[11] =  PlayerController.collisionCounts[11] + 1;
                        
        //                 if(PlayerController.collisionCounts[11] == 0)  
        //                 {
        //                     rend.material.mainTexture = texture[11];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 1)
        //                 {
        //                     rend.material.mainTexture = texture[10];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 2)
        //                 {
        //                     rend.material.mainTexture = texture[9];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 3)
        //                 {
        //                     rend.material.mainTexture = texture[8];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 4)
        //                 {
        //                     rend.material.mainTexture = texture[7];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 5)
        //                 {
        //                     rend.material.mainTexture = texture[6];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 6)
        //                 {
        //                     rend.material.mainTexture = texture[5];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 7)
        //                 {
        //                     rend.material.mainTexture = texture[4];
        //                 }
        //                 if(PlayerController.collisionCounts[11] == 8)
        //                 {
        //                     rend.material.mainTexture = texture[3];
        //                 }

        //                 if(PlayerController.collisionCounts[11] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[2];
        //                 }  
        //                  if(PlayerController.collisionCounts[11] == 10)
        //                 {
        //                     rend.material.mainTexture = texture[1];
        //                 }
        //                   if(PlayerController.collisionCounts[11] == 11)
        //                 {
        //                     rend.material.mainTexture = texture[0];
        //                 }  

        //                 if(PlayerController.collisionCounts[11] == 12)
        //                 {
        //                     collision.gameObject.SetActive(false);
        //                     gameObject.SetActive(false);
        //                     BoxDestroySound();
        //                     PlayerController.score = PlayerController.score + 12;
        //                     PlayerController.collisionCounts[11] = 0;
        //                 }
        //     }
        // }
        // else if(collision.gameObject.tag == "Box_12") 
        // {
        //     if( PlayerController.FireBall > 0)
        //     {
        //         collision.gameObject.SetActive(false);
        //         gameObject.SetActive(false);
        //         FireBoxDestroySound();
        //          PlayerController.collisionCounts[12] = 0;
        //          PlayerController.score = PlayerController.score + 13;
        //     }
        //     if( PlayerController.FireBall == 0 )   
        //     {
        //                Renderer rend = collision.gameObject.GetComponent<Renderer>();
        //                 PlayerController.collisionCounts[12] =  PlayerController.collisionCounts[12] + 1;
                        
        //                 if(PlayerController.collisionCounts[12] == 0)  
        //                 {
        //                     rend.material.mainTexture = texture[12];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 1)
        //                 {
        //                     rend.material.mainTexture = texture[11];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 2)
        //                 {
        //                     rend.material.mainTexture = texture[10];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 3)
        //                 {
        //                     rend.material.mainTexture = texture[9];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 4)
        //                 {
        //                     rend.material.mainTexture = texture[8];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 5)
        //                 {
        //                     rend.material.mainTexture = texture[7];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 6)
        //                 {
        //                     rend.material.mainTexture = texture[6];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 7)
        //                 {
        //                     rend.material.mainTexture = texture[5];
        //                 }
        //                 if(PlayerController.collisionCounts[12] == 8)
        //                 {
        //                     rend.material.mainTexture = texture[4];
        //                 }

        //                 if(PlayerController.collisionCounts[12] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[3];
        //                 }  
        //                  if(PlayerController.collisionCounts[12] == 10)
        //                 {
        //                     rend.material.mainTexture = texture[2];
        //                 }  
        //                  if(PlayerController.collisionCounts[12] == 11)
        //                 {
        //                     rend.material.mainTexture = texture[1];
        //                 }  
        //                  if(PlayerController.collisionCounts[12] == 12)
        //                 {
        //                     rend.material.mainTexture = texture[0];
        //                 }  

        //                 if(PlayerController.collisionCounts[12] == 13)
        //                 {
        //                     collision.gameObject.SetActive(false);
        //                     gameObject.SetActive(false);
        //                     BoxDestroySound();
        //                     PlayerController.score = PlayerController.score + 13;
        //                     PlayerController.collisionCounts[12] = 0;
        //                 }
        //     }
        // }
        // else if(collision.gameObject.tag == "Box_13") 
        // {
        //     if( PlayerController.FireBall > 0)
        //     {
        //         collision.gameObject.SetActive(false);
        //         gameObject.SetActive(false);
        //         FireBoxDestroySound();
        //          PlayerController.collisionCounts[13] = 0;
        //          PlayerController.score = PlayerController.score + 14;
        //     }
        //     if( PlayerController.FireBall == 0 )   
        //     {
        //                Renderer rend = collision.gameObject.GetComponent<Renderer>();
        //                 PlayerController.collisionCounts[13] =  PlayerController.collisionCounts[13] + 1;
                        
        //                 if(PlayerController.collisionCounts[13] == 0)  
        //                 {
        //                     rend.material.mainTexture = texture[13];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 1)
        //                 {
        //                     rend.material.mainTexture = texture[12];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 2)
        //                 {
        //                     rend.material.mainTexture = texture[11];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 3)
        //                 {
        //                     rend.material.mainTexture = texture[10];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 4)
        //                 {
        //                     rend.material.mainTexture = texture[9];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 5)
        //                 {
        //                     rend.material.mainTexture = texture[8];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 6)
        //                 {
        //                     rend.material.mainTexture = texture[7];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 7)
        //                 {
        //                     rend.material.mainTexture = texture[6];
        //                 }
        //                 if(PlayerController.collisionCounts[13] == 8)
        //                 {
        //                     rend.material.mainTexture = texture[5];
        //                 }

        //                 if(PlayerController.collisionCounts[13] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[4];
        //                 }  
        //                   if(PlayerController.collisionCounts[13] == 10)
        //                 {
        //                     rend.material.mainTexture = texture[3];
        //                 }  
        //                   if(PlayerController.collisionCounts[13] == 11)
        //                 {
        //                     rend.material.mainTexture = texture[2];
        //                 }  
        //                   if(PlayerController.collisionCounts[13] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[1];
        //                 }  
        //                   if(PlayerController.collisionCounts[13] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[0];
        //                 }  

        //                 if(PlayerController.collisionCounts[13] == 14)
        //                 {
        //                     collision.gameObject.SetActive(false);
        //                     gameObject.SetActive(false);
        //                     BoxDestroySound();
        //                     PlayerController.score = PlayerController.score + 14;
        //                     PlayerController.collisionCounts[13] = 0;
        //                 }
        //     }
        // }
        // else if(collision.gameObject.tag == "Box_14") 
        // {
        //     if( PlayerController.FireBall > 0)
        //     {
        //         collision.gameObject.SetActive(false);
        //         gameObject.SetActive(false);
        //         FireBoxDestroySound();
        //          PlayerController.collisionCounts[14] = 0;
        //          PlayerController.score = PlayerController.score + 10;
        //     }
        //     if( PlayerController.FireBall == 0 )   
        //     {
        //                Renderer rend = collision.gameObject.GetComponent<Renderer>();
        //                 PlayerController.collisionCounts[14] =  PlayerController.collisionCounts[14] + 1;
                        
        //                 if(PlayerController.collisionCounts[14] == 0)  
        //                 {
        //                     rend.material.mainTexture = texture[9];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 1)
        //                 {
        //                     rend.material.mainTexture = texture[8];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 2)
        //                 {
        //                     rend.material.mainTexture = texture[7];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 3)
        //                 {
        //                     rend.material.mainTexture = texture[6];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 4)
        //                 {
        //                     rend.material.mainTexture = texture[5];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 5)
        //                 {
        //                     rend.material.mainTexture = texture[4];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 6)
        //                 {
        //                     rend.material.mainTexture = texture[3];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 7)
        //                 {
        //                     rend.material.mainTexture = texture[2];
        //                 }
        //                 if(PlayerController.collisionCounts[14] == 8)
        //                 {
        //                     rend.material.mainTexture = texture[1];
        //                 }

        //                 if(PlayerController.collisionCounts[14] == 9)
        //                 {
        //                     rend.material.mainTexture = texture[0];
        //                 }  

        //                 if(PlayerController.collisionCounts[14] == 10)
        //                 {
        //                     collision.gameObject.SetActive(false);
        //                     gameObject.SetActive(false);
        //                     BoxDestroySound();
        //                     PlayerController.score = PlayerController.score + 10;
        //                     PlayerController.collisionCounts[14] = 0;
        //                 }
        //     }
        // }
        
        else{
            gameObject.SetActive(false);
        }


        if(collision.gameObject.tag == "Enemy") 
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

     public void BoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)//Game_Manager.AudioSprite == Game_Manager.mic_On
        {
            FindObjectOfType<AudioManager>().PlaySound("BoxDestroy"); 
        }
        else{
                FindObjectOfType<AudioManager>().StopSound("BoxDestroy"); 
        }
    }

     public void FireBoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)
        {
            FindObjectOfType<AudioManager>().PlaySound("FireExplosion"); 
        }
        else{
                FindObjectOfType<AudioManager>().StopSound("FireExplosion"); 
        }
    }

}
