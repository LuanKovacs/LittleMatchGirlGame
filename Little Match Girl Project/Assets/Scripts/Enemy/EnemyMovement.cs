/* By:Ricardo III Ticlao
 * Enemy 
 * ment Behaviour
 * 09/04/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject target;
    public float alertRadius = 5f;
    public float scareRadius = 10f;
    public float fleeRadius = 10f;
    public float speed;
    public bool isHunting;
    public bool scared;

    float distance;
    int fireMask;
    int playerMask;
    private UnityEngine.AI.NavMeshAgent agent;
    Enemy_AI enemyAI;
    Vector3 fleePosition;

    private void Start()
    {
       // isHunting = true;
    }

	private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAI = GetComponent<Enemy_AI>();
        fireMask = LayerMask.GetMask("Fire");
        playerMask = LayerMask.GetMask("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        agent.speed = speed;
    }

    /*public void HuntTarget()
    {
        if (agent.enabled == true)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            agent.destination = target.transform.position;
        }
    }*/

    private void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if (Physics.CheckSphere(transform.position, scareRadius, fireMask))
        {
            isHunting = false;
            enemyAI.chasePlayer = false;
            scared = true;
            //StartCoroutine("Flee");
        }
       /* else if (!isHunting && Physics.CheckSphere(transform.position, alertRadius, playerMask))
        {
            isHunting = true;
           // scared = false;
            enemyAI.chasePlayer = true;
        }

        if (isHunting)// && Physics.CheckSphere(transform.position, scareRadius, fireMask))
        {
            HuntTarget();
        }*/

        if (scared)
        {
            Flee();
        }
    }

    //IEnumerator Flee()
    void Flee()
    {
       // if(!isHunting){
       //while
            if (agent.enabled == true)
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
                }
             //   yield return null;
          //  }
        }
       // StopCoroutine("Flee");
    }//End Flee

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, scareRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alertRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fleeRadius);
    }

}//End
