using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommencerJeuComponent : MonoBehaviour  //Script permettant de lancer le jeu.
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
