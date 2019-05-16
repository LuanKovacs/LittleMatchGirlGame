/* By Ricardo Ticlao III
    Win/lose condition
    14/05/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject Doors;
    public GameObject roadBlock;
    public int goalCount;
    public int litBonfires;
    public int sceneNumber;

    bool exitOpen;

    private void OnEnable()
    {
        EventManager.StartListening("Dead", Dead);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Dead", Dead);
    }

    // Update is called once per frame
    void Update()
    {
        if (litBonfires == goalCount && !exitOpen)
        {
            roadBlock.SetActive(false);
            Doors.SetActive(true);
            exitOpen = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            winPanel.SetActive(true);
            other.GetComponent<Player_Movement>().enabled = false;
            StartCoroutine("LoadScene1");
        }
    }

    void Dead()
    {
        losePanel.SetActive(true);
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNumber);
        yield break;
    }

    IEnumerator LoadScene1()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneNumber);
        yield break;
    }

}//End
