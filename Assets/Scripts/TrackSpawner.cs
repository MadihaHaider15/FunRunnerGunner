using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public List<GameObject> tracks = new List<GameObject>();
    public List<GameObject> tracksTemp = new List<GameObject>();
     public List<int> TempNumArr = new List<int>();
  
    public GameObject spawnTriger;
    GameObject movedTrack;
    public Vector3 startTrackPosition;
    public Vector3 startTrack0Position;
    public Vector3 startTrack1Position;
    public Vector3 startTrack2Position;
    public Vector3 startTrack3Position;

    private float offset = 60f;

    public List<Texture> texture;
    [SerializeField] GameObject ObstacleSpawn;
    public float x;
    public float z;
    public int boxCount = 0;
 
   
    void Awake()
    {
        startTrackPosition = transform.position;
    
        startTrack0Position = tracksTemp[0].transform.position;
        startTrack1Position = tracksTemp[1].transform.position;
        startTrack2Position = tracksTemp[2].transform.position;
        startTrack3Position = tracksTemp[3].transform.position;

    }
    void Start()
    {
        if(tracks != null && tracks.Count > 0)
        {
            tracks = tracks.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void TrackPosStored()
    {
        tracks[0] = tracksTemp[0];
        tracks[1] = tracksTemp[1];
        tracks[2]= tracksTemp[2];
        tracks[3]=  tracksTemp[3];

        tracks[0].transform.position = startTrack0Position;
        tracks[1].transform.position = startTrack1Position;
        tracks[2].transform.position = startTrack2Position;
        tracks[3].transform.position =  startTrack3Position;
    }

    public void MoveTrack()
    {
        movedTrack = tracks[0];
        tracks.Remove(movedTrack);
        float newZ = tracks[tracks.Count - 1].transform.position.z + offset;

        Transform[] allChildren = movedTrack.transform.GetComponentsInChildren<Transform>(true);

        for(int i=0; i<allChildren.Length; i++)
        {  
            if(allChildren[i].gameObject.activeInHierarchy)
            {
                if(allChildren[i].gameObject.name == "Cube")
                    {
                        Debug.Log("allChildren[i].gameObject.tag Active = " + allChildren[i].gameObject.tag);
                    }
            } 
            else{

                   if(allChildren[i].gameObject.name == "Cube")
                    {
                        Debug.Log("allChildren[i].gameObject.tag inActive = " + allChildren[i].gameObject.tag);
                    }
                allChildren[i].gameObject.SetActive(true);
            }

             TextureUpdate(allChildren[i].gameObject);
                
        }

        movedTrack.transform.position = new Vector3(0,0, newZ);
        tracks.Add(movedTrack);
    
    }

      public void TextureChange()
      {
         Debug.Log("TextureChange()");

        for(int j=0; j<4; j++)
        { 
                Transform[] allChildren = tracks[j].transform.GetComponentsInChildren<Transform>(true);
                for(int i=0; i<allChildren.Length; i++)
                {  
                    if(allChildren[i].gameObject.activeInHierarchy)
                    {
                        Debug.Log(" Active Texture Change");
                    } 
                    else{

                       
                        if(allChildren[i].gameObject.tag != "Coin")
                        {
                             allChildren[i].gameObject.SetActive(true);
                        }
                    }
                    TextureUpdate(allChildren[i].gameObject);
                }
            }

      }


      public void TextureUpdate(GameObject o)
      {
          Renderer rend = o.gameObject.GetComponent<Renderer>();

                    if(o.gameObject.name == "Cube")
                    {
            
                         int num = Random.Range(1,10);
                       
                       if(num == 1)
                        {
                            o.gameObject.tag = "Box_1";
                            rend.material.mainTexture = texture[0];
                        }
                        else if(num == 2) 
                        {
                            o.gameObject.tag = "Box_2";
                            rend.material.mainTexture = texture[1];

                        }
                        else if(num == 3) 
                        {
                            o.gameObject.tag = "Box_3";
                            rend.material.mainTexture = texture[2];
                        }
                        else if(num == 4) 
                        {
                            o.gameObject.tag = "Box_4";
                            rend.material.mainTexture = texture[3];
                        }
                        else if(num == 5) 
                        {
                            o.gameObject.tag = "Box_5";
                            rend.material.mainTexture = texture[4];
                        }
                        else if(num == 6) 
                        {
                            o.gameObject.tag = "Box_6";   
                            rend.material.mainTexture = texture[5];
                        }
                        else if(num == 7) 
                        {
                            o.gameObject.tag = "Box_7";
                            rend.material.mainTexture = texture[6];
                        }
                        else if(num == 8) 
                        {
                            o.gameObject.tag = "Box_8";
                            rend.material.mainTexture = texture[7];
                        }
                        else if(num == 9) 
                        {
                            o.gameObject.tag = "Box_9";
                            rend.material.mainTexture = texture[8];
                        }
                        else if(num == 10) 
                        {
                            o.gameObject.tag = "Box_10";
                            rend.material.mainTexture = texture[9];
                        }

                    }
        
      }

   
}
