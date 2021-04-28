using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLab : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject wall;
    char[,] Map;
    void Start()
    {
        Carte maCarte = new Carte("Map0.txt");
        Dijkstra AlgoDijkstra = new Dijkstra(maCarte);
        Map = AlgoDijkstra.MapFinal;
    }

   
}
