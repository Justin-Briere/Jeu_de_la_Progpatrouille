using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;

    public GameObject arretMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsJeuxArret)
                Restart();
            else
                StopGame();
        }
    }
    private void Restart()
    {
        arretMenu.SetActive(false);
        Time.timeScale = 1f;
        IsJeuxArret = false;
    }
    private void StopGame()
    {
        arretMenu.SetActive(true);
        Time.timeScale = 0f;
        IsJeuxArret = true;
    }
    private void QuitterPartie()
    {
        Application.Quit();
    }

}
