using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuSwitch : MonoBehaviour
{
    public GameObject OffCanvas;
    public GameObject OnCanvas;
    public GameObject FirstButton;

    public bool inputOnly;
    bool isActive;
    bool gameStarted;

    private void OnEnable()
    {
        isActive = true;
        EventManager.StartListening("GameStart", GameStart);
    }

    private void OnDisable()
    {
        isActive = false;
        EventManager.StopListening("GameStart", GameStart);
    }


    void GameStart()
    {
        gameStarted = true;
    }

    public void Switch()
    {
        OffCanvas.SetActive(false);
        OnCanvas.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButton, null);
    }

    private void Update()
    {
        if (isActive == true && !gameStarted)
        {
            if (Input.GetButtonDown("Cancel") && inputOnly == true)
            {
                OffCanvas.SetActive(false);
                OnCanvas.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButton, null);
            }
        }

        if (isActive == true && gameStarted)
        {
            if (Input.GetButtonDown("Cancel") && inputOnly == true)
            {
                OffCanvas.SetActive(false);
                OnCanvas.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstButton, null);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("New LMG");
        }
    }
}
