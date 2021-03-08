using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class VisionPolice : MonoBehaviour
{
    [SerializeField]
    private float rayon = 1.0f;

    //[SerializeField]
    private float teta = Mathf.PI / 4 ;

   // [SerializeField]
    private float phi = Mathf.PI/4;


    [SerializeField]
    GameObject vectooore;


    private Vector3 positionPolice;

    private Vector3 positionBandit;

    private float rotationPolice;

    private Vector3 fieldOfView;

    private float x;
    private float y;
    private float z;


    GameObject testPlayer1;
    GameObject testPlayer2;

    void Start()
    {
        x = Mathf.Sin(phi) * Mathf.Cos(teta) * rayon;
        y = Mathf.Sin(phi) * Mathf.Sin(teta) * rayon;
        z = Mathf.Cos(phi) * rayon;

        fieldOfView = new Vector3(x, y, z);

        Debug.Log("rayon est de  :    " + rayon);
    }

    void Update()
    {
        


        positionBandit = GameObject.Find("Bandit").transform.position;

       

        ChekVision();
    }

    private void ChekVision()
    {
        //var xPolice = GetComponentInParent<Transform>().position.x + fieldOfView.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        //var yPolice = GetComponentInParent<Transform>().position.y + fieldOfView.y;     //ibid
        //var zPolice = GetComponentInParent<Transform>().position.z + fieldOfView.z;     //ibid


        var xPolice = GetComponentInParent<Transform>().position.x ;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var yPolice = GetComponentInParent<Transform>().position.y ;     //ibid
        var zPolice = GetComponentInParent<Transform>().position.z ;     //ibid

        //var vectP = new Vector3(GetComponentInParent<Transform>().position.x, GetComponentInParent<Transform>().position.y, GetComponentInParent<Transform>().position.z);



        // print(Norm);

        //Debug.Log("x:"+ fieldOfView.x);
        //print("y:"+ fieldOfView.y);
        //print("z:" + fieldOfView.z);

        //var allo = new Vector3(xPolice,,);

        //if (positionBandit.x <= xPolice && positionBandit.y <= yPolice && positionBandit.z <= zPolice)

        //print("XXXXX :      " + (positionBandit.x - xPolice));
        //print("YYYY :      " + ( positionBandit.y - yPolice));
        //print("ZZZZZ :      " + (positionBandit.z - zPolice));

        //float test = Vector3.Angle(positionBandit, vectP);

        var testtt = Vector3.Distance(GetComponentInParent<Transform>().position, positionBandit);
        //Debug.Log("norm vecteur :                                          " + testtt);

        var testtt2 = Vector3.AngleBetween(GetComponentInParent<Transform>().position, positionBandit);
        Debug.Log("norm vecteur :                                          " + testtt2);


        //if (Mathf.Abs(NormB.magnitude) <= Mathf.Abs(rayon))
        //{
        //    Debug.Log("T'eS DAnS lE rAYoN");
        //}

        //if ((positionBandit.x - xPolice) <= rayon && (positionBandit.z - zPolice) <= rayon && (positionBandit.y - yPolice) <= rayon)
        //{
        //    Debug.Log("yo wesh mon fuere tes la");
        //}
    }
}
