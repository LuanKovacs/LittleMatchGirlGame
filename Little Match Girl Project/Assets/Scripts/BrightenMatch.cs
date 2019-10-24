using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightenMatch : MonoBehaviour
{
    public GameObject lt;
    public GameObject startTrigger;
    public GameObject endTrigger;
    public float intensityOG; //RT update
    public float intensityNew;


    // Start is called before the first frame update
    void Start()
    {
        //lit = lt.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider darkCol)
    {

        Light lit = lt.GetComponent<Light>();
        if (darkCol.gameObject == startTrigger)
        {
            Debug.Log("Brighten");
            lit.spotAngle = 125.9f;
            lit.intensity = intensityNew;
        }

        if (darkCol.gameObject == endTrigger)
        {
            lit.spotAngle = 87.7f;
            lit.intensity = intensityOG;
        }
    }


}
