using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasePolice : MonoBehaviour 
{
    [SerializeField]
    Transform[] allo; //représente la liste de transform à parcourir, changer son nom implique que le tableau dans unity se vident

    float positionInitialeX;
    float positionInitialeZ;
    int current;
    float policeSpeed;
    float chaseSpeed = 7f;
    float paturnSpeed = 2f;

    void Start()
    {
        //if (ezmode)
        //  paturn speed = 1
        //if (ezmode)
        //  paturn speed = 2
        //if (ezmode)
        //  paturn speed = 3




        current = 0;

        positionInitialeX = GetComponentInParent<Transform>().position.x;
        positionInitialeZ = GetComponentInParent<Transform>().position.z;
    }

    void Update()
    {
        bool chek = GetComponent<VisionPolice>().topVision;
        float positionPoliceX = GetComponentInParent<Transform>().position.x;
        float positionPoliceZ = GetComponentInParent<Transform>().position.z;

        float positionBanditX = GameObject.Find("Bandit").transform.position.x;
        float positionBanditZ = GameObject.Find("Bandit").transform.position.z;

        if (chek)
        {
            policeSpeed = chaseSpeed;
            ChaseBandit(positionPoliceX, positionPoliceZ, positionBanditX, positionBanditZ);
        }
        else
        {
            policeSpeed = paturnSpeed;
            ReturnInitialPosition(positionInitialeX, positionInitialeZ, positionPoliceX, positionPoliceZ);         
        }
    }

    public void ChaseBandit(float positionPoliceX, float positionPoliceZ, float positionBanditX, float positionBanditZ)
    {

        float xDiff = (positionBanditX - positionPoliceX);
        float zDiff = (positionBanditZ - positionPoliceZ);
        
        Deplacer(xDiff, zDiff);
    }

    public void ReturnInitialPosition(float positionInitialeX, float positionInitialeZ, float positionPoliceX, float positionPoliceZ)
    {
        positionInitialeX = allo[current].position.x;
        positionInitialeZ = allo[current].position.z;

        float xDiff = (positionInitialeX - positionPoliceX);
        float zDiff = (positionInitialeZ - positionPoliceZ);

        if (Mathf.Abs(xDiff) <= 0.4 && Mathf.Abs(zDiff) <= 0.4)
        {
            current++;

            if (current >= allo.Length)
            {
                current = 0;
            }          
        }
        else
        {
            if (allo.Length != 1)
            {
                Deplacer(xDiff, zDiff);
                transform.LookAt(allo[current]);
            }
        }
    }

    public void Deplacer(float xDiff, float zDiff)
    {
        Vector3 leVecteur = new Vector3(xDiff, 0, zDiff);
        transform.Translate(leVecteur.normalized * (policeSpeed * Time.deltaTime), Space.World);
    }
}
