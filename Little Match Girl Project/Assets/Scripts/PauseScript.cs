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
            pauseMenu.GetComponent<CanvasGroup>().alpha = 1f;
            isPaused = true;

            Time.timeScale = 0.0f;
            print("TestPause");


        }

        else

        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
            isPaused = false;

            Time.timeScale = 1.0f;
        }
    }

    public void UnPause()
    {
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
        isPaused = false;

        Time.timeScale = 1.0f;
    }


}//End
