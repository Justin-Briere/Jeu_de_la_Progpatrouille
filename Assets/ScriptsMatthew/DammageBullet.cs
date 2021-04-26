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
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnnemyHealt>().HurtEnnemy(damage);
            Destroy(Bullets);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "targets")
        {
            Destroy(other.gameObject);
            Destroy(Bullets);
        }    
    }
}
