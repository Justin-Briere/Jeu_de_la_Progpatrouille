using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;
    public bool Usecursor;
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
            StopGame();
        }
    }
    public void Restart()
    {
        player.GetComponent<CameraCurseur>().enabled = Usecursor ? true : false;
        Cursor.lockState = Usecursor ? CursorLockMode.None : CursorLockMode.Locked;

        NouvelleFonction(false);
    }
    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<CameraCurseur>().enabled = false;

        NouvelleFonction(true);
    }
    private void NouvelleFonction(bool isActive)
    {
        Cursor.visible = isActive;
        arretMenu.SetActive(isActive); 
        Time.timeScale = isActive? 0f : 1f;
        IsJeuxArret = isActive;
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
