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
            difficulty = 1;
            print("diff choisie est ez");
        }
            
        if (porte.gameObject.tag == "Medium")
            difficulty = 2;
        if (porte.gameObject.tag == "Hard")
            difficulty = 3;
    }
}
