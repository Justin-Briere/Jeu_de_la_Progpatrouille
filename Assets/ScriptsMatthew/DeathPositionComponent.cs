using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPositionComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.transform.position =
                GameManager.Instance.lastCheckPoint.position;
    }
}
