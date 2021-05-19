using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponents : MonoBehaviour //Classe ayant pour but de changer les couleurs des  tuiles touchées,  SI la difficulté est à "Hard" 
{
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;
    public MeshRenderer ListTiles;
     bool HardDifficulty = true;
    void Start()=>ListTiles = GetComponentInChildren<MeshRenderer>();


    /// <summary>
    ///Lors d'une collision entre une tuile et le joueur : la tuile change de couleur SI la difficulté est à "Hard" 
    /// </summary>
    public void OnCollisionEnter()
    {
        HardDifficulty = FindObjectOfType<DifficultyScript>().HardDifficulty;
            if (ListTiles.material.color == WhiteMaterial.color)
                ListTiles.material = BlackMaterial;
            else
            {
                 if (HardDifficulty)
                    ListTiles.material = WhiteMaterial;
            }
    }

}
