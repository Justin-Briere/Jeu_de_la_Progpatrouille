using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayComponent : MonoBehaviour  //Script de la dernière session pour le Galaga affichant le score.
{
   [SerializeField]
   ScoreComponent scoreProvider;

   TextMesh Affichage { get; set; }

   void Start()
   {
      Affichage = GetComponent<TextMesh>();
      scoreProvider.OnScoreChanged += (objetSource, donnéesÉvènement) => Affichage.text = donnéesÉvènement.NewValue.ToString();
   }
}
