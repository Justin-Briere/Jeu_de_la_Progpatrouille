
using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Tore : MonoBehaviour   //Script de la dernière session pour le Galaga faisant le mesh du tore.
{
    const int TILES_TRIANGLE = 2;
    const int APEX_TRIANGLE = 3;
    const float LENGTH_TRIGO_CERCLE = 2f * (float)Math.PI;

    [SerializeField]
    float RayonTore;

    [SerializeField]
    Vector2 RayonsTubeTore;

    [SerializeField]
    int NbPointsCercleTore;

    [SerializeField]
    int NbPointsCercleTube;

    [SerializeField]
    bool EstCarrelé;

    [SerializeField]
    Material MatériauTore;

    List<Vector3> PointsTore { get; set; } 

    List<Vector3>[] ListOutsideTube { get; set; } 
    int Rows { get; set; }
    int Columns { get; set; }
    Mesh Mesh { get; set; }

    int NbApex { get; set; }

    Vector3[] Apex { get; set; }

    Vector2 Texture { get; set; }

    void Awake()
    {
        CalculateInitialValues();
        CreatePointsTore();
        CreateInsideCercle();
        CreateMesh();
        GenerateEnvolepCollison();
    }

    private void CalculateInitialValues()
    {
        Columns = NbPointsCercleTube + 1;
        Rows = NbPointsCercleTore + 1;
        NbApex = Columns * Rows;

        if (EstCarrelé)
            Texture = new Vector2(1, 1);
        else
            Texture = new Vector2(1f / Columns, 1f / Rows);
    }

    private void CreatePointsTore()
    {
        PointsTore = new List<Vector3>(NbPointsCercleTore);
        double sommation = 0;
        double positionPoint = LENGTH_TRIGO_CERCLE / NbPointsCercleTore;
        for (int i = 0; i <= NbPointsCercleTore; ++i)
        {
            PointsTore.Add(new Vector3(Vector3.zero.x + RayonTore * (float)Math.Cos(sommation), Vector3.zero.y, Vector3.zero.z + RayonTore * (float)Math.Sin(sommation)));
            sommation += positionPoint;
        }
    }

    private void CreateInsideCercle() //Nous avons eu de l'aide de Vincent
    {
        ListOutsideTube = CreateOutsideTube(NbPointsCercleTore, NbPointsCercleTube);

        float alpha = 0f;
        float beta = 0f;
        float verticalAngularStride = (float)(Math.PI * 2f) / NbPointsCercleTube;
        float horizontalAngularStride = ((float)Math.PI * 2f) / NbPointsCercleTube;

        for (int i = 0; i < PointsTore.Count - 1; ++i)
        {

            alpha = verticalAngularStride * i;

            //Vector3 v1 = PointsTore[i + 1] - PointsTore[i]; //Pour former le vecteur AB, il faut faire B-A
            //Vector3 v2 = Vector3.Normalize(new Vector3(-v1.z, 0, v1.x)); //La premiere etape est d'inverser les 2 coordonnés du vecteur puis le mettre un négatif au premier.
            //Vector3 v3 = Vector3.Normalize(Vector3.Cross(v1, v2)); //Trouver la normale comme dans Maple avec un produit vectoriel

            for (int j = 0; j < NbPointsCercleTube; ++j)
            {
                beta = horizontalAngularStride * j; //Inspiration de la page Wikipedia
                float x = (float)Math.Cos(alpha) * (RayonsTubeTore.x * (float)Math.Cos(beta));
                float y = RayonsTubeTore.x * (float)Math.Sin(alpha) * (RayonsTubeTore.y * (float)Math.Cos(beta));
                float z = RayonsTubeTore.x * RayonsTubeTore.y * (float)Math.Sin(beta);
                Vector3 CoordonneeTorus = PointsTore[i] + new Vector3(x, z, y);
                ListOutsideTube[i].Add(CoordonneeTorus);
            }

            ListOutsideTube[i].Add(ListOutsideTube[i][0]); //Add l'obj à l'indice
        }
        for (int cpt = 0; cpt <= NbPointsCercleTube; ++cpt)
            ListOutsideTube[PointsTore.Count - 1].Add(ListOutsideTube[0][cpt]); 
    }

    private List<Vector3>[] CreateOutsideTube(int nbPointsCercleTore, int nbPointsCercleTube) 
    {
        List<Vector3>[] outsideTube = new List<Vector3>[nbPointsCercleTore + 1]; //+grand
        for (int i = 0; i < PointsTore.Count; ++i)
            outsideTube[i] = new List<Vector3>(nbPointsCercleTube + 1); //+petit

        return outsideTube;
    }
    private void CreateMesh()
    {
        Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = Mesh;
        Mesh.name = nameof(Tore);
        Apex = CreateApex();
        Mesh.vertices = Apex;
        Mesh.triangles = CreateTriangles(); //visualisation grace au ShowVertices
        Mesh.uv = GenerateCoordsTexture();
        Mesh.RecalculateNormals();
        Mesh.tangents = CalculerTangentes();
        GetComponent<MeshRenderer>().material = MatériauTore;
    }

    private Vector3[] CreateApex()
    {
        int cpt = 0;
        Vector3[] apex = new Vector3[NbApex];
        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; ++j)
                apex[cpt++] = ListOutsideTube[i][j];
        }

        return apex;
    }

    private int[] CreateTriangles() //Revoir les exercices sur la maillage
    {
        int cpt = 0;
        int[] triangles = new int[(Columns - 1) * (Rows - 1) * TILES_TRIANGLE * APEX_TRIANGLE]; //2*3
        for (int i = 0; i < Rows-1; ++i) //-3
            for (int j = 0; j < Columns-1; ++j)//-3
            {
                int tmpApex = j + (i + 1) * Columns;

                int apex1 = tmpApex + 1;
                int apex2 = j + i * Columns;
                int apex3 = apex2 + 1;

                AddTriangles(triangles, tmpApex, apex2, apex3, ref cpt);
                AddTriangles(triangles, apex1, tmpApex, apex3, ref cpt);
            }

        return triangles;
    }

    private void AddTriangles(int[] triangles, int apex1, int apex2, int apex3, ref int cpt)
    {
        triangles[cpt++] = apex1; //on peut pas faire ++cpt
        triangles[cpt++] = apex2;
        triangles[cpt++] = apex3;
    }

    private Vector2[] GenerateCoordsTexture()
    {
        int cpt = 0;
        Vector2[] vector = new Vector2[NbApex];
        for (int i = 0; i < Rows; ++i)
            for (int j = 0; j < Columns; ++j)
            {
                float x = Texture.x * j;
                float y = Texture.y * i;
                vector[cpt++] = new Vector2(x, y);
            }

        return vector;
    }

    private Vector4[] CalculerTangentes()
    {
        Vector4[] vector4Array = new Vector4[Apex.Length];
        Vector4 vector4 = new Vector4(1f, 1f, 1f, -1f);
        for (int index = 0; index < vector4Array.Length; ++index)
            vector4Array[index] = vector4;
        return vector4Array;
    }

    private void GenerateEnvolepCollison()
    {
        GetComponent<MeshCollider>().sharedMesh = Mesh;
    }
}
