using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovComponent : MonoBehaviour
{
    [SerializeField]
    Vector3 speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, Space.Self);
    }
}
