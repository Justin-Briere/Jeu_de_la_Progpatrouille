using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showImageScript : MonoBehaviour
{
    RawImage Image;
    bool once = true;
    TimeManager verif;
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
        if (!once && TryGetComponent<GameObject>(out GameObject clef)) Image.enabled = true ;
            

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
