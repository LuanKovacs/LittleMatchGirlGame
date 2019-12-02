
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwAudioEmitterScript : MonoBehaviour
{
   // public string EventName = "default";
   // public string StopEvent = "default";
    public bool IsInCollider = false;
    public float MaxVol;
        
    float FireVol;

    // Start is called before the first frame update
    void Start()
    {
        //AkSoundEngine.RegisterGameObj(gameObject);   
        //AkSoundEngine.PostEvent("Fire_crackling", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.activeInHierarchy)
        {
            FireVol = MaxVol;

            if (other.tag != "Player" || IsInCollider) { return; }
            IsInCollider = true;
            AkSoundEngine.PostEvent("Fire_crackling", gameObject);

            AkSoundEngine.SetRTPCValue("Fire_crackling", FireVol);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        FireVol -= (0/MaxVol) * Time.deltaTime;

        if (other.tag != "Player" || !IsInCollider) { return; }
        //AkSoundEngine.PostEvent("Stop_Fire_crackling", gameObject);
        AkSoundEngine.SetRTPCValue("Fire_crackling", MaxVol);
        IsInCollider = false;
    }

    private void OnTriggerStay(Collider other)
    {
        FireVol = MaxVol;

        if (other.tag != "Player" || IsInCollider) { return; }
        //FireVol = 20;
        

        AkSoundEngine.SetRTPCValue("Fire_crackling", MaxVol);
        IsInCollider = true;
    }
}
