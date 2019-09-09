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

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
        transform.position = Vector3.Lerp(transform.position, targetPos.position, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, transform.position.x, transform.position.x), 
                                                     transform.position.y, 
                                         Mathf.Clamp(transform.position.z, transform.position.z, targetPos.position.z));
        }
    }

}
