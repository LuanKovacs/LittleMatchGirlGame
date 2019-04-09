/* By:Ricardo III Ticlao
 * Enemy Movement Behaviour
 * 09/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject target;
    public float scareRadius = 10f;
    public float fleeRadius = 10f;
    public float speed;
    public bool canFlee;

    float distance;
    int fireMask;
    private UnityEngine.AI.NavMeshAgent agent;

    private void Start()
    {
        HuntTarget();
    }

	private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        fireMask = LayerMask.GetMask("Fire");
        agent.speed = speed;
    }

    public void HuntTarget()
    {
        if (agent.enabled == true)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            agent.destination = target.transform.position;
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if (Physics.CheckSphere(transform.position, scareRadius, fireMask))
        {
            StartCoroutine("Flee");
            canFlee = true;
        }
        else if (!canFlee)
        {
            HuntTarget();
            print("Hunt");
        }
    }

    IEnumerator Flee()
    {
        while (agent.enabled == true)
        {
            if (Physics.CheckSphere(transform.position, fleeRadius, fireMask))
            {
                Vector3 fleePosition = new Vector3(0, 0, 0);

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, fleeRadius, fireMask);
                if (hitColliders.Length > 1)
                {
                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        Vector3 fleeDirection = transform.position - hitColliders[i].transform.position;
                        fleePosition += fleeDirection.normalized * (10f - fleeDirection.magnitude);
                    }
                }
                else
                {
                    Vector3 fleeDirection = transform.position - hitColliders[0].transform.position;
                    fleePosition = fleeDirection.normalized * fleeRadius;
                }
                agent.destination = transform.position + fleePosition;
                agent.speed = Mathf.Clamp(fleePosition.magnitude, 0f, speed);
                print("test fleeing");
            }
            StopCoroutine("Flee");
            yield return null;
        }
    }//End Flee

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, scareRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);
    }

}//End
