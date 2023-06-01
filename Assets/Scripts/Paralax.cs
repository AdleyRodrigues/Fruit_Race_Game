using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length;
    private float StartPosicion;

    private Transform cam;

    public float ParallaxEffect;

    void Start()
    {
        StartPosicion = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;

    }

    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;

       transform.position = new Vector3(StartPosicion + Distance, transform.position.y, transform.position.z); 
        if (RePos > StartPosicion + length) 
        {
            StartPosicion += length;
        }
        else if (RePos < StartPosicion - length) 
        {
            StartPosicion -= length;
        }
    }
}
