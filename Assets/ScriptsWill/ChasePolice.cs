using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePolice : MonoBehaviour //ce script s'occupe de poursuivre le policier s'il le voit et revenir à sa position initiale dans le cas contraire
{
    [SerializeField]
    Transform[] allo;

    // Start is called before the first frame update
    float positionInitialeX;
    float positionInitialeZ;

    //float xDiff;
    //float zDiff;

    private bool chasing;

    public int current;

    //Vector3 leVecteur = new Vector3();
    [SerializeField]
    private float policeSpeed = 3f;

    void Start()
    {
        current = 0;

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

        
        if (chek)
        {
            float positionBanditX = GameObject.Find("Bandit").transform.position.x;
            float positionBanditZ = GameObject.Find("Bandit").transform.position.z;
            policeSpeed = 7;
            ChaseBandit(positionPoliceX, positionPoliceZ, positionBanditX, positionBanditZ);
            chasing = true;
        }
        else
        {
            policeSpeed = 2;
            ReturnInitialPosition(positionInitialeX, positionInitialeZ, positionPoliceX, positionPoliceZ);
            chasing = false;

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

        if (Mathf.Abs(xDiff) <= 0.1 && Mathf.Abs(zDiff) <= 0.1)
        {
            current++;

            

            if (current >= allo.Length)
            {
                current = 0;
            }
            
        }
        else
        {

            Deplacer(xDiff, zDiff);
            transform.LookAt(allo[current]);
        }

        //if (positionPoliceX - allo[current].position.x <= 0.5 && positionPoliceZ - allo[current].position.z <= 0.5)
        //{
        //    current++;
        //}

    }

    public void Deplacer(float xDiff, float zDiff)
    {
        Vector3 leVecteur = new Vector3(xDiff, 0, zDiff);

        transform.Translate(leVecteur.normalized * (policeSpeed * Time.deltaTime), Space.World);

    }
}
