/// Permet de faire une certaine action dans le script Action, lorsque toutes les tiles sont identique
/// 
/// 
/// ATTENTION, CHANGER LA FONCTION START!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

using System.Collections;


using System.Collections.Generic;
using UnityEngine;

public class OpenDoorComponents : MonoBehaviour
{
    public TileComponents[] ListTiles;
    bool LevelComleted = true;
   
    void Test()                            // regarde si les tiles sont identique.
    {
        ListTiles = FindObjectsOfType<TileComponents>();
        
        //var CurrentMat = ListTiles[1];
        //ListTiles[0] = CurrentMat;
        foreach (TileComponents Floor in ListTiles)

        {

            if (Floor.gameObject.GetComponent<MeshRenderer>().material.color != ListTiles[0].gameObject.GetComponent<MeshRenderer>().material.color)

            {
                LevelComleted = false;
                Debug.Log("Non");
                break;
            }
            else
            {
                
            }


        }

        if (LevelComleted) { Debug.Log("OUI!!!"); }
        LevelComleted = true;
    }

    // Update is called once per frame
    private void OnMouseDown()                          // fonction qui permet de call le start par clicker sur un items.
    {
        if ( gameObject.layer == 9 )
            Test();
    }
}
