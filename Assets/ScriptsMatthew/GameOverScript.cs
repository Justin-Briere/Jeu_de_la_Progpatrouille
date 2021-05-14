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

    public void StopGame()
    {
        if (!gameEnd)
        {
            deathPanel.SetActive(true);

            curseur.PauseGame();

            ChooseFunction(true);
        }
    }

    public void Restart()
    {
        curseur.Reload();

        Cursor.lockState = CursorLockMode.Locked;

        ChooseFunction(false);
    }
    private void ChooseFunction(bool isActive)
    {
        Cursor.visible = isActive;
        Time.timeScale = isActive ? 0f : 1f;
        gameEnd = isActive;
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
