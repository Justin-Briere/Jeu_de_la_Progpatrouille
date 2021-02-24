using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateForm : MonoBehaviour
{
    ListSpawnPosition TriggerSpawn = new ListSpawnPosition();

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            TriggerSpawn.SpawnPF();
    }
}
