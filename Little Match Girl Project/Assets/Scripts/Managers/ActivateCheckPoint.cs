using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckPoint : MonoBehaviour
{
    public GameObject checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (checkpoint.activeSelf == false)
            {
                checkpoint.SetActive(true);
            }
        }
    }
}
