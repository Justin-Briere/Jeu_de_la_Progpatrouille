using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AI;

public class VisionPolice : MonoBehaviour
{

    [SerializeField]
    public GameObject banditos;

    public bool topVision;

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
    float minMaxAngleXZ ;
    float minMaxAngleYZ;

    float policierRegarde;

    bool rayonBool = false;
    bool angleXZBool = false;
    bool angleYZBool = false;
    bool thereIsNoWalls = false;

    void Start()
    {
        //bool EZmode = true;
        //if (EZmode)
        //{
        //    MinValueAngle = 45;
        //    MaxValueAngle = 315;
        //}



        minMaxAngleXZ = 45;
        minMaxAngleYZ = 5;

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
        CheckAngleYZ();
        CheckWalls();
        ChekAll();


    }

    private void CheckRayon()
    {

        //LES 5 PROCHAINE LIGNES SERVENT À DÉTERMINER SI LE JOUEUR EST DANS LE RAYON PRÉDÉFINI DU POLICIER DU POLICIER
        var distanceRayon = Vector3.Distance(GetComponentInParent<Transform>().position, positionBandit);

        if (distanceRayon <= rayon)
        {
            rayonBool = true;
        }
        else
        {
            rayonBool = false;
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

        //Debug.Log("angle" + tetaDeg2);

        //if (Mathf.Abs(tetaDeg2) < x)
        //{
        //    Debug.Log("angle is right");
        //}
        

        if (UpAngle < (2*minMaxAngleXZ) && DownAngle > 360 - (2 * minMaxAngleXZ))
        {
            if (test < UpAngle || test > DownAngle)
            {
                angleXZBool = true;
            }
            else
            {
                angleXZBool = false;
            }
        }
        else if (test < UpAngle && test > DownAngle) 
        {
            angleXZBool = true;

        }
        else
        {
            angleXZBool = false;
        }
        
        
        //var IsInVision = (test < MinValueAngle && test > MaxValueAngle) ? true : false;
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

        if (!Physics.Linecast(transform.position, positionBandit, LayerMask.GetMask("WallsAI"))) 
        {
            thereIsNoWalls = true;
            //print("pas de mur donc true");
        }
        else
        {
            thereIsNoWalls = false;
        }
    }

}

