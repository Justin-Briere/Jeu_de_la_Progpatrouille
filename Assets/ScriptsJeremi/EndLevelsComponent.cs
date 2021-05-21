using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelsComponent : MonoBehaviour //Classe permettant de faire les changements de scène après les niveaux.
{
    string sceneName;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (sceneName == "Piege facile")
                SceneManager.LoadScene("AIPolice");
            if (sceneName == "Piege Moyen")
                SceneManager.LoadScene("Niveau changement de Tiles");
            if (sceneName == "Piege difficile")
                SceneManager.LoadScene("TESTVAISSEAU");
            if (sceneName == "TESTVAISSEAU")
                SceneManager.LoadScene("Niveau changement de Tiles");
            if (sceneName == "Niveau changement de Tiles")
                SceneManager.LoadScene("AIPolice");
            if (sceneName == "AIPolice")
                SceneManager.LoadScene("FinalScene");
        }
    }
}
