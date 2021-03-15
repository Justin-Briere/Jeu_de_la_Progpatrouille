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

    private Vector3 PoliceBandit;
    private Vector3 VectorPolice;
    private Vector3 VectorAnglePolice;
    private Transform positionPolice;

    GameObject bodyPolice;
    private float x;
    private float y;
    private float z;
    int cnt;
    float MinValueAngle;
    float MaxValueAngle;
    void Start()
    {
        bool EZmode = true;
        if (EZmode)
        {
            MinValueAngle = 45;
            MaxValueAngle = 315;
        }
         cnt = 0;
        x = 45;
        y = 45;
        z = 45;
         bodyPolice = GameObject.Find("Body");

    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        positionPolice = GetComponentInParent<Transform>();
         

        CheckRayon();
        CheckAngleXZ();
        //CheckAngleXY();
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
    private void OnMouseDown()                          // fonction qui permet de call le start par clicker sur un items.
    {
        

    }



    private void CheckAngleXZ()
    {

        var xPolice = GetComponentInParent<Transform>().position.x;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var zPolice = GetComponentInParent<Transform>().position.z;     //ibid

        var d1 = positionBandit.z - zPolice;
        var d2 = positionBandit.x - xPolice;

        var teta1 = Mathf.Atan(d1 / d2);

        var tetaDeg = teta1 * Mathf.Rad2Deg;


        var tetaDeg2 = RightConversion(tetaDeg,d1,d2);

        var rotPolice = Mathf.Abs(GetComponentInParent<Transform>().eulerAngles.y);

        var rotPolice2 = RightConversion2(rotPolice);
        var test = tetaDeg2 + rotPolice2;



        Debug.Log("angle" + test);

        //if (Mathf.Abs(tetaDeg2) < x)
        //{
        //    Debug.Log("angle is right");
        //}
        if (test < MinValueAngle || test > MaxValueAngle) Debug.Log("angle is right");
        var IsInVision = (test < MinValueAngle && test > MaxValueAngle) ? true : false;
    }


    public float RightConversion(float tetaDeg,float d1,float d2)
    {

        if (d2 < 0)
        {
            tetaDeg += 180;
        }
        else if (d1 < 0)
        {
            tetaDeg += 360;

        }

        return tetaDeg;
    }

    public float RightConversion2(float rotPolice)
    {
        
        rotPolice = rotPolice * -1;
        rotPolice += 360;

        if (rotPolice >= 360)
        {
            rotPolice -= 360;
        }

      
        return rotPolice;
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