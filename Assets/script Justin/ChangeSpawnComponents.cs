using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpawnComponents : MonoBehaviour
{
    [SerializeField]
    EnemySpawnerComponent objectToClone;
    [SerializeField]
    Transform NewSpawn;
    GameObject OldSpawn;
    // Start is called before the first frame update
    void Start()
    {
        objectToClone = GetComponentInChildren<EnemySpawnerComponent>();
        //NewSpawn = objectToClone.spawnPoint;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Start();
    }
}
