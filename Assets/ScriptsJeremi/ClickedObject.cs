using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickedObject : MonoBehaviour
{
    private Vector3 positionCube;
    GameObject bandit;
    Vector3 positionBandit;
    void Start()
    {
        positionCube = GetComponentInParent<Transform>().position;
        bandit = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
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
    //private void OnMouseDown()
    //{
    //    //Instantiate(SceneManager.LoadScene("Main Menu", LoadSceneMode ));
    //    SceneManager.LoadScene("Main Menu");
    //}
}

  