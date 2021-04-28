using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDifficulty : MonoBehaviour
{
    int difficulty;

    private void OnCollisionEnter(Collision porte)
    {
        print("efweffwfew");
        if (porte.gameObject.tag == "easy")
        {
            KeepOverTimeComponent.difficulty = 1;
            print("diff choisie est ez");
        }
            
        if (porte.gameObject.tag == "Medium")
            KeepOverTimeComponent.difficulty = 2;
        if (porte.gameObject.tag == "Hard")
            KeepOverTimeComponent.difficulty = 3;
    }
}
