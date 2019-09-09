using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rtpc = 0;
        AkSoundEngine.SetState("Dead_or_Alive", "Alive");
        AkSoundEngine.SetRTPCValue("Music_RTPC", rtpc);
        AkSoundEngine.PostEvent("Ambience_1", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
