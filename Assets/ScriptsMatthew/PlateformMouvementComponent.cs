using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    private Vector3 vector = new Vector3(0,0,-1);

    void Update()
    {
        transform.Translate(vector * speed * Time.deltaTime);
    }
}
