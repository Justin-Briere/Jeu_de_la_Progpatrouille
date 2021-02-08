using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    //Fonction que nous avons ajouté à bullet permettant de lui donner une vitesse
    private Vector3 direction;
    static private Vector3[] directions = new[]
     {
        new Vector3(0,0,1),
        new Vector3(-1,0,0),
        new Vector3(0,0,-1),
        new Vector3(1,0,0),
    };

    [SerializeField]
    private float speed = 10f;

    public void AddDirection(int directionIndex) => direction += directions[directionIndex];
   
    private void Move(Vector3 direction) => transform.Translate(direction * (speed * Time.deltaTime));

    private void Update()
    {
        if (direction != Vector3.zero)
            Move(direction.normalized);
        direction = new Vector3();
    }

    
}