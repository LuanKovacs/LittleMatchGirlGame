using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMusic : MonoBehaviour
{
    public GameObject musicMemory;
    public GameObject churchMemory;

    public bool hasPlayed = false;
    PuzzleMusic musicPuzzle;
    // Start is called before the first frame update
    //void Awake()
    //{
    
    //}

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
       
        //{
            if (hasPlayed == false)
            {
                if (musicMemory.activeInHierarchy)
                {
                    hasPlayed = true;
                    AkSoundEngine.PostEvent("Play_Memories", gameObject);
                    return;
                }
                //else
        
                if (churchMemory.activeInHierarchy)
                {  
                    hasPlayed = true;
                    AkSoundEngine.PostEvent("Play_Memories", gameObject);
                    return;
                }
            }

             if (hasPlayed == true)
            {

                    if (!musicMemory.activeSelf)
                    {
                         if (!churchMemory.activeSelf)
                         { 
                                //Debug.Log("StOop MuuusIc");
                                AkSoundEngine.PostEvent("Stop_Memories", gameObject);
                                //AkSoundEngine.PostEvent("Play_General", gameObject);
                                hasPlayed = false;
                         }
                       
                    }

                    if (!churchMemory.activeInHierarchy)
                    {
                        if (!musicMemory.activeInHierarchy)
                        {
                            //Debug.Log("StOop MuuusIc");
                            AkSoundEngine.PostEvent("Stop_Memories", gameObject);
                            
                            //AkSoundEngine.PostEvent("Stop_Intense_Church", gameObject);
                            //AkSoundEngine.PostEvent("Play_Church", gameObject);
                            hasPlayed = false;
                        }
                    }

            // Debug.Log("do not repeat");
            return;
        }
    }
               
        //if (hasPlayed = true)
        //{
          //  return;
            //AkSoundEngine.PostEvent("Stop_Memories", gameObject);
        //}
}
//}
