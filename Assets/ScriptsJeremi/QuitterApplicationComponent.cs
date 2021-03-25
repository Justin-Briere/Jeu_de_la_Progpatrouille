using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitterApplicationComponent : MonoBehaviour
{
    public void Quitter()  //Script dernière session
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit();
#endif
    }

}
//public void QuitGame()
//    {
//        Application.Quit();
//        Debug.Log("Game is exiting");
//    }
//}

