using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechPointComponent : MonoBehaviour
{
    /// <summary>
    /// Permet de changer le spawn point du joueur lorsqu'il passe sur le game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //ou layer selon un nombre MAIS VOIR AVEC 
            GameManager.Instance.lastCheckPoint = transform;
    }
}
