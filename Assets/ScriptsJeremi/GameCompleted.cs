using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleted : MonoBehaviour  // Classe qui détruit un mur lorsque deux jeux sont réussis.
{
    GameObject destructibleWall;
    private void Start()
    {
        destructibleWall = GameObject.FindGameObjectWithTag("DestructibleWall");
        
    }

    
    void Update()
    {
        if(KeepOverTimeComponent.SimonRéussi == true && KeepOverTimeComponent.GalagaRéussi)
        {
            
            Destroy(destructibleWall);
        }
    }
}
