using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitSimon : MonoBehaviour
{
    public void Quit() 
    {
        SceneManager.LoadScene("FinalScene");
    }
}
