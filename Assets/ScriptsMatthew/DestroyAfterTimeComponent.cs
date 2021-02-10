using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTimeComponent : MonoBehaviour
{
    [SerializeField]
    private float time;

    private float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > time)
            Destroy(gameObject);
    }
}
