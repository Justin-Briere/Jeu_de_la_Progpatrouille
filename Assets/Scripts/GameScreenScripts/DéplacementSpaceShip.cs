using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DéplacementSpaceShip : MonoBehaviour
{
   [SerializeField]              // Le champs VitesseLinéaire sera accessible en tant que paramètre du script dans l'éditeur de Unity.
   float VitesseLinéaire = 10f;  // L'usage de la commande [SeralizeField] permet d'éviter de mettre l'attribut public tout en permettant 
                                 // de faire quand même le lien avec l'éditeur.
                                 // La vitesseLinéaire est le scalaire utilisé pour le calcul de la translation

   [SerializeField]              // Le champs TouchesDéplacement sera accessible en tant que paramètre du script dans l'éditeur de Unity.
   KeyCode[] TouchesDéplacement; // L'usage de la commande [SeralizeField] permet d'éviter de mettre l'attribut public tout en permettant 
                                 // de faire quand même le lien avec l'éditeur.
                                 // Le tableau TouchesDéplacement contiendra les différentes touches utilisées pour le déplacement du véhicule

   [SerializeField]
   float LimiteGauche;

   [SerializeField]
   float LimiteDroite;

   Action[] ActionsDéplacement;

   void Awake()
   {
      AssocierActionsDéplacement();
      Debug.Assert(TouchesDéplacement.Length == ActionsDéplacement.Length);
   }

   void AssocierActionsDéplacement()
   {
      ActionsDéplacement = new Action[]
      {
            () => Déplacer(-VitesseLinéaire),
            () => Déplacer(VitesseLinéaire)
      };
   }

   private void Déplacer(float vitesse)
   {
      if (vitesse < 0 && transform.position.x > LimiteGauche || vitesse > 0 && transform.position.x < LimiteDroite)
      {
         transform.Translate(Vector3.left * vitesse * Time.deltaTime);
      }
   }

   void Update()
   {
      if (!Input.GetKey("right shift") && !Input.GetKey("left shift")) // si aucune des deux touches shift (ou les deux) n'est enfoncée
      {
         for (int i = 0; i < TouchesDéplacement.Length; ++i)
         {
            if (Input.GetKey(TouchesDéplacement[i]))
            {
               ActionsDéplacement[i].Invoke();
            }
         }
      }
   }
}
