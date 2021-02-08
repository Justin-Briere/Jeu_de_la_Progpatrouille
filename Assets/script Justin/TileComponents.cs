using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileComponents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Material BlackMaterial;
    [SerializeField]
    public Material WhiteMaterial;
    private ChangeTile test;
    public MeshRenderer[] ListTiles;
    Material textureBleu;
    //private BoxCollider[] ListTiles;
    void Start()
    {
        //MAt = GetComponent<Renderer>().material;
        //ListTiles = GetComponentsInChildren<BoxCollider>();
        ListTiles = GetComponentsInChildren<MeshRenderer>();
        
        //  ListTiles[1].material = textureBleu;
        var ajds = 1;

        //BlackMaterial = textureBleu;


    }
    public void OnCollisionEnter()

    {
       // print("aalalall");
        
        //if (other.gameObject.layer == 9)
        //{
            //Debug.Log("fnjsdnbfjsdfd");
        //  Destroy(other.gameObject);
        var text = gameObject.GetComponent<Material>();
        foreach (MeshRenderer Floor in ListTiles)
        {
            //if ((Floor.gameObject.transform.position.x - gameObject.transform.position.x) <= 0.001 &&
            //    (Floor.gameObject.transform.position.y - gameObject.transform.position.y) <= 0.001)
            //{
                Debug.Log("Je passe dans TileComponents");
                // Floor.material.color = Color.clear;
                if (Floor.material.color == WhiteMaterial.color)
                {
                    Floor.material = BlackMaterial;
                }
                else { Floor.material = WhiteMaterial; }


               
                //Floor.material = Texture;
            


        }
        text = BlackMaterial;
        var x = gameObject.transform.position.x;
        var y = gameObject.transform.position.y;
       // test.Change(x, y);
           // MAt.color = Color.blue;

       // }
    }
    private void OnMouseDown()
    {
        foreach (MeshRenderer Floor in ListTiles)
        {
            //if ((Floor.gameObject.transform.position.x - gameObject.transform.position.x) <= 0.001 &&
            //    (Floor.gameObject.transform.position.y - gameObject.transform.position.y) <= 0.001)
            //{
            Debug.Log("Je passe dans TileComponents");
            // Floor.material.color = Color.clear;
            if (Floor.material.color == WhiteMaterial.color)
            {
                Floor.material = BlackMaterial;
            }
            else { Floor.material = WhiteMaterial; }



            //Floor.material = Texture;



        }

    }



}
