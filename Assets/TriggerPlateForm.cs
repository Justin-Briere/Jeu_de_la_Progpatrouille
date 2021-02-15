using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateForm : MonoBehaviour
{
    SpawnPlateforme TriggerSpawn = new SpawnPlateforme();

    [SerializeField]
    Transform [] spawnPositions = new Transform[3];

    private void OnColliderEnter(Collider other)
    {
        TriggerSpawn.SpawnPF(spawnPositions[TriggerSpawn.current]);
    }
}
