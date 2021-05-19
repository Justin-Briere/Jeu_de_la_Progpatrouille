using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    bool gameEnd = false;

    [SerializeField]
    GameObject deathPanel;

    CameraCurseur curseur;

    private void Start()
    {
        curseur = FindObjectOfType<CameraCurseur>();

        deathPanel.SetActive(false);
    }

    // Met le jeu sur pause et offre deux options au joueur lorsque le joueur meurt
    public void StopGame()
    {
        if (!gameEnd)
        {
            deathPanel.SetActive(true);

            curseur.PauseGame();

            ChooseFunction(true);
        }
    }

    // Permet au joueur de réapparaître
    public void Restart()
    {
        curseur.Reload();

        Cursor.lockState = CursorLockMode.Locked;

        ChooseFunction(false);
    }

    // Fonction générale qui est présente dans l'arrêt de jeux (Restart = false / StopGame = true)
    private void ChooseFunction(bool isActive)
    {
        Cursor.visible = isActive;
        Time.timeScale = isActive ? 0f : 1f;
        gameEnd = isActive;
    }

    // Fontion qui permet au joueur de quitter
    public void QuitterPartie()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
