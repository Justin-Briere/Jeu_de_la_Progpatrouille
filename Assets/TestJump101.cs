using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump101 : MonoBehaviour
{
    public int forceConst = 50;
    private Rigidbody selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {

            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
    }
}