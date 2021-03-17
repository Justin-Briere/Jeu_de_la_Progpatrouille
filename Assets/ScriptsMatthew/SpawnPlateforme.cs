using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlateforme : MonoBehaviour
{
    //Position de la plateforme de base
    public Transform SpawnPoint;

    //Objet à faire spawner
    public GameObject PlateForm;

    TimeManager verif;

    private void Start()
    {
        verif=FindObjectOfType<TimeManager>();   
    }

    // Permet d'activer la première plateforme
    private void OnMouseDown()
    {
        if(verif.verification)
        {
            Instantiate(PlateForm, SpawnPoint.position, SpawnPoint.rotation);
            verif.Attendre();
        }
    }
}
