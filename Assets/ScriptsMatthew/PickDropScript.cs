using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDropScript: MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.F;
    public KeyCode dropKey = KeyCode.G;
    string weaponTag = "Gun";

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

        //Pickup
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(weaponTag) && Input.GetKeyDown(pickupKey))
            {

                hit.collider.gameObject.SetActive(true);

                hit.transform.parent = hand;
                hit.transform.position = hand.position;
                hit.transform.rotation = hand.rotation;
            }
        }

        // DROP WEAPONS
        
        if (Input.GetKeyDown(dropKey) && currentWeapon != null)
        {

            currentWeapon.transform.parent = null;

            currentWeapon.transform.position = dropPoint.position;
            //currentWeapon = null;
        }
    }
}
