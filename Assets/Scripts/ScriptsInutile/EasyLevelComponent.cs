using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyLevelComponent : MonoBehaviour
{
    //public bool DifficultéFacile = false;
    //public bool DifficultéIntermédiaire = false;
    //public bool DifficultéDifficile = false;
    //[SerializeField]
    //Scene next;
    //private void DéterminerDifficultéJeu()
    //{
    //    if (gameObject.layer == 13)
    //        DifficultéFacile = true;
    //    else if (gameObject.layer == 14)
    //        DifficultéIntermédiaire = true;
    //    else if (gameObject.layer == 15)
    //        DifficultéDifficile = true;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        
           
            //Debug.Log("Collision Detected");
            SceneManager.LoadScene("TESTVAISSEAU");
            
            
        
    }

    
}
