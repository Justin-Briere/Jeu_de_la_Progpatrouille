using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;

    private Vector3 vector = new Vector3(0,0,-1);
    MovementComponent Follow;
    void Update()
    {
        transform.Translate(vector * speed * Time.deltaTime);
    }
    private void OnCollisionEnter()
    {
        Debug.Log("ici");

        var text = GameObject.FindGameObjectWithTag("Player");
        text.transform.Translate(vector * speed * Time.deltaTime);
        
       // Follow.Move(vector) = transform.Translate(vector * (speed * Time.deltaTime)); 
    }
}
