using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEnterComponent : MonoBehaviour
{
     int Range =  2;
    RaycastHit Hit;
    int layerMask;
    void Start()
    {
        layerMask = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
        var DirectionRay = transform.TransformDirection(Vector3.forward * 10f);
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, Mathf.Infinity, layerMask))//if (Physics.Raycast(transform.position, DirectionRay, 10f ))
        {
            Debug.Log("Did Hit");
            Debug.DrawRay(transform.position, DirectionRay * Range, Color.blue);
            if (Hit.collider.CompareTag("Player"))
            {
               // AddHighlight(Hit.collider.gameObject);
                
                if (/*Input.GetButtonDown ("Fire1")*/  Input.GetKeyDown(KeyCode.M))
                 {
                    Debug.Log("Did Hit 2");
                    // Hit.collider.Send$$anonymous$$essageUpwards("Active", Send$$anonymous$m$essageOptions.DontRequireReceiver);
                    Hit.collider.SendMessage("Active");
                }
            }
        }
    }
}
