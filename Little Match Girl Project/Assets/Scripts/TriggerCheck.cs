using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
 void OnTriggerEnter(Collider other)
    {
        Debug.Log("is Triggered");
    }
}
