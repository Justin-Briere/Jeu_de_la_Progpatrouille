using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AdaptLevel : MonoBehaviour
{
    // Start is called before the first frame update

   // public GameObject PolicePrefab;
    public GameObject[] Police2;
    public GameObject[] Police3;
    public GameObject[] Police;

    void Start()
    {
        //if (KeepOverTimeComponent.difficulty == 1)
        //{
        //    Police2 = GameObject.FindGameObjectsWithTag("PoliceMedium");
        //    Police3 = GameObject.FindGameObjectsWithTag("PoliceHard");
        //    Police = Police2.Concat(Police3).ToArray();
        //}

        //if (KeepOverTimeComponent.difficulty == 2)
        //{
        //    Police = GameObject.FindGameObjectsWithTag("PoliceHard");
        //}


        ////HardMode do nothing

        //foreach (GameObject policier in Police)
        //{
        //    Destroy(policier);
        //}


    }


}
