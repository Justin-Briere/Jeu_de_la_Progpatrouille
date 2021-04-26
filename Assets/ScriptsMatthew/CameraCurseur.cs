using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCurseur : MonoBehaviour
{
    public bool ShowCursor;
    public float Sensitivity;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (ShowCursor == false)
            Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Sensitivity;
        float newRotationX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * Sensitivity;

        gameObject.transform.localEulerAngles = new Vector3(newRotationX, newRotationY,0);
    }
}
