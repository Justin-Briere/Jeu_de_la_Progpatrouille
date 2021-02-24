using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionPolice : MonoBehaviour
{
    [SerializeField]
    private float rayon = 1.0f;

    //[SerializeField]
    private float teta = Mathf.PI / 4 ;

   // [SerializeField]
    private float phi = Mathf.PI/4;


    private Vector3 positionPolice;

    private Vector3 positionBandit;

    private float rotationPolice;

    private Vector3 fieldOfView;
    void Start()
    {
        //positionPolice = transform.position ;
        //Debug.Log(positionPolice);


        //positionBandit = GameObject.Find("Bandit").transform.position;
        //Debug.Log(positionBandit);

        //teta = teta * Mathf.Deg2Rad;
    }



    // Update is called once per frame
    void Update()
    {
        rotationPolice = transform.rotation.y * Mathf.Deg2Rad;
        positionPolice = transform.position;
        fieldOfView = new Vector3 (Mathf.Sin(phi) * Mathf.Cos(teta) + positionPolice.x,       Mathf.Sin(phi) * Mathf.Sin(teta) + positionPolice.y /*- rotationPolice*/      , Mathf.Cos(phi) + positionPolice.z);      
        positionBandit = GameObject.Find("Bandit").transform.position;
        ChekVision(fieldOfView.normalized * rayon);
    }


    private void ChekVision(Vector3 fieldOfView2)
    {
       // Debug.Log(fieldOfView2);

        if (positionBandit.x <= fieldOfView2.x && positionBandit.y <= fieldOfView2.y && positionBandit.z <= fieldOfView2.z)
        {
            Debug.Log("yo wesh mon fuere tes la");
        }
    }

    //private bool Verification()
    //{
    //    //Debug.Log("je passe dans verif"); 
    //    return positionBandit.x <= fieldOfView.x && positionBandit.y <= fieldOfView.y && positionBandit.z <= fieldOfView.z;
    //}
}
