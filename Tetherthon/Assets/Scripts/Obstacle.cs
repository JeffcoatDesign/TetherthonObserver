using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Quaternion startRotation;
    Vector3 startPos;
    void Start()
    {
        startRotation = transform.rotation;
        startPos = transform.position;
    }

    public void ResetLocation()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        transform.position = startPos;
        transform.rotation = startRotation;
    }
}
