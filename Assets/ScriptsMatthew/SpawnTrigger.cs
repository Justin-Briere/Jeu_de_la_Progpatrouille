using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    //Position de la plateforme de base
    public Transform SpawnPoint;

    //Objet à faire spawner
    public GameObject PlateForm;

    TimeManager verif;
    // Permet d'activer la première plateforme
    private void Start()
    {
        verif = FindObjectOfType<TimeManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && verif.verification)
        {
            Instantiate(PlateForm, SpawnPoint.position, SpawnPoint.rotation);
            verif.Attendre();
        }
    }
}
