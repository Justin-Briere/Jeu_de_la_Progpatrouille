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
    void Start()
    {
        IsFinish = FindObjectOfType <OpenDoorComponents>().gameObject;
        ListTiles = GetComponentsInChildren<MeshRenderer>();
    }
    public void OnCollisionEnter()

    {
        var Done = IsFinish.GetComponent<OpenDoorComponents>();
        
        var text = gameObject.GetComponent<Material>();
        if (!Done.LevelComleted)
        {
            foreach (MeshRenderer Floor in ListTiles)
            {
                Debug.Log("Je passe dans TileComponents");
                if (Floor.material.color == WhiteMaterial.color)
                {
                    Floor.material = BlackMaterial;
                }
                else { Floor.material = WhiteMaterial; }
            }
        }
    }
    private void OnMouseDown()
    {
        foreach (MeshRenderer Floor in ListTiles)
        {
            Debug.Log("Je passe dans TileComponents");
            if (Floor.material.color == WhiteMaterial.color)
            {
                Floor.material = BlackMaterial;
            }
            else { Floor.material = WhiteMaterial; }
        }

    }



}
