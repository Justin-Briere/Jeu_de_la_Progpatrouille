using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstriggerClef : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other) => Destroy(this.gameObject);
      
   
    
}
