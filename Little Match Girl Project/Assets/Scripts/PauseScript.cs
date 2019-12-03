using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject buttons;
    public GameObject FirstButton;
    bool gameStarted;
    bool isPaused;

    private void OnEnable()
    {
        EventManager.StartListening("GameStart", GameStart);
    }

    private void OnDisable()
    {
        EventManager.StopListening("GameStart", GameStart);
    }

    void GameStart()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (gameStarted == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused || Input.GetButtonDown("StartButton") && !isPaused)
            {
                Pause();
                //AkSoundEngine.PostEvent("Play_Musicbox", gameObject);
            }

            else

            if (Input.GetKeyDown(KeyCode.Escape) && isPaused || Input.GetButtonDown("StartButton") && isPaused)
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        buttons.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButton, null);
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1f;
        isPaused = true;

        Time.timeScale = 0.0f;
        print("TestPause");
    }

    public void UnPause()
    {
        buttons.SetActive(false);
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
        isPaused = false;

        Time.timeScale = 1.0f;
    }


}//End
