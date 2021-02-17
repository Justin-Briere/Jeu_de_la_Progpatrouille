using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    private bool isMoving;

    private Vector3 vector = new Vector3(0,0,-1);

    //MovementComponent Follow;

    void Update()
    {
        if(isMoving)
            transform.position += (vector * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = true;
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.collider.transform.SetParent(null);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.collider.transform.SetParent(null);

        ///var text = GameObject.FindGameObjectWithTag("Player");
        //text.transform.Translate(vector * speed * Time.deltaTime);
        
       // Follow.Move(vector) = transform.Translate(vector * (speed * Time.deltaTime)); 
    }
    */
}
