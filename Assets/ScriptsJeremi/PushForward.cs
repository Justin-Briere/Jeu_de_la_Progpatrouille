using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{
    private Vector3 positionBandit;
    private Vector3 positionFan;
    private PushComponent item;
    BoxCollider i;

    [SerializeField]
    private float Intensity;

    [SerializeField]
    float puissanceFan;
    public void PousserAvant()
    {
        item.Push(transform.forward * (Intensity) * 50);
    }
    void Start()
    {
        item = GetComponent<PushComponent>();
        i = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        positionBandit = GameObject.Find("Bandit").transform.position;
        positionFan = GetComponentInParent<Transform>().position;
        Intensity = 1 / Mathf.Pow(TrouverDistanceBanditFan(positionBandit, positionFan), 2);
        if (i.isTrigger)
            PousserAvant();
    }
    public float TrouverDistanceBanditFan(Vector3 positionBandit, Vector3 positionFan)
    {

        return Vector3.Distance(positionBandit, positionFan);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.isTrigger)
    //        PousserAvant();
    //}
}
