using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComportementBouton : MonoBehaviour
{
   [SerializeField]
   float TauxVariationCouleur;
   Button Bouton { get; set; }
   Image ImageBouton { get; set; }
   Color CouleurBouton { get; set; }
   float CanalBleu { get; set; }
   float CanalVert { get; set; }
   int SensVariation { get; set; }
   // Start is called before the first frame update
   void Awake()
    {
      Bouton = GetComponent<Button>();
      ImageBouton = Bouton.GetComponent<Image>();
      CouleurBouton = ImageBouton.color;
      CanalBleu = CouleurBouton.b;
      CanalVert = CouleurBouton.g;
      SensVariation = CanalBleu > CanalVert ? -1 : 1;
   }

   // Update is called once per frame
   void Update()
    {
      CanalBleu += SensVariation * TauxVariationCouleur;
      CanalVert -= SensVariation * TauxVariationCouleur;
      if (CanalBleu > 1 || CanalBleu < 0 || CanalVert < 0 || CanalVert > 1)
      {
         SensVariation = -SensVariation;
      }
      Color couleur = new Color(0, CanalVert, CanalBleu);
      ImageBouton.color = couleur;
   }
}
