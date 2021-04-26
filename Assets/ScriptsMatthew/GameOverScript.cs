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

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mort.SetActive(false);
    }

    public void StopGame()
    {
        if (gameEnd == false)
        {
            gameEnd = true;
            mort.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<CameraCurseur>().enabled = false;
            mort.SetActive(true);
            Time.timeScale = 0f;
            gameEnd = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameEnd = false;
        player.GetComponent<CameraCurseur>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
