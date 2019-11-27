using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMusic : MonoBehaviour
{
    public GameObject musicMemory;
    public GameObject churchMemory;

    bool hasPlayed = false;
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
        /* if (musicPuzzle.curGoal == musicPuzzle.goal && !musicPuzzle.PuzzleComplete)
             {
             AkSoundEngine.PostEvent("Play_General", gameObject);
             AkSoundEngine.PostEvent("Stop_Memories", gameObject);
         }*/
        if (hasPlayed == true)
        {
            return;
            //AkSoundEngine.PostEvent("Stop_Memories", gameObject);
        }
        else
        {
            if (hasPlayed == false)
            {
                if (musicMemory.active)
                {
                    Debug.Log("play music");
                    AkSoundEngine.PostEvent("Play_Memories", gameObject);
                    hasPlayed = true;
                }
                if (churchMemory.active)
                {
                    hasPlayed = true;
                    AkSoundEngine.PostEvent("Play_Memories", gameObject);
                }
            }

        }
        if (musicMemory = null)
        {
            Debug.Log("StOop MuuusIc");
            AkSoundEngine.PostEvent("Stop_Memories", gameObject);
            hasPlayed = false;
        }
        

        if (churchMemory = null)
        {
            AkSoundEngine.PostEvent("Stop_Memories", gameObject);
            hasPlayed = false;
        }
        

        //if (hasPlayed = true)
        //{
          //  return;
            //AkSoundEngine.PostEvent("Stop_Memories", gameObject);
        //}
    }
}
