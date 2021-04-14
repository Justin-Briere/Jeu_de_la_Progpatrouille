using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPolice : MonoBehaviour
{
    /// <summary>
    /// Permet de changer le spawn point du joueur lorsqu'il passe sur le game object
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager.Instance.lastCheckPoint = transform;
    }
}
