using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMusic : MonoBehaviour
{
    public GameObject MemoryMusic;
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
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Stop_Church");
            AkSoundEngine.PostEvent("Stop_Church", MemoryMusic);
            AkSoundEngine.PostEvent("Play_City", gameObject);
        }
    }
}
