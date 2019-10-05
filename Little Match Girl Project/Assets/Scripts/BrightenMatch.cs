using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightenMatch : MonoBehaviour
{
    public Light lt;
    public GameObject trigger;


    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider darkCol)
    {
        if (darkCol.gameObject == trigger)
        {
           lt.intensity = 2f;
        }
    }


}
