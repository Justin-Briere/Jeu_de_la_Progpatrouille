using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    bool gameEnd = false;

    [SerializeField]
    GameObject mort;

    private void Start()
    {
        mort.SetActive(false);
    }

    public void StopGame()
    {
        if (gameEnd == false)
        {
            gameEnd = true;
            mort.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
