using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDropScript: MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.F;
    public KeyCode dropKey = KeyCode.G;
    const string WEAPONTAG = "Gun";

    public List<GameObject> weapons;

    public GameObject currentWeapon;

    public Transform hand;

    public Transform dropPoint;

    public Transform cam;
    void Awake()
    {
        cam = Camera.main.transform;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.position, cam.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(WEAPONTAG) && Input.GetKeyDown(pickupKey))
            {

                hit.collider.gameObject.SetActive(true);

                hit.transform.position = hand.position;
                hit.transform.rotation = hand.rotation;
                hit.transform.parent = hand;
            }
        }
        
        if (Input.GetKeyDown(dropKey) && currentWeapon != null)
        {
            currentWeapon.transform.parent = null;

            currentWeapon.transform.position = dropPoint.position;
        }
    }
}
