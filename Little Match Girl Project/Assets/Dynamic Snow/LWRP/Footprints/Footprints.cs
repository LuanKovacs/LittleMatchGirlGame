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
    public float colliderRadius = 0.05f;
    public float footprintVerticalOffset = 0.01f;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        if (connectedTransform != null)
        {
            transform.SetParent(connectedTransform, true); //keep scale
            transform.position = connectedTransform.position;
        }
        thisCollider.radius = colliderRadius;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position , Vector3.down * checkDist, Color.red, 0.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.tag == groundTag)
        {

            MakeFootprint();
        }
    }

    void MakeFootprint()
    {
        //Debug.Log("Make Footprint");
        Ray ray = new Ray(transform.position, Vector3.down);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, checkDist, layerMask) )
        {
            Debug.Log(hit.point);
            GameObject footprint = Instantiate(footprintPrefab, hit.point, Quaternion.identity);
            footprint.transform.position = hit.point + Vector3.up*footprintVerticalOffset;
            footprint.transform.LookAt(footprint.transform.position + transform.forward, hit.normal);
            if (flip)
                footprint.transform.localScale = new Vector3(-footprint.transform.localScale.x,
                                                              footprint.transform.localScale.y,
                                                              footprint.transform.localScale.z);
        
        }
    }
}
