using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{
    public float fadeTime;
    float fadeMax;
    float fadeTimer;
    Renderer rend;
    Material material;
    Color originalColor;
    Color endColor;
    // Start is called before the first frame update
    void Start()
    {
        if (fadeTime <= 0.0f)
            fadeTime = 1.0f;
        float fadeVar = fadeTime/5.0f; 
        fadeMax = fadeTime + Random.Range(-fadeVar, fadeVar);
        fadeTimer = fadeMax;
        rend = GetComponent<Renderer>();
        material = rend.material;
        originalColor = material.color;
        endColor = material.color;
        endColor.a = 0.0f;
        Debug.Log(endColor);
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer -= Time.deltaTime;
        if (fadeTimer > 0.0f)
        {
            //These named slots were found by looking at the
            //supplied Lit shader for LWRP.
            //If you change the footprint shader, you'd need to change these
            //strings
            float fadeval = 1.0f - (fadeTimer/ fadeMax);
            material.SetColor("_BaseColor", Color.Lerp(originalColor, endColor, fadeval) );
            material.SetFloat("_BumpScale", Mathf.Lerp(1.0f, 0.0f, fadeval) );
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
