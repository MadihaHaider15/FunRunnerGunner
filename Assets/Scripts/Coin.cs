using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

     private Rigidbody rb;
     private TrackSpawnManager TrackSpawnManager;
  //   private Vector3 target;
   //  public float speed = 1000.0f;

   float tempval;

    
     void Start()
    {
        rb = GetComponent<Rigidbody>();
       // tempval = -6f;
       // target = new Vector3(0.0f, 0.0f, -0.0f);
    }

    void FixedUpdate()
    {
        transform.Rotate(1f,0,0);
     //   var step =  speed * Time.deltaTime; // calculate distance to move
        //transform.position += Vector3.back * Time.deltaTime;
       // transform.position += new Vector3(0, 0, -9f)  * Time.deltaTime;   // -6
        //tempval += 0.05f;
    }
}
