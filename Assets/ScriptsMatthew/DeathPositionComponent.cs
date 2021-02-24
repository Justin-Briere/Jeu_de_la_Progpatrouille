using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPositionComponent : MonoBehaviour
{
    /// <summary>
    /// Lorsqu'un joueur avec le tag Player entre en collision avec l'objet, il meurt
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.transform.position =
                GameManager.Instance.lastCheckPoint.position;
    }
}
