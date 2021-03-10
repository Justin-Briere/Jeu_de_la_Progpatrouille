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
            //Debug.Log("T'eS DAnS lE rAYoN");
        }

    }

    private void CheckAngleXZ()
    {
        var xPolice = GetComponentInParent<Transform>().position.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var zPolice = GetComponentInParent<Transform>().position.z;     //ibid

        // var Vpopo = new Vector3(xPolice, 0, zPolice);
        // var Vban = new Vector3(positionBandit.x, 0, positionBandit.z);

        //var Vtot = Vpopo - Vban;

        //var angle = Mathf.Atan(Vtot.x / Vtot.y);  

        //if(Mathf.Abs(angle) < Mathf.PI/2)
        //{
        //    Debug.Log("angle is right");
        //}

        var d1 = positionBandit.z- zPolice ;
        var d2 = positionBandit.x - xPolice;

        var teta1 = Mathf.Atan(d1 / d2);

        var tetaDeg = teta1 * Mathf.Rad2Deg;

        if(d2 < 0)
        {
            tetaDeg += 180;
        }


        var rotPolice = GetComponentInParent<Transform>().eulerAngles.y ;

       // tetaDeg += rotPolice;
        //tetaDeg + rotation y
        //Debug.Log("rotPolice :            " + rotPolice);


       Debug.Log("angle :            " + tetaDeg);

       
        if (tetaDeg >= 45 && tetaDeg <= 135)
        {
            Debug.Log("angle is right");
        }


       // Vector3 vectorBidon = new Vector3(((Time.deltaTime) * Mathf.Sin(Mathf.Deg2Rad * Plateform.eulerAngles.y)), 0, ((Time.deltaTime) * Mathf.Cos(Mathf.Deg2Rad * Plateform.eulerAngles.y)));
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