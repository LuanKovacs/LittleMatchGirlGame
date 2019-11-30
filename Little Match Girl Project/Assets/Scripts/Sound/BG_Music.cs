using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Music : MonoBehaviour
{
    public string ObjName;
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
            if (ObjName == "GoodChurchMusic")
            {
                Debug.Log("play good church music");
                AkSoundEngine.PostEvent("Play_Intense_Church", gameObject);
                AkSoundEngine.PostEvent("Stop_General", gameObject);
            }

            if (ObjName == "BadChurchMusic")
            {
                Debug.Log("play bad church music");
                AkSoundEngine.PostEvent("Play_Church", gameObject);
                AkSoundEngine.PostEvent("Stop_Intense_Church", gameObject);
            }

            if (ObjName == "CityMusic")
            {
                Debug.Log("play city music");
                AkSoundEngine.PostEvent("Play_City", gameObject);
                AkSoundEngine.PostEvent("Stop_Church", gameObject);
            }

            if (ObjName == "ForestMusic")
            {
                Debug.Log("play forest music");
                AkSoundEngine.PostEvent("Play_General", gameObject);
            }

        }
    }
}
