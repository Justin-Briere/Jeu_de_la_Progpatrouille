using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlateforme : MonoBehaviour
{
    //Position de la plateforme de base
    public Transform SpawnPoint;

    //Objet à faire spawner
    public GameObject PlateForm;
    
    // Lorsqu'il est trigger, les plate forme commence à spawn
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(PlateForm, SpawnPoint.position, SpawnPoint.rotation);
    }
}
