using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceComponents : MonoBehaviour
{
    void Start()
    {
        
    }
    public float CalculatueDistance(GameObject a, GameObject b) 
    {
        return(float)Vector3.Distance(a.transform.position, b.transform.position);
    }
}
