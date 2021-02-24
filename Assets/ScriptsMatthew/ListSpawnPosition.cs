using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSpawnPosition : MonoBehaviour
{
    public int current = 1;
    
    public Transform[] spawnPositions ;
    public GameObject PlateForm;
    Transform spawnP;
   
    public  void SpawnPF(Transform spawnPositions)
    {
        ListSpawnPosition TriggerSpawn = new ListSpawnPosition();
        // ListSpawnPosition Platform = new ListSpawnPosition();
        var Plate = PlateForm.GetComponentInChildren<BoxCollider>().gameObject;
        // spawnPositions[current];
        Instantiate(Plate, spawnPositions.position, spawnPositions.rotation);
        current = current + 1;
    }

   
}
