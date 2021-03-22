using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePolice : MonoBehaviour //ce script s'occupe de poursuivre le policier s'il le voit et revenir à sa position initiale dans le cas contraire
{
    // Start is called before the first frame update
    float positionInitialeX;
    float positionInitialeZ;

    //float xDiff;
    //float zDiff;

    //Vector3 leVecteur = new Vector3();

    private float policeSpeed = 1f;

    void Start()
    {
        //trouver la position initiale
        positionInitialeX = GetComponentInParent<Transform>().position.x;
        positionInitialeZ = GetComponentInParent<Transform>().position.z;
    }

    // Update is called once per frame
    void Update()
    {
        bool chek = GetComponent<VisionPolice>().topVision;
        float positionPoliceX = GetComponentInParent<Transform>().position.x;
        float positionPoliceZ = GetComponentInParent<Transform>().position.z;

        //print("chek is :  " +   chek);

        if (chek)
        {
            float positionBanditX = GameObject.Find("Bandit").transform.position.x;
            float positionBanditZ = GameObject.Find("Bandit").transform.position.z;
            
            ChaseBandit(positionPoliceX, positionPoliceZ, positionBanditX, positionBanditZ);
        }
        else
        {
            ReturnInitialPosition(positionInitialeX,positionInitialeZ, positionPoliceX, positionPoliceZ);
        }
    }

    public void ChaseBandit(float positionPoliceX, float positionPoliceZ, float positionBanditX, float positionBanditZ)
    {
        
        float xDiff = (positionBanditX - positionPoliceX);
        float zDiff = (positionBanditZ - positionPoliceZ);

        Deplacer(xDiff,zDiff);
    }

    public void ReturnInitialPosition(float positionInitialeX, float positionInitialeZ, float positionPoliceX, float positionPoliceZ)
    {

        float xDiff = ( positionInitialeX - positionPoliceX);
        float zDiff = (positionInitialeZ - positionPoliceZ);

        Deplacer(xDiff, zDiff);
    }

    public void Deplacer(float xDiff, float zDiff)
    {
        Vector3 leVecteur = new Vector3(xDiff, 0, zDiff);
        //print("le vecteur est : " + leVecteur);

        transform.Translate(leVecteur.normalized * (policeSpeed * Time.deltaTime), Space.World);

    }
}
