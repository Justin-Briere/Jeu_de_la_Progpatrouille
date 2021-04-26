using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public Light light1;
    public Light light2;
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;
    Light lt;
    bool lightOn;
    Light lightComp;
    NaviguationInLab Map;
    void Start()
    {
        Map = GetComponent<NaviguationInLab>();
        //light1.enabled = true;
        //light2.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        lightOn = true;
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.intensity = 20;

         lightGameObject.transform.position = new Vector3(Map.width / 2, 1f, (-Map.height / 2) - 1);
        // Set color and position
        lightComp.color = Color.white;
        
       // lightComp.color = Color.Lerp(color0, color1, t);
        // Set the position (or any transform property)

       
    }
    void Update()
    {
        while (lightOn)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            //lt.color = 
            lightComp.color = Color.Lerp(color0, color1, t);
        }
    }
}
