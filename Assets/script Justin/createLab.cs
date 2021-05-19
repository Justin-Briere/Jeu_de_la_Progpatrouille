﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class createLab : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject wall;
    [SerializeField]
    GameObject Key;
    char[,] Map;
    GameObject EndPoint;
    GameObject Player;
    GameObject Clef;
    Dijkstra AlgoDijkstra { get; set; }
    Carte maCarte { get; set; }
   
    
    void Start()
    {
        maCarte = new Carte("Map0.txt");
        AlgoDijkstra = new Dijkstra(maCarte);
        Map = AlgoDijkstra.MapFinal;
        EndPoint = GameObject.Find("ENDPOINT").gameObject;
        Player = GameObject.Find("Bandit Variant").gameObject;
        Clef = GameObject.Find("clef").gameObject;
        //FindObjectOfType < GameObject.Find("ENDPOINT") > ();

        Create();
      
       // Instantiate(Key, new Vector3(10.1f , 0, 5.5f), new Quaternion(0, 0, 0, 0));
    }

    private void Create()
    {
        for (int i = 0; i < Map.GetLength(0); ++i)
        {
            for (int j = 0; j < Map.GetLength(1); ++j)
            {
                 if( (Map[j, i]== '*') || (i == 0 || j == 0))  create(i, j) ;
                if ((Map[j, i] == 'D')) EndPoint.transform.position = new Vector3(wall.transform.localScale.x * j, 0, wall.transform.localScale.y * i);
                if ((Map[j, i] == 'I'))
                {
                    Clef.transform.position = new Vector3(wall.transform.localScale.x * j , 0, wall.transform.localScale.y * i +2);
                    Player.transform.position = new Vector3(wall.transform.localScale.x * j, 0, wall.transform.localScale.y * i);
                }


            }
        }
        
    }
    public void create(int i, int j)
    {
        Vector3 test;
        if (j == 0)
        {
            test = new Vector3(0, 0, wall.transform.localScale.x * i);
        }
        else if (i == 0)
        {
            test = new Vector3(wall.transform.localScale.x * j, 0, 0);
        }
        else 
        {
            test = new Vector3(wall.transform.localScale.x * j, 0, wall.transform.localScale.y * i);
        }
        //t = (i == 0 || j == 0) ? (j == 0) ? new Vector3(0, 0, wall.transform.localScale.x * i) : new Vector3(wall.transform.localScale.x * j, 0, 0) : new Vector3(wall.transform.localScale.x * j, 0, wall.transform.localScale.y * i);

        Instantiate(wall,test, new Quaternion(0, 0, 0, 0));
    }



}
