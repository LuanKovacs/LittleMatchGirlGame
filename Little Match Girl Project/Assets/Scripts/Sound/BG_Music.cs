using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Music : MonoBehaviour
{
    public bool GchurchPlayed = false;
    public bool BchurchPlayed = false;
    public bool ForestPlayed = false;
    public bool CityPlayed = false;
    public float FadeVol = 0f;

    public GameObject BadChurchMusic;
    public string ObjName;

    public GameObject GoodChurch;
    public GameObject BadChurch;
    public GameObject Forest;
    public GameObject City;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BchurchPlayed == false)
        {
            if (BadChurchMusic.activeInHierarchy)
            {
                Debug.Log("play bad church music");
                AkSoundEngine.PostEvent("Play_Church", BadChurch);
                AkSoundEngine.PostEvent("Stop_Intense_Church", GoodChurch);

                BchurchPlayed = true;
            }
        }

        if (CityPlayed == true)
        {
            AkSoundEngine.PostEvent("Stop_Church", BadChurch);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GchurchPlayed == false)
            {
                if (ObjName == "GoodChurchMusic")
                {
                    Debug.Log("play good church music");
                    AkSoundEngine.PostEvent("Play_Intense_Church", GoodChurch);
                    AkSoundEngine.PostEvent("Stop_General", Forest);

                    GchurchPlayed = true;
                }
            }

            /*if (BchurchPlayed == false)
            {
                if (ObjName == "BadChurchMusic")
                {
                    Debug.Log("play bad church music");
                    AkSoundEngine.PostEvent("Play_Church", gameObject);
                    AkSoundEngine.PostEvent("Stop_Intense_Church", gameObject);

                    BchurchPlayed = true;
                }
            }*/

            if (CityPlayed == false)
            {
                if (ObjName == "CityMusic")
                {
                    Debug.Log("play city music");
                    AkSoundEngine.PostEvent("Play_City", City);
                    AkSoundEngine.PostEvent("Stop_Church", BadChurch);
                    Debug.Log("STOP church muse");

                    CityPlayed = true;
                }
            }

            if (ForestPlayed == false)
            {
                if (ObjName == "ForestMusic")
                {
                    Debug.Log("play forest music");
                    AkSoundEngine.PostEvent("Play_General", Forest);

                    ForestPlayed = true;
                }
            }

            /*    if ((GchurchPlayed || GchurchPlayed || ForestPlayed || CityPlayed) == true)
                {
                    return;
                }*/
        }
    }

   /*  void OnTriggerExit(Collider other)
     {
         if (other.gameObject.tag == "Player")
         {
             if (GchurchPlayed == true)
             {
                 if (ObjName == "GoodChurchMusic")
                 {
                     //Debug.Log("play good church music");
                     //AkSoundEngine.PostEvent("Play_Intense_Church", gameObject);
                     AkSoundEngine.PostEvent("Stop_General", gameObject);
                     //AkSoundEngine.SetRTPCValue("Play_General", FadeVol);


                     GchurchPlayed = false;
                 }
             }

             if (BchurchPlayed == true)
             {
                 if (ObjName == "BadChurchMusic")
                 {
                     //Debug.Log("play bad church music");
                     // AkSoundEngine.PostEvent("Play_Church", gameObject);
                     AkSoundEngine.PostEvent("Stop_Intense_Church", gameObject);

                     BchurchPlayed = false;
                 }
             }

             if (CityPlayed == true)
             {
                 if (ObjName == "CityMusic")
                 {
                     //Debug.Log("play city music");
                     //AkSoundEngine.PostEvent("Play_City", gameObject);
                     AkSoundEngine.PostEvent("Stop_Church", gameObject);

                     CityPlayed = false;
                 }
             }

             if (ForestPlayed == true)
             {
                 if (ObjName == "ForestMusic")
                 {
                     //Debug.Log("play forest music");
                     // AkSoundEngine.PostEvent("Play_General", gameObject);

                     ForestPlayed = false;
                 }
             }
         }
     }*/
}
