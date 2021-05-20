
using UnityEngine;

public class Plan : MonoBehaviour  //Script de la dernière session pour le Galaga faisant le mesh du plan
{
    const int SQUARE_TRIANGLE = 2;
    const int APEX_TRIANGLE = 3;

    [SerializeField]
     Vector2 Charpente;

    [SerializeField]
    bool EstCarrelé;

    [SerializeField]
    Material MatériauPlan;

    Mesh Mesh { get; set; }

    Vector3 InitialVector { get; set; }

    Vector3[] Apex { get; set; }

    int NbApex { get; set; }

    int Columns { get; set; }

    int Rows { get; set; }

    Vector2 Texture { get; set; }
    
    void Awake()
    {
        CalculateInitialeValues();
        CreateMesh();
    }

    private void CalculateInitialeValues()
    {
        InitialVector = new Vector3(-0.5f, -0.5f, 0); 
        Columns = (int)Charpente.x;
        Rows = (int)Charpente.y;
        NbApex = (Rows + 1) * (Columns + 1);

        if (!EstCarrelé)
            Texture = new Vector2( 1f / Columns, 1f / Rows);
        else
            Texture = new Vector2(1, 1);
    }

    private void CreateMesh()
    {
        Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = Mesh;
        Mesh.name = "Mesh";
        Apex = CreateApex();
        Mesh.vertices = Apex;
        Mesh.triangles = CreateTriangles();
        Mesh.uv = GenerateCoordsTexture();
        Mesh.RecalculateNormals();
        Mesh.tangents = CalculerTangentes();
        GetComponent<MeshRenderer>().material = MatériauPlan;
    }

    private Vector3[] CreateApex() //Les exercices de maillage nous ont été tres partique
    {
        
        Vector3[] apex = new Vector3[NbApex];
        float inverseNbRows = 1f / Rows;
        float inverseNbColumns = 1f / Columns;
        int cpt = 0;
        for (int i = 0; i <= Rows; ++i)
        {
            for (int j = 0; j <= Columns; ++j)
            {
                float y = i * inverseNbRows;
                float x = j * inverseNbColumns;
                cpt = i * Columns + j + i;
                apex[cpt] = InitialVector + new Vector3(x, y, 0);
            }
        }
        return apex;
    }

    protected int[] CreateTriangles()
    {
        int cpt = 0;
        int[] triangles = new int[Columns * Rows * SQUARE_TRIANGLE * APEX_TRIANGLE]; // 2*3 afin de compter le bon nombre de triangles dans le plan

        for (int i = 0; i < Rows; ++i)
            for (int j = 0; j < Columns; ++j)
            {
                int apex1 = j + i * Columns + i; //Passer a travers tous les points (+i finale permet le faire la diago)
                int tmpApex = apex1 + Columns + 1;
                int apex2 = tmpApex + 1;
                int apex3 = apex1 + 1;

                AddTriangles(triangles, apex1, tmpApex, apex3, ref cpt);
                AddTriangles(triangles, tmpApex, apex2, apex3, ref cpt);
            }

        return triangles;
    }

    private void AddTriangles(int[] triangles, int apexA, int apexB, int apexC, ref int cpt)
    {
        triangles[cpt++] = apexA; //on peut pas faire ++cpt
        triangles[cpt++] = apexB;
        triangles[cpt++] = apexC;
    }

    protected Vector2[] GenerateCoordsTexture()
    {
        Vector2[] vector = new Vector2[NbApex];
        for (int i = 0; i <= Rows; ++i)
            for (int j = 0; j <= Columns; ++j)
            {
                float x = Texture.x * j;
                float y = Texture.y * i;
                vector[j + i * Columns + i] = new Vector2(x, y);
            }

        return vector;
    }

    private Vector4[] CalculerTangentes()
    {
        // Génère un tableau contenant les tangentes à chacun des sommets, ce qui permet l'utilisation de la texture en relief (bump map) sur la primitive.
        Vector4[] tangentes = new Vector4[Apex.Length];
        Vector4 tangenteDeBase = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0; i < tangentes.Length; ++i)
        {
            tangentes[i] = tangenteDeBase;
        }
        return tangentes;
    }
}
