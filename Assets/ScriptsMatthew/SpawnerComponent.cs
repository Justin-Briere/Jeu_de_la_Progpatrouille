using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField]
    GameObject objectToClone;

    [SerializeField]
    Transform spawnPosition;

    [SerializeField]
    float fireRate;

    float nextFire = 0.0f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && transform.parent != null &&
            transform.gameObject.CompareTag("Gun"))
        {
            nextFire = Time.time + fireRate;
            Spawn();
        }
    }
    public void Spawn()
    {
        var spawned = Instantiate(objectToClone, spawnPosition.position, transform.rotation);
        spawned.transform.localScale = transform.localScale;
    }
}
                                          