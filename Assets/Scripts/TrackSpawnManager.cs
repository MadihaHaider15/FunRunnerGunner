using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawnManager : MonoBehaviour
{
   TrackSpawner TrackSpawner;
   public Game_Manager Game_Manager;
   public float playerPosZ; 
   public int AmpliBox;

    void Start()
    {
        TrackSpawner = GetComponent<TrackSpawner>();
    }

     void Update()
    {
      if(PlayerController.resetTrack == 1)
      {
         TrackSpawner.TrackPosStored();
         PlayerController.resetTrack = 0;
      }    
       TrackSpawner.z = playerPosZ;
    }

    public void TrackSpawnerTriggerEntered()
    {
       TrackSpawner.MoveTrack();
    }

    public void TextureUpdate()
    {
      Debug.Log("Texture update from track spawner");
      TrackSpawner.TextureChange();
    }
}
