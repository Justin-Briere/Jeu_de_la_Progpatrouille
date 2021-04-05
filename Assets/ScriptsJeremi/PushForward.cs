using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{
    private Vector3 positionJoueur;
    private Vector3 positionFan;
    private GameObject joueur;
    private PushComponent item;
    BoxCollider i;
    private bool vérif;

    [SerializeField]
    int zePuissance = 7;

    //[SerializeField]
    private float Intensity;

    [SerializeField]
    float puissanceFan;
    public void PousserAvant()
    {
        //joueur.transform.(transform.forward * (Intensity) * 50);
        joueur.GetComponent<Rigidbody>().velocity = transform.forward * Intensity * zePuissance;
    }
    void Start()
    {
        joueur = GameObject.Find("LeJoueur");
        item = GetComponent<PushComponent>();
        i = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {

        if (vérif)
        {
            positionJoueur = joueur.transform.position;
            positionFan = GetComponentInParent<Transform>().position;
            Intensity = Mathf.Pow(Mathf.Log(TrouverDistanceBanditFan(positionJoueur, positionFan)), -1);
            PousserAvant();
        }

    }
    public float TrouverDistanceBanditFan(Vector3 positionBandit, Vector3 positionFan)
    {

        return Vector3.Distance(positionBandit, positionFan);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.isTrigger)

        //positionJoueur = joueur.transform.position;
        //positionFan = GetComponentInParent<Transform>().position;
        //Intensity = Mathf.Pow(Mathf.Log(TrouverDistanceBanditFan(positionJoueur, positionFan)), -1);
        //PousserAvant();
        vérif = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        joueur.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vérif = false;
    }
}
