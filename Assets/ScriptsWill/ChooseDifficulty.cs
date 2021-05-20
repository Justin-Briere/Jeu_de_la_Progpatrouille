using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDifficulty : MonoBehaviour //Cette classe sert à déterminé la difficulté du jeu selon la porte choisie par le joueur.
{
    private void OnCollisionEnter(Collision door)
    {
        if(door.gameObject.layer == 9)
        {
            if (door.gameObject.name == "Porte facile")
            {
                KeepOverTimeComponent.difficulty = 1;
                SceneManager.LoadScene("Piege facile");
            }
            if (door.gameObject.name == "Porte intermédiaire")
            {
                KeepOverTimeComponent.difficulty = 2;
                SceneManager.LoadScene("Piege Moyen");
            }
            if (door.gameObject.name == "Porte difficile")
            {
                KeepOverTimeComponent.difficulty = 3;
                SceneManager.LoadScene("Piege difficile");
            }
        }

    }
}