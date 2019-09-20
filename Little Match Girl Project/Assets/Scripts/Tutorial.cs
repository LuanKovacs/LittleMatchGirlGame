using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject IntTUT;//***Tianna!!***


    // Start is called before the first frame update
    void Start()
    {
        IntTUT.GetComponent<CanvasGroup>().alpha = 0;//***Tianna!!***

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider player)//***Tianna!!***
    {
        if (player.gameObject.tag == "Player")//***Tianna!!***
        {
            Debug.Log("you have collided");//***Tianna!!***
            IntTUT.GetComponent<CanvasGroup>().alpha = 1;//***Tianna!!***
        }
    }

    private void OnTriggerExit(Collider player)//***Tianna!!***
    {
        if (player.gameObject.tag == "Player")//***Tianna!!***
        {
            Debug.Log("you have left");//***Tianna!!***
            IntTUT.GetComponent<CanvasGroup>().alpha = 0;//***Tianna!!***
        }
    }
}
