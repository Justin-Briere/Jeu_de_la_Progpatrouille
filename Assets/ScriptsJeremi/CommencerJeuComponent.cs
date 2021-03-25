using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommencerJeuComponent : MonoBehaviour
{
    public void CommencerJeu()
    {
        SceneManager.LoadScene("LVL1");
    }
}
