using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickedObject : MonoBehaviour  // Script servant à changer de scène avec un Raycast.
{
    GameObject bandit;
    void Start()
    {
        bandit = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()  // code inspiré de Ingens https://answers.unity.com/questions/294310/button-on-wall.html
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                { 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject) // Fonction permettant le changement de scène suite au Raycast.
    {
        if (gameObject.name == "Cube Simon")
        {
            SceneManager.LoadScene("Simon mini game");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bandit.GetComponent<CameraCurseur>().enabled = false;
        }
        if (gameObject.name == "Cube Galaga")
        {
            SceneManager.LoadScene("ScèneTitreGalaga");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bandit.GetComponent<CameraCurseur>().enabled = false;
        }
    }
}

  