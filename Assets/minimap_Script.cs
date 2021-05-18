using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap_Script : MonoBehaviour
{
    public Transform player;
    public Camera minimap;
    private void LateUpdate()
    {
    
        
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;

           
        
    }
   
}
