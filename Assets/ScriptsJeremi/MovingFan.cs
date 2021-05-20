using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFan : MonoBehaviour //Script faisant faire au ventilateur une rotation de ses pales.
{
    float VitesseRotation = 50.0f;
   
    void Update()
    {
        transform.Rotate(0, 0, (VitesseRotation * Time.deltaTime));
    }
}
