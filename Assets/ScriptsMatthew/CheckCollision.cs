using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    //GameObject neutre et vide qui contient la corps solide (plateforme)
    GameObject PFneutre;
    
   /// <summary>
   /// Set la vitesse du joueur à celle de la plateforme en mouvement
   /// </summary>
   /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //var colPF = PFneutre.GetComponentInChildren<BoxCollider>();
        if (collision.gameObject.CompareTag("Player"))
        {
            PFneutre = transform.parent.gameObject;
            collision.gameObject.transform.SetParent(PFneutre.transform);
            //PFneutre.transform.position = collision.transform.position;
            //collision.transform.SetParent(transform);
        }
    }
    /// <summary>
    /// Enlève la collision qui était parent et la set à null pour que le 
    /// joueur reprenne sa vitesse
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        //var colPF = PFneutre.GetComponentInChildren<BoxCollider>();
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(null);
    }
}
