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
        bandit = GameObject.Find("Voleur");

    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
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
        if (gameObject.tag == "button")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    //private void OnMouseDown()
    //{
    //    //Instantiate(SceneManager.LoadScene("Main Menu", LoadSceneMode ));
    //    SceneManager.LoadScene("Main Menu");
    //}
}

  