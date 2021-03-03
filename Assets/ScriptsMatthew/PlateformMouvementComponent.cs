using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    private bool isMoving = true;

    private Vector3 vector = new Vector3(0, 0, 1);
    private Transform Plateform;
    //MovementComponent Follow;
    private void Start()
    {
        Plateform = GetComponentInChildren<Transform>();

        
    }
    void Update()
    {
        //Plateform.TransformPoint(speed * (vector * Time.deltaTime));
       // Plateform.Translate(speed * Time.deltaTime);
        //Plateform.position = (float)transform.Translate(speed * Time.deltaTime);
       Plateform.position += (speed * (vector * Time.deltaTime)*Mathf.Cos((Plateform.rotation.y)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ici");
        var text = GameObject.FindGameObjectWithTag("Player");
        text.transform.Translate((vector * speed) * Time.deltaTime);

        // Follow.Move(vector) = transform.Translate(vector * (speed * Time.deltaTime)); 
    }

}
