using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rtpc = 0;
        //AkSoundEngine.SetState("Dead_or_Alive", "Alive");
        AkSoundEngine.SetRTPCValue("Ambience_1", rtpc);
        AkSoundEngine.PostEvent("Wind_1", gameObject);
        //AkSoundEngine.PostEvent("Play_BG_Music", gameObject);
        //AkSoundEngine.PostEvent("Play_Memories", gameObject);
        //AkSoundEngine.SetState("Music", "Memories");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
