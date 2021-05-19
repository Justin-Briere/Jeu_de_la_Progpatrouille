/// Fonction qui permet de mettre aléatoirement toutes les tuiles d'une couleur.
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{
    public MeshRenderer[] ListTiles;
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;
    void Start()
    {       
        ListTiles = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer Floor in ListTiles)
        {
            if (Floor.material != WhiteMaterial &&
                Floor.material != BlackMaterial)
            {                
                  Floor.material = (Random.value < 0.5)? WhiteMaterial : BlackMaterial;
            }
        } 
    }   
}
