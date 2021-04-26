using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;

    public GameObject arretMenu;

    GameObject player;
    void Start()
    {
        arretMenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(player == null)
                player = GameObject.FindGameObjectWithTag("Player");
            StopGame();
        }
    }
    public void Restart()
    {
        arretMenu.SetActive(false);
        Time.timeScale = 1f;
        IsJeuxArret = false;
        player.GetComponent<CameraCurseur>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<CameraCurseur>().enabled = false;
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
