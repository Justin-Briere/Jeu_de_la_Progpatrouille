
using UnityEngine;

public class GestionCollisionOVNI : MonoBehaviour //Script de la dernière session gérant les collisions du Galaga.
{

    const float PtsPerElimination = 100f;

    [SerializeField]
    int CoucheCollisionMissile; //Layer comme dans le tp2 en prog

    [SerializeField]
    int CoucheCollisionVaisseau;

    GameScreenManager GameManager { get; set; }
    ScoreComponent Score { get; set; }


    void Awake()
    {
        Score = transform.parent.parent.GetComponent<ScoreComponent>(); //demander a Kyle s'il y a un lien plus rapide pour le GetComponent
        GameManager = transform.parent.parent.GetComponent<GameScreenManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == CoucheCollisionVaisseau || collision.gameObject.layer == CoucheCollisionMissile)
            if (CoucheCollisionVaisseau == collision.gameObject.layer)
            {
                Destroy(collision.gameObject);
                GameManager.DétruireVaisseau();
            }

        GameManager.DétruireEnnemi(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
        Score.AddScore(PtsPerElimination); //Ca rajoute 100 points meme si c'est le vaisseau qui est détruit
    }
}


