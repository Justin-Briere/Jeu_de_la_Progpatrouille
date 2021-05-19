using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class DataSpline //Les docuements de JF nous on été très utile
{
    private string PATH = Application.dataPath + "/Ressources/Data/";
    const int NB_POINTS = 8;

    List<Vector3> ListPoints { get; set; }

    List<string[]> DataSplineString { get; set; }

    List<double[]> CoordsX { get; set; } //comme dans la PFI3 avec JF (Maple)

    List<double[]> CoordsY { get; set; } //comme dans la PFI3 avec JF (Maple)

    public DataSpline(string nameDocument)
    {
        DataSplineString = ReadData(nameDocument); //Le hardcoder est plus facile tant que je ne touche pas a ma const NB_POINTS
        CoordsX = GetCoordsFromPoints(DataSplineString, 0, 3);// 4 premiers points
        CoordsY = GetCoordsFromPoints(DataSplineString, 4, 7);// 4 derniers points
        GenerateListPoints();
    }

    private List<string[]> ReadData(string nameDocument) //Comme dans les tp de la session 2 en prog
    {
        char[] separator = new char[1] { '\t' }; //Console.WriteLine()

        List<string[]> dataList = new List<string[]>();
        StreamReader sr = new StreamReader(PATH + nameDocument); // "Assets/Resources/Data/"
        while (!sr.EndOfStream) 
        {
            string txt = sr.ReadLine();
            dataList.Add(txt.Split(separator));
        }
        sr.Close();

        return dataList;
    }

    private List<double[]> GetCoordsFromPoints(List<string[]> data, int firstPoint, int lastPoint)
    {
        List<double[]> dataList = new List<double[]>(data.Count);

        foreach (string[] dataString in data) 
        {
            double[] dataDouble = new double[NB_POINTS/2]; //les tableaux de str dans la liste data
            for (int i = firstPoint; i <= lastPoint; ++i)
                dataDouble[i - firstPoint] = double.Parse(dataString[i], CultureInfo.InvariantCulture); 

            dataList.Add(dataDouble);
        }
        return dataList;
    }

    private void GenerateListPoints()
    {
        ListPoints = new List<Vector3>(DataSplineString.Count * NB_POINTS);

        for (int i = 0; i < DataSplineString.Count; ++i)
        {
            double[] deformationFactorX = CoordsX[i]; //comme dans Maple (PFI3)
            double[] deformationFactorY = CoordsY[i]; //comme dans Maple

            ListPoints.Add(new Vector3(FindActualCoords(deformationFactorX, i), FindActualCoords(deformationFactorY, i), 1));
        }
    }

    private float FindActualCoords(double[] deformationFactor, float deformation)
    {
        return (float)(deformationFactor[0] + deformationFactor[1] * deformation + deformationFactor[2] * (deformation * deformation) + deformationFactor[3] * (deformation * deformation* deformation)); 
    }

    public Vector3[] GetPointsSpline()
    {
        Vector3[] array = new Vector3[ListPoints.Count];
        for (int i = 0; i < ListPoints.Count; ++i)
            array[i] = new Vector3(ListPoints[i].x, ListPoints[i].y, ListPoints[i].z);

        return array;
    }
}
