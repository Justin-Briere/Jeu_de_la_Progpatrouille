using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    //BONUS********
    //Script allant sur l'ennemi directement qui permet de prendre des dégats, de le détruire et même de le faire re-spawn

    [SerializeField]
    private int healthPoints;

    private int bulletDamage = 2;
    EnemySpawnerComponent ObjectToClone;



    private void Awake()
    {
        ObjectToClone = GetComponentInParent<EnemySpawnerComponent>();
    }
    private void Update()
    {
        if (healthPoints <= 0)
            Destroy();
    }

    public void BodyShot()
    {
        healthPoints -= bulletDamage;
        Destroy();
    }
    public void HeadShot()
    {
        healthPoints -= (bulletDamage * 2);
        Destroy();

    }
    public void BackpackShot()
    {
        healthPoints -= bulletDamage;
        Destroy();
    }

    public void Destroy()
    {
        if (healthPoints <= 0)
        {
            healthPoints = 5;

            ObjectToClone.Spawn();
            Destroy(gameObject);
            Debug.Log("BRAVO, YOU KILLED AN ENEMY");

           
            
            
        }
    }

}