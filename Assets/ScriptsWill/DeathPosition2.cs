using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPosition2 : MonoBehaviour
{
    /// <summary>
    /// Lorsqu'un joueur avec le tag Player entre en collision avec l'objet, il meurt
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameOverScript>().StopGame();

            //other.gameObject.transform.position =
            //    GameManager.Instance.lastCheckPoint.position;
        }
    }
}
