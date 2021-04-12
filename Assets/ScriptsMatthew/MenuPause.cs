using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;

    public GameObject arretMenu;
    void Start()
    {
        arretMenu.SetActive(false);
    }

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
    public void Restart()
    {
        arretMenu.SetActive(false);
        Time.timeScale = 1f;
        IsJeuxArret = false;
    }
    public void StopGame()
    {
        arretMenu.SetActive(true);
        Time.timeScale = 0f;
        IsJeuxArret = true;
    }
    public void QuitterPartie()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
