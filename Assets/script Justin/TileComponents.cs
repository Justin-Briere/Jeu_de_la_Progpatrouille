using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponents : MonoBehaviour
{
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;
    private ChangeTile test;
    public MeshRenderer[] ListTiles;
    Material textureBleu;
    GameObject IsFinish;
     bool HardDifficulty = true;
    void Start()
    {
        IsFinish = FindObjectOfType <OpenDoorComponents>().gameObject;
        ListTiles = GetComponentsInChildren<MeshRenderer>();
    }
    public void OnCollisionEnter()
    {
         HardDifficulty = FindObjectOfType<DifficultyScript>().HardDifficulty; 
       
        
        var Done = IsFinish.GetComponent<OpenDoorComponents>();
       
        var text = gameObject.GetComponent<Material>();
        if (!Done.LevelComleted)       
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
    private void OnMouseDown()
    {
        foreach (MeshRenderer Floor in ListTiles)
        {
            
            if (Floor.material.color == WhiteMaterial.color)
            {
                Floor.material = BlackMaterial;
            }
            else { Floor.material = WhiteMaterial; }
        }

    }



}
