using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitSimon : MonoBehaviour
{
    public void Quit() //Fonction servant à quitter les 2 minijeux. 
    {
        SceneManager.LoadScene("FinalScene");
    }
}
