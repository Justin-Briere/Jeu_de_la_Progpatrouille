using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammageBullet : MonoBehaviour
{
    int damage = 10;
    [SerializeField]
    GameObject Bullets;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<EnnemyHealt>().HurtEnnemy(damage);
            Destroy(Bullets);
        }
    }
}
