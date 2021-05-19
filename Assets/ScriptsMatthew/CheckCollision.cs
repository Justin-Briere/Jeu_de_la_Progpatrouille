using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    GameObject PFneutre;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PFneutre = transform.parent.gameObject;
            collision.gameObject.transform.SetParent(PFneutre.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(null);
    }
}
