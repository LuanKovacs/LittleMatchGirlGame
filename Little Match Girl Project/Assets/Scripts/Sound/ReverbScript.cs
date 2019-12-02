using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbScript : MonoBehaviour
{
    public float reverb;
    public string sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.SetRTPCValue(sound, reverb);
    }
}
