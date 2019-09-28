using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenu;

    bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {

        }

        else

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            UnPause();
        }
    }

    public void Pause()
    {
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1f;
        isPaused = true;

        Time.timeScale = 0.0f;
        print("TestPause");
    }

    public void UnPause()
    {
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
        isPaused = false;

        Time.timeScale = 1.0f;
    }


}//End
