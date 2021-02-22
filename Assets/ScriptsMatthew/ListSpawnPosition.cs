using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSpawnPosition : MonoBehaviour
{
    public int current = 1;
    
    Transform[] spawnPositions ;
    public GameObject PlateForm;
    Transform spawnP;
    private void Start()
    {
         spawnPositions = GetComponents<Transform>();
    }
    public void SpawnPF()
    {

        spawnP = spawnPositions[current];
        Instantiate(PlateForm, spawnP.position, spawnP.rotation);
        current = current + 1;
    }

   
}
