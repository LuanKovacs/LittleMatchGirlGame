using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShadowNPCs : MonoBehaviour
{
    public float radius = 15.0f;
    public GameObject[] npcs;

    // Start is called before the first frame update
    void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("npc");
    }

    // Update is called once per frame
    void Update()
    {
      //  GetInactiveInRadius();
    }

    void GetInactiveInRadius()
    {
        foreach (GameObject npc in npcs)
        {
            float distanceSqr = (transform.position - npc.transform.position).sqrMagnitude;
            if (distanceSqr < radius)
            {
                npc.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("npc"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("npc"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
