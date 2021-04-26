using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarRotation : MonoBehaviour
{
    public Transform cam;
    void Awake()
    {
        cam = Camera.main.transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(cam)
            transform.LookAt(transform.position + cam.forward);
    }
}
