using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFan : MonoBehaviour
{
    float VitesseRotation = 50.0f;
   
    void Update()
    {
        transform.Rotate(0, 0, (VitesseRotation * Time.deltaTime));
    }
}
