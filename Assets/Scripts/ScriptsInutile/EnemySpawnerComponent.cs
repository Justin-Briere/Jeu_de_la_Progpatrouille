using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerComponent : MonoBehaviour
{
    //BONUS***********
    //Permets de recréer l'ennemi lorsqu'il est détruit 

    [SerializeField]
     GameObject objectToClone;
    public PlayerHealthComponent[] gameObjects;
    [SerializeField]
    public GameObject spawnPoint;

     Transform TestSpawnPoint;
    private float time;

    public void Spawn()
    {
        gameObjects = GetComponentsInChildren<PlayerHealthComponent>();
        TestSpawnPoint = GetComponentInParent<Transform>();

        var un = 1;
        var spawned = Instantiate(objectToClone, spawnPoint.transform.position, transform.rotation);
            spawned.transform.localScale = transform.localScale;
          
        
 
    }
    public void SpawnPoint(GameObject newPosition)
    {
        spawnPoint = newPosition;
    }
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

}


