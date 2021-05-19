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

    // Permet au joueur de reprendre la partie
    public void Restart()
    {
        curseur.enabled = Usecursor;
        Cursor.lockState = Usecursor ? CursorLockMode.None : CursorLockMode.Locked;

        ChooseFunction(false);
    }

    // Met le jeu sur pause et offre deux options au joueur
    public void StopGame()
    {
        curseur.PauseGame();

        ChooseFunction(true);
    }

    // Fonction générale qui est présente dans l'arrêt de jeux (Restart = false / StopGame = true)
    private void ChooseFunction(bool isActive)
    {
        Cursor.visible = isActive;
        arretMenu.SetActive(isActive); 
        Time.timeScale = isActive? 0f : 1f;
        IsJeuxArret = isActive;
    }

    // Fonction qui permet de quitter la partie
    public void QuitterPartie()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
