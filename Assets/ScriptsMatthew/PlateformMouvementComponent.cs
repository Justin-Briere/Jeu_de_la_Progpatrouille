using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvementComponent : MonoBehaviour
{
    public List<GameObject> Spawns;
    


    [SerializeField]
    private float speed = 1.5f;

    private bool isMoving = true;

    //[SerializeField]
    private Vector3 vector = new Vector3(0, 0, -1);

    SpawnTrigger Spawn;
    private Transform Plateform;
    //MovementComponent Follow;
    private void Start()
    {
        Plateform = GetComponentInChildren<Transform>();
    }
    void Update()
    {

        if (isMoving)
            Plateform.position += speed * (vector * Time.deltaTime) * Plateform.rotation.y ; // vector valeur pas bonne (pas de rotation de plateforme)
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("ici");
    //    var text = GameObject.FindGameObjectWithTag("Player");
    //    text.transform.Translate(vector * speed * Time.deltaTime);

    //    // Follow.Move(vector) = transform.Translate(vector * (speed * Time.deltaTime)); 
    //}
    public Vector3 DéterminerDirection()
    {
        Vector3 vector = new Vector3();
        GameObject Spawn1 = GameObject.Find("Spawn1");
        GameObject Spawn2 = GameObject.Find("Spawn2");
        GameObject Spawn3 = GameObject.Find("Spawn3");

        Spawns.Add(Spawn1);
        Spawns.Add(Spawn2);
        Spawns.Add(Spawn3);

        for (int i = 0; i <= Spawns.Count; ++i)
            if (i % 2 == 0)
            {
                vector = new Vector3(0, 0, -1);
            }
            else
                vector = new Vector3(0, 0, 1);
        return vector;
    }

    


}
