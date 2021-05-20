using UnityEngine;

public class ComportementTitre : MonoBehaviour  //Script de la dernière session servant à gérer la scène titre pour le Galaga
{
   [SerializeField]
   float TauxVariationCouleur;
   TextMesh Texte3D { get; set; }
   Color CouleurTexte { get; set; }
   float CanalAlpha { get; set; }
   int SensVariation { get; set; }

   void Awake()
   {
      Texte3D = GetComponent<TextMesh>();
      CouleurTexte = Texte3D.color;
      CanalAlpha = CouleurTexte.a;
      SensVariation = CanalAlpha > 0 ? -1 : 1;
   }

   void Update()
   {
      CanalAlpha += SensVariation * TauxVariationCouleur;
      if (CanalAlpha > 1 || CanalAlpha < 0)
      {
         SensVariation = -SensVariation;
      }
      Color couleur = new Color(CouleurTexte.r, CouleurTexte.g, CouleurTexte.b, CanalAlpha);
      Texte3D.color = couleur;
   }

}
