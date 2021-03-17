using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public bool verification = true;
    public void Attendre()
    {
        StartCoroutine(TempsAttente());
    }

    // Permet d'activer la première plateforme
    public IEnumerator TempsAttente()
    {
        verification = false;
        yield return new WaitForSeconds(3.0f);
        verification = true;
    }
}
