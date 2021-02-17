using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump101 : MonoBehaviour
{
    public int forceConst = 50;
    private Rigidbody selfRigidbody;
    private Rigidbody Floor;
    float dist;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }

    public void Jump()   
    {
        Debug.Log("Distance to other: " );
       
             dist = Vector3.Distance(selfRigidbody.gameObject.transform.position, Floor.gameObject.transform.position);
           
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            selfRigidbody.AddForce(0, -9.81f, 0, ForceMode.Impulse);
         Debug.Log ("Distance to other: " + dist);
    }
}