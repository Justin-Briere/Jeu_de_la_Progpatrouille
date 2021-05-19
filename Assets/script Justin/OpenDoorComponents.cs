/// Permet de faire une certaine action lorsque toutes les tiles sont identique
/// 
/// 
//

using System.Collections;
using System.Timers;

using System.Collections.Generic;
using UnityEngine;

public class OpenDoorComponents : MonoBehaviour
{
    public TileComponents[] ListTiles;
     public bool LevelComleted ;
    public float timeToWait = 5;
       [SerializeField]
    private GameObject ModèleExplosion;
    [SerializeField]
    GameObject LeftDoor;
        [SerializeField]
    GameObject floor;
    bool EasyDifficulty;
    void Start()=> StartCoroutine(StartCountdown());
    void Update()
    {
        EasyDifficulty = FindObjectOfType<DifficultyScript>().EasyDifficulty;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (TileComponents Floor in ListTiles)
            {
                Floor.gameObject.GetComponent<MeshRenderer>().material.color = ListTiles[0].gameObject.GetComponent<MeshRenderer>().material.color;
            }

        }
        Test();

    }
    /// <summary>
    /// Regarde si les tuiles sont identiques.
    /// Utilise un compteur puisque dans une foreach c'est très difficile de connaitre le nombre d'itération.
    /// Alors, j'ai décidé d'aller le chercher moi-même!
    /// </summary>
    void Test()
    {
        ListTiles = FindObjectsOfType<TileComponents>(); //Voir façon plus rapide
        var cnt = 0;
        foreach (TileComponents Floor in ListTiles)
        {
            // test si le niveau est fini
            cnt++;
            if (Floor.gameObject.GetComponent<MeshRenderer>().material.color != ListTiles[0].gameObject.GetComponent<MeshRenderer>().material.color && !LevelComleted)
                break;
        }
        if (cnt == ListTiles.Length) LevelComleted = true;
        if (LevelComleted && cnt != 0)      // action lorsque les tuiles sont tous de la mm couleur
        {
            GameObject Explosion = Instantiate(ModèleExplosion, transform.position, ModèleExplosion.transform.rotation);    // feux d'artifice! :o
            Destroy(Explosion, 3);
            foreach (TileComponents Floor in ListTiles)
                Destroy(Floor.gameObject);
            Destroy(GameObject.Find("floor collider").gameObject);
        }
    }
    /// <summary>
    /// Change une Tuile au hasard de couleurs
    /// </summary>
    private void ChangeOneTile()
    {
        TileComponents[] List = FindObjectsOfType<TileComponents>();
        var value = Random.Range(0, List.Length);
        var Initial = List[value].gameObject.GetComponent<MeshRenderer>().material.color;
        List[value].gameObject.GetComponent<MeshRenderer>().material = (Initial == List[1].BlackMaterial.color) ? List[1].WhiteMaterial : List[1].BlackMaterial;
    }
    /// <summary>
    /// Ici, on décide le nombre de secondes pour qu'une tuile au hasard change.
    ///Par défaut j'ai mis 5 secondes pour raccourcir le temps d'attente entre deux changements.
    /// Comme ça on peut bien voir tous les changements. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartCountdown() 
    {
        if (!LevelComleted)
        {
            yield return new WaitForSeconds(timeToWait);
            if (!LevelComleted && !EasyDifficulty)
            ChangeOneTile(); 
            Test();
            StartCoroutine(StartCountdown());
        }
    }
}
