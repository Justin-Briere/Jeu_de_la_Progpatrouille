using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AI;

public class VisionPolice : MonoBehaviour
{
    [SerializeField]
    public GameObject banditos;

    

    
   

    private Vector3 positionBandit;

    private Transform positionPolice;

    private float rayon = 10f;
    float minMaxAngleXZ ;
    float minMaxAngleYZ;

    float policierRegarde;

    bool rayonBool = false;
    bool angleXZBool = false;
    bool angleYZBool = false;
    bool thereIsNoWalls = false;

    public bool topVision;

    void Start()
    {
        if (KeepOverTimeComponent.difficulty == 1)
        {
            minMaxAngleXZ = 35;
            minMaxAngleYZ = 5;
            rayon = 10;

        }
        if (KeepOverTimeComponent.difficulty == 2)
        {
            minMaxAngleXZ = 40;
            minMaxAngleYZ = 10;
            rayon = 15;
        }
        else
        {
            minMaxAngleXZ = 45;
            minMaxAngleYZ = 15;
            rayon = 20;
        }

    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        positionPolice = GetComponentInParent<Transform>();
         

        CheckRayon();
        CheckAngleXZ();
        CheckAngleYZ();
        CheckWalls();
        ChekAll();


    }

    private void CheckRayon()
    {
        //LES 5 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER
        var distanceRayon = Vector3.Distance(GetComponentInParent<Transform>().position, positionBandit);

        rayonBool = false;
        if (distanceRayon <= rayon)
        {
            rayonBool = true;
        }
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

        policierRegarde = tetaDeg2;

        var rotPolice = Mathf.Abs(GetComponentInParent<Transform>().eulerAngles.y);

        var rotPolice2 = RightConversion2(rotPolice);

        //print("policier regarde :  " + rotPolice2);
        //print("angle entre policier et bandit :  " + tetaDeg2);


        var test = tetaDeg2;

        var UpAngle = rotPolice2  + minMaxAngleXZ;
        var DownAngle = rotPolice2 - minMaxAngleXZ;

        if(UpAngle > 360)
        {
            UpAngle -= 360;
        }

        if (DownAngle < 0)
        {
            DownAngle += 360;
        }


        angleXZBool = false;

        if ((UpAngle < (2*minMaxAngleXZ) && DownAngle > 360 - (2 * minMaxAngleXZ)) && (test < UpAngle || test > DownAngle))
            angleXZBool = true;
              
        else if (test < UpAngle && test > DownAngle) 
            angleXZBool = true;
        

        

    }


    private void CheckAngleYZ()
    {
        var yPolice = GetComponentInParent<Transform>().position.y;     //Prends la composante du la position du policier et l'additione à la composante correspondanted du vecteur de sa vision
        var zPolice = GetComponentInParent<Transform>().position.z;     //ibid
        var xPolice = GetComponentInParent<Transform>().position.x;

        var l1 =   Mathf.Sqrt (    Mathf.Pow(positionBandit.z - zPolice,2) + Mathf.Pow(positionBandit.x - xPolice, 2));
        var l2 = Mathf.Abs(positionBandit.y - yPolice);
    
        var tetaUp = Mathf.Atan(l2 / l1);

        var tetaDegUp = tetaUp * Mathf.Rad2Deg;

        angleYZBool = false;
        if (tetaDegUp < minMaxAngleYZ)
        {
            angleYZBool = true;
        }
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

        rotPolice -= 90;
        rotPolice = rotPolice * -1;
        rotPolice += 360;

        if (rotPolice >= 360)
        {
            rotPolice -= 360;
        }


        return rotPolice;
    }

    public void ChekAll()
    {
        //if (gameObject.name == "police1Jean")
        //{
        //    print("rayon :" + rayonBool);
        //    print("angledg :" + angleXZBool);
        //    print("anglehauteur :" + angleYZBool);
        //    print("walls :" + thereIsNoWalls);
        //}



        if (rayonBool && angleXZBool && angleYZBool && thereIsNoWalls)
        {
           // Debug.Log("I SEE U");
            topVision = true;
            RotatePolice();
        }
        else
        {
            topVision = false;
        }
        

    }


    public void RotatePolice()
    {
        // transform.Rotation(0, policierRegarde, 0, Space.World);

        //   transform.rotation = Vector3(0, policierRegarde, 0);


        transform.LookAt(banditos.transform); 
        
    }

    public void CheckWalls()
    {
        thereIsNoWalls = false;
        if (!Physics.Linecast(transform.position, positionBandit, LayerMask.GetMask("WallsAI"))) 
        {
            thereIsNoWalls = true;
        }
    }
}

