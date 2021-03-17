using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpinComponent : MonoBehaviour
{
    //Composante permettant de spin/rotate les joueurs sur l'une des 3 axes

    [SerializeField]
    private float RotationPerSecond = 400;
    private Vector3 vector;





    public void SpinUp() => Spin(vector = new Vector3(-1, 0, 0));
    public void SpinDown() => Spin(vector = new Vector3(1, 0, 0));
    public void SpinRight() => Spin(vector = new Vector3(0, 1, 0));
    public void SpinLeft() => Spin(vector = new Vector3(0, -1, 0));
    public void RotationLeft() => Spin(vector = new Vector3(0, 0, 1));
    public void RotationRight() => Spin(vector = new Vector3(0, 0, -1));
    public void Spin(Vector3 vector) => transform.Rotate(vector * (RotationPerSecond * Time.deltaTime));
}