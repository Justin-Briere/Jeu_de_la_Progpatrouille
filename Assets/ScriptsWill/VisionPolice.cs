﻿using System.Collections;
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

    private float x;
    private float y;
    private float z;

    //void Start()
    //{
    //    //positionPolice = transform.position ;
    //    //Debug.Log(positionPolice);


    //    //positionBandit = GameObject.Find("Bandit").transform.position;
    //    //Debug.Log(positionBandit);

    //    //teta = teta * Mathf.Deg2Rad;

        
    //}



    //// Update is called once per frame
    //void Update()
    //{
    //    rotationPolice = transform.rotation.y * Mathf.Deg2Rad;
    //    positionPolice = transform.position;

    //    x = Mathf.Sin(phi) * Mathf.Cos(teta) + positionPolice.x;
    //    y = Mathf.Sin(phi) * Mathf.Sin(teta) + positionPolice.y;
    //    z = Mathf.Cos(phi) + positionPolice.z;
    //    fieldOfView = new Vector3 (x,y,z);    
        
    //    positionBandit = GameObject.Find("Bandit").transform.position;
    //    ChekVision(fieldOfView.normalized * rayon);
    //}


    //private void ChekVision(Vector3 fieldOfView2)
    //{
    //   // Debug.Log(fieldOfView2);

    //    if (positionBandit.x <= fieldOfView2.x && positionBandit.y <= fieldOfView2.y && positionBandit.z <= fieldOfView2.z)  ////position bandit-position
    //    {
    //        Debug.Log("yo wesh mon fuere tes la");
    //    }
    //}


    void Start()
    {
        x = Mathf.Sin(phi) * Mathf.Cos(teta) *rayon;
        y = Mathf.Sin(phi) * Mathf.Sin(teta) *rayon ;
        z = Mathf.Cos(phi) *rayon;

        fieldOfView = new Vector3(x, y, z);


        //Vector3[] fieldOfViews = new Vector3[3];
        //fieldOfViews[0] = new Vector3(x, y, z);


        
    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        ChekVision();
    }

    private void ChekVision()
    {
        var xPolice = GetComponentInParent<Transform>().position.x + fieldOfView.x;     //regqgerggr
        var yPolice = GetComponentInParent<Transform>().position.y + fieldOfView.y;
        var zPolice = GetComponentInParent<Transform>().position.z + fieldOfView.z;

        if(positionBandit.x <= xPolice && positionBandit.y <= yPolice && positionBandit.z <= zPolice)
        {
            Debug.Log("yo wesh mon fuere tes la");
        }
    }
}
