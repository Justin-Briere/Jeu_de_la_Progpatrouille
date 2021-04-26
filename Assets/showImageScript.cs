using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImageScript : MonoBehaviour
{
    RawImage Image;
    bool once = true;
    TimeManager verif;

    public Light light1;
    public Light light2;
    private void Start()
    {
        
        StartCoroutine(Wait());
        Image = GetComponent<RawImage>();
    }
   

    // Update is called once per frame
    void Update()

    {
        var test = GameObject.FindGameObjectWithTag("key");
        if ( test == null) Image.enabled = true;
        if (!once && TryGetComponent<GameObject>(out GameObject clef))
        {
            light1.enabled = true;
            light2.enabled = false;
            CreateLight();
            Image.enabled = true;
        }


            

    }
    private void CreateLight()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        // Set the position (or any transform property)
        lightGameObject.transform.position = new Vector3(0, 5, 0);
    }
    public IEnumerator Wait()
    {
        if (once)
        {
            once = false;
            yield return new WaitForSeconds(1f);
        }
    }
   
}
