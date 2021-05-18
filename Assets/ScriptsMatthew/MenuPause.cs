using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool IsJeuxArret = false;
    public bool Usecursor;
    public GameObject arretMenu;

    CameraCurseur curseur;
    void Start()
    {
        curseur = FindObjectOfType<CameraCurseur>();

        arretMenu.SetActive(false);
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
        curseur.enabled = Usecursor;
        Cursor.lockState = Usecursor ? CursorLockMode.None : CursorLockMode.Locked;

        ChooseFunction(false);
    }
    public void StopGame()
    {
        curseur.PauseGame();

        ChooseFunction(true);
    }
    private void ChooseFunction(bool isActive)
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
