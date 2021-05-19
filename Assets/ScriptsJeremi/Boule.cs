using System.Collections.Generic;
using UnityEngine;


public sealed class Boule : MonoBehaviour
{
    const float MIN_LATITUDE = -Mathf.PI / 2; 
    const float MAX_LATITUDE = Mathf.PI / 2; 
    const float MIN_LONGITUDE = -Mathf.PI; 
    const float MAX_LONGITUDE = Mathf.PI; 

    const int TILES_TRIANGLE = 2;
    const int APEX_TRIANGLE = 3;

    [SerializeField]
    private float RayonBoule;

    [SerializeField]
    private Vector2 Charpente;

    [SerializeField]
    private bool EstCarrelé;

    [SerializeField]
    private Material MatériauBoule;

    private int NbApex { get; set; }

    private Vector3[] Apex { get; set; }

    private int Columns { get; set; }

    private int Rows { get; set; }

    private Mesh Mesh { get; set; }

    private Vector2[] CoordsTexture { get; set; }


    void Awake()
    {
        CalculateInitialValues();
        CreateMesh();
        GenerateEnvelopCollison();
    }
    private void CalculateInitialValues()
    {
        Columns = (int)Charpente.x;
        Rows = (int)Charpente.y;
        NbApex = (Columns + 1) * (Rows + 1);
    }

    private void CreateMesh()
    {
        Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = Mesh;
        Mesh.name = "Boule";
        Apex = CreateApexAndCoordsTexture();
        Mesh.vertices = Apex;
        Mesh.triangles = CreateTriangles();
        Mesh.uv = CoordsTexture;
        Mesh.RecalculateNormals(); 
        Mesh.tangents = CalculerTangentes();
        GetComponent<MeshRenderer>().material = MatériauBoule;
    }

    private Vector3[] CreateApexAndCoordsTexture() 
    {
        Vector2 CoordTexture;

        CoordsTexture = new Vector2[0];
        int cpt = 0;

        if (!EstCarrelé)
            CoordTexture = new Vector2(1 / Charpente.x, 1 / Charpente.y);
        else
            CoordTexture = new Vector2(1, 1);

        Vector2 position = new Vector2((2 * MAX_LONGITUDE) / Columns, MAX_LONGITUDE / Rows);
        Vector3[] apex = new Vector3[NbApex];

        CoordsTexture = new Vector2[NbApex];

        float currentLatitude = MIN_LATITUDE;
        float yCoordsTexture = 0;
        for (int i = 0; i < Rows + 1; ++i) //Le +1 sert a revenir au point de depart
        {
            float xCoordsTexture = 0; //le 0 est super important et nous l'appris à la dure ...
            float currentLongitude = MIN_LONGITUDE;
            for (int j = 0; j < Columns + 1; ++j)
            {
                float xApex = RayonBoule * AngleRad(currentLatitude, MAX_LATITUDE) * AngleRad(currentLongitude, MAX_LATITUDE); //Fortement inspiré des pages Wikipedia
                float yApex = RayonBoule * AngleRad(0, currentLatitude);
                float zApex = RayonBoule * AngleRad(currentLatitude, currentLongitude);

                apex[cpt] = new Vector3(xApex, yApex, zApex);
                CoordsTexture[cpt++] = new Vector2(xCoordsTexture, yCoordsTexture);
                xCoordsTexture += CoordTexture.x;
                currentLongitude += position.x;
            }

            currentLatitude += position.y;
            yCoordsTexture += CoordTexture.y;
        }

        return apex;
    }


    float AngleRad(float cosValue, float sinValue) => (Mathf.Cos(cosValue) * Mathf.Sin(sinValue)); 
    private int[] CreateTriangles() 
    {
        int[] triangles = new int[Columns * Rows * TILES_TRIANGLE * APEX_TRIANGLE]; // 2*3 pour calculer le nombre de triangles dans les Boules
        int cpt = 0;

        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; ++j)
            {
                int cptTriangles = j + (Columns + 1) * i;
                int tmpTriangle = cptTriangles + Columns + 1;

                AddTriangles(triangles, cptTriangles, tmpTriangle, cptTriangles + 1, ref cpt);
                AddTriangles(triangles, tmpTriangle, tmpTriangle + 1, cptTriangles + 1, ref cpt);
            }
        }

        return triangles;
    }
    private void AddTriangles(int[] triangles, int triangle1, int triangle2, int triangle3, ref int cpt)
    {
        triangles[cpt++] = triangle1; //on peut pas faire ++cpt
        triangles[cpt++] = triangle2;
        triangles[cpt++] = triangle3;
    }
   
    private Vector4[] CalculerTangentes()
    {
        //Génère un tableau contenant les tangentes à chacun des sommets, ce qui permet l'utilisation de la texture en relief (bump map) sur la primitive.
        Vector4[] tangentes = new Vector4[Apex.Length];
        Vector4 tangenteDeBase = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0; i < tangentes.Length; ++i)
        {
            tangentes[i] = tangenteDeBase;
        }
        return tangentes;
    }
    private void GenerateEnvelopCollison()
    {
        SphereCollider enveloppe = GetComponent<SphereCollider>();
        enveloppe.radius = RayonBoule;
    }
}