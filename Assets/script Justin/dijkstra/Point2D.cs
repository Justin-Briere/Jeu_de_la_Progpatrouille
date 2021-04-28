using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2D : MonoBehaviour
{
    //struct Point2D
    //{
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point2D(int valX, int valY)
        {
            X = valX;
            Y = valY;
        }
    //}
}
