using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlateforme : MonoBehaviour
{
    public int current = 1;
    //Position de la plateforme de base
    public Transform SpawnPoint;

    //Objet à faire spawner
    public GameObject PlateForm;

    // Lorsqu'il est trigger, les plate forme commence à spawn
    public void SpawnPF(Transform spawnP)
    {
        Instantiate(PlateForm, spawnP.position, spawnP.rotation);
        current = current + 1;
    }

    // Permet d'activer la première plateforme
    private void OnMouseDown()
    {
         Instantiate(PlateForm, SpawnPoint.position, SpawnPoint.rotation);
    }
}
