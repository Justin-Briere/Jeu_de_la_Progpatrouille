/// Fonction qui permet de mettre toutes les tiles d'une couleurs différente
/// 








using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTile : MonoBehaviour
{
    // Start is called before the first frame update
   
    private int NbTiles = 49;
    
    public MeshRenderer[] ListTiles;
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;

    TileComponents textureBleu;
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
