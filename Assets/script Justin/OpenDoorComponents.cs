/// Permet de faire une certaine action dans le script Action, lorsque toutes les tiles sont identique
/// 
/// 
/// ATTENTION, CHANGER LA FONCTION START!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

using System.Collections;
using System.Timers;

using System.Collections.Generic;
using UnityEngine;

public class OpenDoorComponents : MonoBehaviour
{
    public TileComponents[] ListTiles;
    bool LevelComleted = true;
    private static System.Timers.Timer aTimer;
    int cnt = 0;
    float timeToWait = 3;
    float timer = 0;
    void Start()
    {
        //Timer();
    }
    void Update()
    {
        
        timer += Time.deltaTime;
        Debug.Log(timer);
        
//if (timer > 2.901f) timer = 0f;
        if ((timeToWait - timer) <= 0.0001)
        {
            timer = timer - timer;

            ChangeOneTile();


        }
       
        Test();
    }
   
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
        if (gameObject.layer == 9)
        {
            Test();
            
        }
        
    }
   
    private void ChangeOneTile()
    {
        timer = 0;

        TileComponents[] List = FindObjectsOfType<TileComponents>();
        var value = Random.Range(0, List.Length);
        if (List[value].gameObject.GetComponent<MeshRenderer>().material.color == List[1].BlackMaterial.color)
            List[value].gameObject.GetComponent<MeshRenderer>().material = List[1].WhiteMaterial;
        else
        {
            List[value].gameObject.GetComponent<MeshRenderer>().material = List[1].BlackMaterial;
        }

      
    }
}
