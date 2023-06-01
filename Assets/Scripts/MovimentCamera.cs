using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentCamera : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
    }


    void Update()
    {
        newPosition.x -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
