using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwSound : MonoBehaviour
{
    //public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        float rtpc = 0;
        //AkSoundEngine.SetState("Dead_or_Alive", "Alive");
        //Menu.SetActive(false);
        AkSoundEngine.SetRTPCValue("Ambience_1", rtpc);
        AkSoundEngine.PostEvent("Wind_1", gameObject);
        //AkSoundEngine.PostEvent("Stop_Musicbox", gameObject);
        //"Type_Stop", gameObject);
        //AkActionOnEvent
        //AkSoundEngine.PostEvent("Play_BG_Music", gameObject);
        //AkSoundEngine.PostEvent("Play_Memories", gameObject);
        //AkSoundEngine.SetState("Music", "Memories");
    }

    void Awake()
    {
        //AkSoundEngine.ExecuteActionOnEvent("Play_Musicbox", 0, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
