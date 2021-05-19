using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushComponent : MonoBehaviour
{

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Push(Vector3 acceleration)
    {
        rb.AddForce(acceleration);
    }

}