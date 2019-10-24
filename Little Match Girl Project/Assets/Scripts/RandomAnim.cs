using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        int Randomize = Random.Range(1, 3);
        Debug.Log("randomize");

        anim.SetInteger("Randomize", Randomize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
