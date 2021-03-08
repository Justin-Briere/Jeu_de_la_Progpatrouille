using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class VisionPolice : MonoBehaviour
{
    [SerializeField]
    private float rayon = 10f;

    //[SerializeField]
    private float teta = Mathf.PI / 4;

    // [SerializeField]
    private float phi = Mathf.PI / 4;


    private Vector3 positionBandit;

    private Vector3 rotationPolice;

    private Vector3 fieldOfView;

    private float x;
    private float y;
    private float z;


    void Start()
    {
        x = 45;
        y = 45;
        z = 45;
    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;

        CheckRayon();
        CheckAngleXZ();
        CheckAngleXY();
    }

    private void CheckRayon()
    {  

        //LES 5 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER
        var distanceRayon = Vector3.Distance(GetComponentInParent<Transform>().position, positionBandit);

        if (distanceRayon <= rayon)
        {
            Debug.Log("T'eS DAnS lE rAYoN");
        }

    }

    private void CheckAngleXZ()
    {
        var xPolice = GetComponentInParent<Transform>().position.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var zPolice = GetComponentInParent<Transform>().position.z;     //ibid

        var Vpopo = new Vector3(xPolice, 0, zPolice);
        var Vban = new Vector3(positionBandit.x, 0, positionBandit.z);

        var Vtot = Vpopo - Vban;

        var angle = Mathf.Tan(Vtot.x / Vtot.y);  //DOIT FAIRE ARC TAN 

        if(Mathf.Abs(angle) < x)
        {
            Debug.Log("angle is right");
        }
    }

    private void CheckAngleXY()
    {

    }

}

//var popoX = new Vector3(GetComponentInParent<Transform>().position.x, 0, 0);

//var banbanX = new Vector3(positionBandit.x, 0, 0);

//var rfnij = Vector3.Angle(popoX, banbanX);

////var testtt2 = Vector3.Angle(GetComponentInParent<Transform>().position, positionBandit);


//Debug.Log("angle x :                                          " + rfnij);

//        // if(est dans le bon angle)


//var xPolice = GetComponentInParent<Transform>().position.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
//var yPolice = GetComponentInParent<Transform>().position.y;     //ibid
//var zPolice = GetComponentInParent<Transform>().position.z;     //ibid


//x = Mathf.Sin(phi) * Mathf.Cos(teta) ;
// y = Mathf.Sin(phi) * Mathf.Sin(teta) ;
// z = Mathf.Cos(phi) ;