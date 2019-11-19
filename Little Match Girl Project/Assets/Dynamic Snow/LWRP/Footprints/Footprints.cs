using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public Transform connectedTransform;
    public string connectedObjectName;
    public GameObject footprintPrefab;
    public bool flip = false;
    public string groundTag;
    public SphereCollider thisCollider;
    public float checkDist = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject g = character.Find(connectedObjectName);
        //if (g != null)
        //{
        //    transform.SetParent(g.transform);
        //}
        if (connectedTransform != null)
        {
            transform.SetParent(connectedTransform, true); //keep scale
            transform.position = connectedTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * checkDist, Color.red, 0.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == groundTag)
        {

            MakeFootprint();
            //Instantiate(footprintPrefab, col.position, Quaternion.identity);
        }
    }

    void MakeFootprint()
    {
        Debug.Log("Make Footprint");
        Ray ray = new Ray(transform.position + (Vector3.up*0.1f), Vector3.down);
        
        RaycastHit hit;
        if (thisCollider.Raycast(ray, out hit, checkDist) )
        {
            Debug.Log(hit.point);
            Instantiate(footprintPrefab, hit.point, Quaternion.identity);
        }
    }
}
