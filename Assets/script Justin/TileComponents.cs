using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponents : MonoBehaviour //Classe ayant pour but de donner une couleur aux les tuiles touchés tout dépendant la difficulté
{
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;
    private ChangeTile test;
    public MeshRenderer[] ListTiles;
    //Material textureBleu;
    GameObject IsFinish;
     bool HardDifficulty = true;
    void Start()
    {
        IsFinish = FindObjectOfType <OpenDoorComponents>().gameObject;
        ListTiles = GetComponentsInChildren<MeshRenderer>();
    }

    /// <summary>
    /// Lors d'une collision avec le joueur, la tuile change de couleur 
    /// </summary>
    public void OnCollisionEnter()
    {
        HardDifficulty = FindObjectOfType<DifficultyScript>().HardDifficulty;  
        var done = IsFinish.GetComponent<OpenDoorComponents>();
       
        if (!done.LevelComleted)       
            foreach (MeshRenderer Floor in ListTiles)
            {
              
                if (Floor.material.color == WhiteMaterial.color)
                {
                    Floor.material = BlackMaterial;
                }
                else 
                {                   
                    if(HardDifficulty)
                    Floor.material = WhiteMaterial;
                }
            }        
    }
}
