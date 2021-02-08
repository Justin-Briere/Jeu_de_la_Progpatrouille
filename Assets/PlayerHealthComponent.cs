using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : MonoBehaviour
{
    GestionPlayer player;

    [SerializeField]
    private int maxHealthPoints = 5;

    private int currentHealth;
    EnemySpawnerComponent test;
    EnemySpawnerComponent ObjectToClone;
    private void Start()
    {
        ObjectToClone = GetComponentInParent<EnemySpawnerComponent>();
        currentHealth = maxHealthPoints;
    }

    private void Update()
    {
        if (currentHealth <= 0)
            DestroyObject();
    }

    public void DestroyObject()
    {
        //player.NewSpawn();

        currentHealth = maxHealthPoints;
        //  test = new EnemySpawnerComponent();
        ObjectToClone.Spawn();
        Destroy(gameObject);
      


    }
    private void OnMouseDown()
    {
        currentHealth--;
        Debug.Log(currentHealth);
    }
}

