using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraCurseur : MonoBehaviour
{
    public bool ShowCursor;
    public float Sensitivity;

    public GameObject player;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (ShowCursor == false)
            Cursor.visible = false;
    }

    void Update()
    {
        float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
        float newRotationX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;

        gameObject.transform.localEulerAngles = new Vector3(newRotationX, newRotationY,0);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.GetComponent<CameraCurseur>().enabled = true;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<CameraCurseur>().enabled = false;
    }
}
