using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointComponent : MonoBehaviour
{
    public EnemySpawnerComponent player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<EnemySpawnerComponent>();
    }

    /// <summary>
    /// Permet de changer le spawn point du joueur lorsqu'il passe sur le game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) //ou layer selon un nombre MAIS VOIR AVEC 
            player.SpawnPoint(transform.gameObject);
    }
}
