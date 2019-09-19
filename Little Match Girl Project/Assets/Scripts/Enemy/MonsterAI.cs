using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform targetPos;
    public float speed = 5.0f;
    public bool move;

    private void OnEnable() 
    {
        move = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (move)
        {
            float dist = Vector3.Distance(transform.position, targetPos.position);
            float minDist = 2.0f;
            transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
        
            //transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
            //transform.position = new Vector3(Mathf.Clamp (transform.position.x, transform.position.x - 1f , transform.position.x - 1f), transform.position.y, transform.position.z);
        }
    }

}
