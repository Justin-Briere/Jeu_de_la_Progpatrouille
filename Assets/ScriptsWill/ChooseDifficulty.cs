using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDifficulty : MonoBehaviour
{
    private void OnCollisionEnter(Collision porte)
    {
        if(porte.gameObject.layer == 9)
        {
            if (porte.gameObject.name == "Porte facile")
                KeepOverTimeComponent.difficulty = 1;
            if (porte.gameObject.name == "Porte intermédiaire")
                KeepOverTimeComponent.difficulty = 2;
            if (porte.gameObject.name == "Porte difficile")
                KeepOverTimeComponent.difficulty = 3;
            SceneManager.LoadScene("FinalScene");//AIPolice
        }

    }
}