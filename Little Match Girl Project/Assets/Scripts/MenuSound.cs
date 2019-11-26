using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;

    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
            
    }

        // Update is called once per frame
        void Update()
        {

        if (mainMenu.activeSelf)
        {
            if(hasPlayed == true)
            {
                return;
            }
            else
            { 
                Debug.Log("is menu");
                AkSoundEngine.PostEvent("Play_Musicbox", gameObject);
                hasPlayed = true;
            }
        }

        if (!mainMenu.activeSelf)
            {
                Debug.Log("no menu");
                AkSoundEngine.PostEvent("Stop_Musicbox", gameObject);
                hasPlayed = false;
            }


            if (!pauseMenu.activeSelf)
                {
                    Debug.Log("no menu");
                    AkSoundEngine.PostEvent("Stop_Musicbox", gameObject);
                    hasPlayed = false;
                }
        }
    
}
