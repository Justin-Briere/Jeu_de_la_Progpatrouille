using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitterApplicationComponent : MonoBehaviour
{
    public void Quitter()  //Script dernière session servant à quitter au menu.
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();
#endif
    }
}

