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

        if(PlayerController.FireBall > 0 )
        {
                gameObject.SetActive(false);
                TextureScoreChange(collision.gameObject);
                if(collision.gameObject.name == "Cube")
                {
                     collision.gameObject.SetActive(false);
                    FireBoxDestroySound();
                }
        }
      else   
        {
                PlayerController.score = PlayerController.score +1;
                int col = TextureColChange(collision.gameObject);  
                Renderer rend = collision.gameObject.GetComponent<Renderer>();  
                col = col -1;  

                 if(col == 0 && collision.gameObject.name == "Cube")
                {
                    collision.gameObject.SetActive(false);
                }  
                else if(col == 1)
                {
                    rend.material.mainTexture = texture[0];
                }  
                else if(col == 2)
                {
                    rend.material.mainTexture = texture[1];
                } else if(col == 3)
                {
                    rend.material.mainTexture = texture[2];
                } else if(col == 4)
                {
                    rend.material.mainTexture = texture[3];
                } else if(col == 5)
                {
                    rend.material.mainTexture = texture[4];
                } else if(col == 6)
                {
                    rend.material.mainTexture = texture[5];

                } else if(col == 7)
                {
                    rend.material.mainTexture = texture[6];

                } else if(col == 8)
                {
                    rend.material.mainTexture = texture[7];

                } else if(col == 9)
                {
                    rend.material.mainTexture = texture[8];
                } else if(col == 10)
                {
                    rend.material.mainTexture = texture[9];
                }

                if(collision.gameObject.name == "Cube")
                {
                      BoxDestroySound();
                }
        }
       
          gameObject.SetActive(false);
    }

     public void BoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)
        {
            FindObjectOfType<AudioManager>().PlaySound("BoxDestroy"); 
        }
    }

     public void FireBoxDestroySound()
    {
         if(PlayerPrefs.GetInt("Audio") ==  1)
        {
            FindObjectOfType<AudioManager>().PlaySound("FireExplosion"); 
        }
    }

    public int TextureColChange(GameObject col)
    {
        int number =0;
        Renderer rend = col.GetComponent<Renderer>();  
          for(int m = 0; m < texture.Count; m++)
          {
              if(rend.material.mainTexture == texture[m])  
                {
                   number = m+1;
                }
          }
        return number;
    }

    public void TextureScoreChange(GameObject col)
    {
       if(col.tag == "Box_1")
       {
          PlayerController.score = PlayerController.score + 1;
       }else if(col.tag == "Box_2")
       {
          PlayerController.score = PlayerController.score + 2;
       }else if(col.tag == "Box_3")
       {
         PlayerController.score = PlayerController.score + 3;
       }else if(col.tag == "Box_4")
       {
         PlayerController.score = PlayerController.score + 4;
       }else if(col.tag == "Box_5")
       {
          PlayerController.score = PlayerController.score + 5;
       }else if(col.tag == "Box_6")
       {
          PlayerController.score = PlayerController.score + 6;
       }else if(col.tag == "Box_7")
       {
          PlayerController.score = PlayerController.score + 7;
       }else if(col.tag == "Box_8")
       {
          PlayerController.score = PlayerController.score + 8;
       }else if(col.tag == "Box_9")
       {
          PlayerController.score = PlayerController.score + 9;
       }else if(col.tag == "Box_10")
       {
          PlayerController.score = PlayerController.score + 10;
       }
    }

}
