using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTargetMove : MonoBehaviour
{
    public Transform target;
    public float speed = 8.0f;
    public GameObject player;
    Player_Health playerHPref;

    void Awake()
    {
        playerHPref = player.GetComponent<Player_Health>();
    }

    void FixedUpdate()
    {
        if (!playerHPref.isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, playerHPref.transform.position, speed * Time.deltaTime);
        }
    }
}
