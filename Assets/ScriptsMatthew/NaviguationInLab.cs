using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviguationInLab : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int largeur = 10;

    [SerializeField]
    [Range(1, 50)]
    private int hauteur = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform prefabWall;

    [SerializeField]
    private Transform prefabFloor;

    void Start()
    {
        var labyrinthe = CreationLab.GenererWalls(largeur, hauteur);
        DessinerLab(labyrinthe);
    }

    private void DessinerLab(WallPosition[,] lab)
    {

        var floor = Instantiate(prefabFloor, transform);
        floor.localScale = new Vector3(largeur, 1, hauteur);

        for (int i = 0; i < largeur; ++i)
        {
            for (int j = 0; j < hauteur; ++j)
            {
                var cell = lab[i, j];
                var position = new Vector3(-largeur / 2 + i, 0, -hauteur / 2 + j);

                if (cell.HasFlag(WallPosition.NORD))
                {
                    var wallHaut = Instantiate(prefabWall, transform); 
                    wallHaut.position = position + new Vector3(0, 0, size / 2);
                    wallHaut.localScale = new Vector3(size, wallHaut.localScale.y, wallHaut.localScale.z);
                }

                if (cell.HasFlag(WallPosition.OUEST))
                {
                    var wallGauche = Instantiate(prefabWall, transform);
                    wallGauche.position = position + new Vector3(-size / 2, 0, 0);
                    wallGauche.localScale = new Vector3(size, wallGauche.localScale.y, wallGauche.localScale.z);
                    wallGauche.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == largeur - 1)
                {
                    if (cell.HasFlag(WallPosition.EST))
                    {
                        var wallDroite = Instantiate(prefabWall, transform);
                        wallDroite.position = position + new Vector3(size / 2, 0, 0);
                        wallDroite.localScale = new Vector3(size, wallDroite.localScale.y, wallDroite.localScale.z);
                        wallDroite.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallPosition.SUD))
                    {
                        var wallBas = Instantiate(prefabWall, transform);
                        wallBas.position = position + new Vector3(0, 0, -size / 2);
                        wallBas.localScale = new Vector3(size, wallBas.localScale.y, wallBas.localScale.z);
                    }
                }
            }

        }

    }
}
