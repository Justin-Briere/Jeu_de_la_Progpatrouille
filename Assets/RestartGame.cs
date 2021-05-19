using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    Camera lastCam;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && lastCam.isActiveAndEnabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("MenuBouton");
        }
    }
}
