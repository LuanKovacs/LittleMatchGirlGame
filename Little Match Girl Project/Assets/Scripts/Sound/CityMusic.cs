using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMusic : MonoBehaviour
{
    //public bool isTriggered = false;
    public GameObject MemoryMusic;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       /* if(isTriggered == true)
        {
            AkSoundEngine.PostEvent("Stop_Church", MemoryMusic);
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Stop_Church");
            //isTriggered = true;
           // AkSoundEngine.PostEvent("Stop_Church", MemoryMusic);
            //AkSoundEngine.PostEvent("Play_City", gameObject);
        }
    }
}
