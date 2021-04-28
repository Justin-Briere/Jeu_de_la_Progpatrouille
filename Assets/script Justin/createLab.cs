using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLab : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject wall;
    char[,] Map;

    Dijkstra AlgoDijkstra { get; set; }
    Carte maCarte { get; set; }



    void Start()
    {
        maCarte = new Carte("Map0.txt");
        AlgoDijkstra = new Dijkstra(maCarte);
        Map = AlgoDijkstra.MapFinal;

        Create();
    }

    private void Create()
    {
        for(int i=0; i<Map.GetLength(0);++i)
        {
            for (int j = 0; j < Map.GetLength(1); ++j)
            {
                var test = Map[j, i] == '*' ? Instantiate(wall, new Vector3(2*j,0,2*i), new Quaternion(0,0,0,0)) : null;

            }
        }
    }

   
}
