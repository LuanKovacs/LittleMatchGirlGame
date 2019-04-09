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
    public float followRadius = 5f;
    public float moveSpeed = 5;

    float distance;
    int playerMask;
    private UnityEngine.AI.NavMeshAgent agent;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRadius);
    }

}//End
