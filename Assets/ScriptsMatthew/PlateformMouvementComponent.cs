using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    private float speed = 2.5f;

    private float angleX;
    private float angleY;
    private float angleZ;

    private float X;
    private float Y;
    private float Z;

    private Transform Plateform;

    //MovementComponent Follow;
    private void Start()
    {
        Plateform = GetComponentInChildren<Transform>();
    }
    void Update()
    {
        angleX =- Mathf.Deg2Rad * Plateform.eulerAngles.x;
        angleY = Mathf.Deg2Rad * Plateform.eulerAngles.y;
        angleZ = Mathf.Deg2Rad * Plateform.eulerAngles.z;

        X = Mathf.Sin(angleY);
        Y = Mathf.Sin(angleX);
        Z = Mathf.Cos(angleY) * Mathf.Cos(angleX);

        Vector3 vectorBidon = new Vector3(X+0f,Y+0f,Z+0f);
        Plateform.position += speed * vectorBidon.normalized * (Time.deltaTime); 
    }
}
