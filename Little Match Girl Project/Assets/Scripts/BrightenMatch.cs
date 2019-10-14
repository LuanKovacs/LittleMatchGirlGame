using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightenMatch : MonoBehaviour
{
    public Light lt;
    public GameObject startTrigger;
    public GameObject endTrigger;
    public float intensityOG; //RT update
    public float intensityNew;


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
        if (darkCol.gameObject == startTrigger)
        {
           lt.spotAngle = 125.9f;
           lt.intensity = intensityNew;
        }

        if (darkCol.gameObject == endTrigger)
        {
            lt.spotAngle = 87.7f;
            lt.intensity = intensityOG;
        }
    }


}
