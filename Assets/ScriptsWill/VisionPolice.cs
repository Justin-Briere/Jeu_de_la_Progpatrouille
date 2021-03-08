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
        x = Mathf.Sin(phi) * Mathf.Cos(teta) ;
        y = Mathf.Sin(phi) * Mathf.Sin(teta) ;
        z = Mathf.Cos(phi) ;
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
        var xPolice = GetComponentInParent<Transform>().position.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var yPolice = GetComponentInParent<Transform>().position.y;     //ibid
        var zPolice = GetComponentInParent<Transform>().position.z;     //ibid


        //LES 5 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER
        var distanceRayon = Vector3.Distance(GetComponentInParent<Transform>().position, positionBandit);

        if (distanceRayon <= rayon)
        {
            Debug.Log("T'eS DAnS lE rAYoN");
        }

    }

    private void CheckAngleXZ()
    {

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
