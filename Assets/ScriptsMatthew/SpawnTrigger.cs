using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    //Position de la plateforme de base
    public Transform SpawnPoint;

    //Objet à faire spawner
    public GameObject PlateForm;

    // Lorsqu'il est trigger, les plate forme commence à spawn

    // Permet d'activer la première plateforme
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
            Instantiate(PlateForm, SpawnPoint.position, SpawnPoint.rotation);
    }
}
