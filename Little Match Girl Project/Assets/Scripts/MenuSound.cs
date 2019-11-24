using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
            if (mainMenu.activeSelf)
            {
             //   AkSoundEngine.PostEvent("Play_Musicbox", gameObject);
            }
           
            
    }

        // Update is called once per frame
        void Update()
        {
            if (mainMenu = null)
            {
            Debug.Log("no menu");
                AkSoundEngine.PostEvent("Stop_Musicbox", gameObject);
             }

        }
    
}
