using UnityEngine;

public class ComportementEnnemi : MonoBehaviour
{
   enum ÉtatEnnemi { PositionnementInitial, PositionnementFinal, Attente, Attaque, NbÉtatsEnnemi };
   enum TransitionJeu { Activation, EnMarche, Terminé };
   delegate void ActionÉtat();

   const int Vitesse = 9; // Vitesse de déplacement de la soucoupe dans les différentes phases du jeu

   ActionÉtat[] ActionsÉtat { get; set; }
   ÉtatEnnemi ÉtatActuel { get; set; }
   TransitionJeu TransitionÉtat { get; set; }
   Vector3[] TrajectoireInitiale { get; set; }
   Vector3[] TrajectoireDéplacement { get; set; }
   float DistanceParFrame { get; set; }
   int NoPtTrajectoire { get; set; }
   bool DéplacementTerminé { get; set; }
   bool AttenteTerminé { get; set; }
   Vector3 PositionFinale { get; set; }
   GameScreenManager ScriptManagerParent { get; set; }
   GameObject VaisseauJoueur { get; set; }
   Vector3 CibleAttaque { get; set; }
   private void Awake()
   {
      InitialiserActionsÉtat();
      ÉtatActuel = ÉtatEnnemi.PositionnementInitial;
      TransitionÉtat = TransitionJeu.Activation;
      ScriptManagerParent = transform.parent.GetComponent<GameScreenManager>();
   }

   private void InitialiserActionsÉtat()
   {
      ActionsÉtat = new ActionÉtat[(int)ÉtatEnnemi.NbÉtatsEnnemi];
      ActionsÉtat[(int)ÉtatEnnemi.PositionnementInitial] = GérerÉtatPositionnementInitial;
      ActionsÉtat[(int)ÉtatEnnemi.PositionnementFinal] = GérerÉtatPositionnementFinal;
      ActionsÉtat[(int)ÉtatEnnemi.Attente] = GérerÉtatAttente;
      ActionsÉtat[(int)ÉtatEnnemi.Attaque] = GérerÉtatAttaque;
   }

   void Update()
   {
      ActionsÉtat[(int)ÉtatActuel]();
   }

   private void GérerÉtatPositionnementInitial()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            TrajectoireInitiale = ScriptManagerParent.SpawnTrajectoire;
            VaisseauJoueur = ScriptManagerParent.VaisseauJoueur;
            NoPtTrajectoire = 1;
            DistanceParFrame = 0;
            DéplacementTerminé = false;
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            EffectuerDéplacement(TrajectoireInitiale);
            TransitionÉtat = DéplacementTerminé ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatEnnemi.PositionnementFinal;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void EffectuerDéplacement(Vector3[] trajectoire)
   {
      DistanceParFrame = CalculerDistanceParFrame(trajectoire, NoPtTrajectoire, DistanceParFrame, Time.deltaTime);
      float distanceDuProchainPoint = Vector3.Distance(transform.position, trajectoire[NoPtTrajectoire]);
      if (distanceDuProchainPoint < DistanceParFrame)
      {
         transform.position = trajectoire[NoPtTrajectoire];
         int NoPtTrajectoireSuivant = NoPtTrajectoire + 1;
         DéplacementTerminé = NoPtTrajectoireSuivant == trajectoire.Length;
         NoPtTrajectoire = NoPtTrajectoireSuivant;
      }
      if (!DéplacementTerminé)
      {
         transform.position = Vector3.MoveTowards(transform.position, trajectoire[NoPtTrajectoire], Vitesse * Time.deltaTime);
      }
   }

   private void GérerÉtatPositionnementFinal()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            DéplacementTerminé = false;
            NoPtTrajectoire = 1;
            TrajectoireDéplacement = new Vector3[2];
            TrajectoireDéplacement[0] = TrajectoireInitiale[TrajectoireInitiale.Length - 1];
            PositionFinale = ScriptManagerParent.GetPositionEnnemi();
            TrajectoireDéplacement[1] = PositionFinale;
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            EffectuerDéplacement(TrajectoireDéplacement);
            TransitionÉtat = DéplacementTerminé ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ScriptManagerParent.IncrémenterNbEnnemisEnPosition();
            ÉtatActuel = ÉtatEnnemi.Attente;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void GérerÉtatAttente()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TransitionÉtat = AttenteTerminé ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatEnnemi.Attaque;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void GérerÉtatAttaque()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            CibleAttaque = VaisseauJoueur.transform.position + (2 * Vector3.left);//Le modèle d'origine est mal positionné...
            DéplacementTerminé = false;
            NoPtTrajectoire = 1;
            Vector3 directionAttaque = (CibleAttaque - transform.position);
            TrajectoireDéplacement = new Vector3[2];
            TrajectoireDéplacement[0] = transform.position;
            TrajectoireDéplacement[1] = CibleAttaque + 2 * directionAttaque;
            //TrajectoireDéplacement[2] = TrajectoireDéplacement[1] + directionAttaque;
            //TrajectoireDéplacement[3] = TrajectoireDéplacement[2] + directionAttaque;
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            EffectuerDéplacement(TrajectoireDéplacement);
            TransitionÉtat = DéplacementTerminé ? TransitionJeu.Terminé : TransitionJeu.EnMarche;
            break;
         case TransitionJeu.Terminé:
            ScriptManagerParent.DétruireEnnemi(transform.gameObject);
            Destroy(transform.gameObject);
            break;
      }
   }

   private float CalculerDistanceParFrame(Vector3[] lstPts, int noPoint, float ancienneDistanceParFrame, float deltaTime)
   {
      return (noPoint == lstPts.Length - 1) ? ancienneDistanceParFrame : (Vector3.Distance(lstPts[noPoint], lstPts[noPoint + 1]) / (1f / deltaTime)) * Vitesse;
   }

   public void DéclencherAttaque()
   {
      AttenteTerminé = true;
   }
}
