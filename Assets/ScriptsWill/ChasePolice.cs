using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChasePolice : MonoBehaviour
{
    [SerializeField]
    Transform[] allo; //représente la liste de transform à parcourir, changer son nom implique que le tableau ed chaque police dans unity se vide :(

    Transform positionPolice;
    Transform positionBandit;

    int current;
    float chaseSpeed;
    float paturnSpeed;

    void Start()
    {
        if (KeepOverTimeComponent.difficulty == 1)
        {
            paturnSpeed = 1;
            chaseSpeed = 3;
        }
        if (KeepOverTimeComponent.difficulty == 2)
        {
            paturnSpeed = 2;
            chaseSpeed = 5;
        }
        else
        {
            paturnSpeed = 3;
            chaseSpeed = 7;
        }

        current = 0;
    }

    void Update()
    {
        bool chekVision = GetComponent<VisionPolice>().vueSurBandit;

        positionPolice = GetComponentInParent<Transform>();
        positionBandit = GameObject.Find("Bandit").transform;

        if (chekVision)    
            Deplacer((positionBandit.position.x - positionPolice.position.x), (positionBandit.position.z - positionPolice.position.z), chaseSpeed);
        else           
            FollowPaturn();
        
    }


    public void FollowPaturn()
    {

        float xDiff = (allo[current].position.x - positionPolice.position.x);
        float zDiff = (allo[current].position.z - positionPolice.position.z);

        if (Mathf.Abs(xDiff) <= 0.4 && Mathf.Abs(zDiff) <= 0.4)
        {
            current++;
            if (current >= allo.Length)          
                current = 0;
            
        }
        else if (allo.Length != 1)
        {
            Deplacer(xDiff, zDiff, paturnSpeed);
            transform.LookAt(allo[current]);
        }
    }

    public void Deplacer(float xDiff, float zDiff, float vitesse)
    {
        Vector3 leVecteur = new Vector3(xDiff, 0, zDiff);
        transform.Translate(leVecteur.normalized * (vitesse * Time.deltaTime), Space.World);
    }
}
