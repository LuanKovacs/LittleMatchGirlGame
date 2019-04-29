/* By:Ricardo III Ticlao
 * Girl movement/follow script
 * 09/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_Movement : MonoBehaviour
{
    public GameObject target;
    public bool isFollowing = true;
    public float followDistance = 5f;
    public float speed = 5f;
    public float senseRadius = 15f;
    public float followRadius = 3f;

    float distance;
    int poiMask;
    int followMask;
    private UnityEngine.AI.NavMeshAgent agent;

    private void Awake() 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        poiMask = LayerMask.GetMask("PointOfInterest");
        followMask = LayerMask.GetMask("Follow");
        agent.speed = speed;
    }

    private void Update() 
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        //FindPOI();

        if (!isFollowing)
        {
            StartCoroutine("MoveToPOI");
        }
        else if (distance > followDistance && isFollowing)
        {
            FollowPlayer();
        }
      
        //FollowPlayer();
    }

    void FollowPlayer()
    {
        // target = GameObject.FindGameObjectWithTag("Player");
       agent.destination = target.transform.position;

    }

    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.transform.position);
        }
    }


    IEnumerator MoveToPOI()
    {
        while (agent.enabled == true)
        {
            if (Physics.CheckSphere(transform.position, senseRadius, poiMask))
            {
                Vector3 poiTarget = new Vector3(0,0,0);

                Collider[] possibleTargets = Physics.OverlapSphere(transform.position, senseRadius, poiMask);
                Vector3 closestTarget = possibleTargets[0].transform.position;
                float closestDistance = (possibleTargets[0].transform.position - transform.position).sqrMagnitude;
                for (int i = 0; i < possibleTargets.Length; i++)
                {
                    Vector3 offset = possibleTargets[i].transform.position - transform.position;
                    float sqrLen = offset.sqrMagnitude;
                    if (sqrLen < closestDistance)
                        closestTarget = possibleTargets[i].transform.position;
                        closestDistance = sqrLen;   

                        poiTarget = closestTarget;
                }
               // target = GameObject.FindGameObjectWithTag("Player");
                agent.destination = target.transform.position;

                agent.destination = poiTarget;
                agent.speed = Mathf.Clamp(poiTarget.magnitude, 0f, speed);
            }
            StopCoroutine("MoveToPOI");
            yield return null;
        }
    }//End Flee

    void FindPOI()
    {
        if (Physics.CheckSphere(transform.position, senseRadius, poiMask))
        {
            isFollowing = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, senseRadius);

        Gizmos.DrawWireSphere(transform.position, followRadius);
    }

}//End
