using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPlayer : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoints = 5;

    private int currentHealth;

    [SerializeField]
    private GameObject objectToClone;

    private GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = Instantiate(objectToClone, spawnPoint.transform);
        currentHealth = maxHealthPoints;
    }
    public void NewSpawn()
    {
        Instantiate(objectToClone, spawnPoint.transform);
        currentHealth = maxHealthPoints;
    }
    public void SpawnPoint(GameObject newPosition)
    {
        spawnPoint = newPosition;
    }
}
