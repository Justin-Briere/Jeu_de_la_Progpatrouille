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
        Image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()

    {
        
        if (TryGetComponent<GameObject>(out GameObject clef)) Image.enabled = true ;
            

    }
    private IEnumerable Wait()
    {
        if (once)
        {
            once = false;
            yield return new WaitForSeconds(10);
        }
    }
}
