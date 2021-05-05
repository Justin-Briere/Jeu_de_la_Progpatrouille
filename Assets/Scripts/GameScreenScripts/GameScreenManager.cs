using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenManager : MonoBehaviour
{
   enum ÉtatJeu { TitreNiveau, PositionnementEscadrille, Combat, FinNiveau, NbÉtatsJeu };
   enum TransitionJeu { Activation, EnMarche, Terminé };

   const int NbEnnemis = 29;
   const int NbEnnemisRangéeImpaire = 10;
   const int NbRangéesOVNI = 3;

   [SerializeField]
   GameObject Ovni;

   [SerializeField]
   public GameObject VaisseauJoueur;

   [SerializeField]
   float TempsApparitionMessage;

   [SerializeField]
   GameObject TitreNiveau;

   [SerializeField]
   float DeltaCréationEnnemi;

   [SerializeField]
   float DélaiEntreAttaque;

   delegate void ActionÉtat();

   ActionÉtat[] ActionsÉtat { get; set; }
   ÉtatJeu ÉtatActuel { get; set; }
   TransitionJeu TransitionÉtat { get; set; }
   List<Vector3> PositionsEscadrille { get; set; }
   List<GameObject> EscadrilleEnnemi { get; set; }
   public Vector3[] SpawnTrajectoire { get; private set; }
   float TempsÉcoulé { get; set; }
   int NoEnnemi { get; set; }
   int NbEnnemisEnPosition { get; set; }
   float TempsÉcouléAttaque { get; set; }
   bool VaisseauJoueurDétruit { get; set; }

   readonly Vector3 SpawnPoint = new Vector3(-12, -2, 0);
   readonly Vector3 AjustementDimension = new Vector3(1f, 0.5f, 0);

   void Awake()
   {
      DataSpline spawnSpline = new DataSpline("SplineAEx.txt");
      SpawnTrajectoire = spawnSpline.GetPointsSpline();
      ModifierListePoints(SpawnPoint, AjustementDimension, SpawnTrajectoire);
      InitialiserActionsÉtat();
      ÉtatActuel = ÉtatJeu.TitreNiveau;
      TransitionÉtat = TransitionJeu.Activation;
      TitreNiveau.SetActive(false);
   }

   private void ModifierListePoints(Vector3 origine, Vector3 modificationDimension, Vector3[] trajectoire)
   {
      Vector3 deltaOrigine = trajectoire[0] - origine;
      for (int i = 0; i < trajectoire.Length; ++i)
      {
         Vector3 ptSpline = trajectoire[i];
         ptSpline -= deltaOrigine;
         ptSpline.x *= modificationDimension.x;
         ptSpline.y *= modificationDimension.y;
         trajectoire[i] = ptSpline;
      }
   }

   private void InitialiserActionsÉtat()
   {
      ActionsÉtat = new ActionÉtat[(int)ÉtatJeu.NbÉtatsJeu];
      ActionsÉtat[(int)ÉtatJeu.TitreNiveau] = GérerÉtatTitreNiveau;
      ActionsÉtat[(int)ÉtatJeu.PositionnementEscadrille] = GérerÉtatPositionnementEscadrille;
      ActionsÉtat[(int)ÉtatJeu.Combat] = GérerÉtatCombat;
      ActionsÉtat[(int)ÉtatJeu.FinNiveau] = GérerÉtatFinNiveau;
   }

   void Update() => ActionsÉtat[(int)ÉtatActuel]();

   private void GérerÉtatTitreNiveau()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            TempsÉcoulé = 0;
            TitreNiveau.SetActive(true);
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TempsÉcoulé += Time.deltaTime;
            TransitionÉtat = TempsÉcoulé < TempsApparitionMessage ? TransitionJeu.EnMarche : TransitionJeu.Terminé;
            break;
         case TransitionJeu.Terminé:
            TitreNiveau.SetActive(false);
            ÉtatActuel = ÉtatJeu.PositionnementEscadrille;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void GérerÉtatPositionnementEscadrille()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            NoEnnemi = 0;
            NbEnnemisEnPosition = 0;
            CréerPositionsEscadrille();
            EscadrilleEnnemi = new List<GameObject>(NbEnnemis);
            TransitionÉtat = TransitionJeu.EnMarche;
            TempsÉcoulé = 0;

            break;
         case TransitionJeu.EnMarche:
            TempsÉcoulé += Time.deltaTime;
            if (EscadrilleEnnemi.Count < NbEnnemis && TempsÉcoulé > DeltaCréationEnnemi)
            {
               CréerEnnemi();
               TempsÉcoulé = 0;
            }
            TransitionÉtat = NbEnnemisEnPosition < NbEnnemis ? TransitionJeu.EnMarche : TransitionJeu.Terminé;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.Combat;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void CréerPositionsEscadrille()
   {
      const int MinX = -9;
      const int DeltaX = 17;
      const int MaxY = 7;
      PositionsEscadrille = new List<Vector3>(NbEnnemis);
      for (int j = 0; j < NbRangéesOVNI; ++j)
      {
         int ligne = j % 2;
         Vector3 positionEnnemie = new Vector3(MinX + ligne * DeltaX, MaxY - j, 0);
         for (int i = 0; i < NbEnnemisRangéeImpaire - ligne; ++i)
         {
            PositionsEscadrille.Add(positionEnnemie);
            positionEnnemie += ligne == 0 ? (Vector3.right * 2) : (Vector3.left * 2);
         }
      }
   }

   private void CréerEnnemi() => EscadrilleEnnemi.Add(Instantiate(Ovni, SpawnPoint, Ovni.transform.localRotation, transform));
   public void IncrémenterNbEnnemisEnPosition() => ++NbEnnemisEnPosition;
   public Vector3 GetPositionEnnemi() => PositionsEscadrille[NoEnnemi++];

   private void GérerÉtatCombat()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            VaisseauJoueur.SetActive(true);
            VaisseauJoueurDétruit = false;
            TempsÉcouléAttaque = DélaiEntreAttaque;
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            TempsÉcouléAttaque += Time.deltaTime;
            if (TempsÉcouléAttaque>DélaiEntreAttaque)
            {
               EnvoyerOvniAttaquer();
               TempsÉcouléAttaque = 0;
            }
            TransitionÉtat = !VaisseauJoueurDétruit && EscadrilleEnnemi.Count > 0 ? TransitionJeu.EnMarche : TransitionJeu.Terminé;
            break;
         case TransitionJeu.Terminé:
            ÉtatActuel = ÉtatJeu.FinNiveau;
            TransitionÉtat = TransitionJeu.Activation;
            break;
      }
   }

   private void EnvoyerOvniAttaquer()
   {
      int nbSurvivants = EscadrilleEnnemi.Count;
      if (nbSurvivants > 0)
      {
         int volontaire = UnityEngine.Random.Range(0, nbSurvivants);
         EscadrilleEnnemi[volontaire].GetComponent<ComportementEnnemi>().DéclencherAttaque();
      }
   }
   public void DétruireVaisseau() => VaisseauJoueurDétruit = true;

   public void DétruireEnnemi(GameObject ennemiAbattu) => EscadrilleEnnemi.Remove(ennemiAbattu);

   private void GérerÉtatFinNiveau()
   {
      switch (TransitionÉtat)
      {
         case TransitionJeu.Activation:
            TransitionÉtat = TransitionJeu.EnMarche;
            break;
         case TransitionJeu.EnMarche:
            GameMasterFSM scriptMaster = GameObject.Find("GlobalGameManager").GetComponent<GameMasterFSM>();
            scriptMaster.CréerMessageFinal(GetComponent<ScoreComponent>().GetScore());
            scriptMaster.ProchaineScène(); 
             TransitionÉtat = TransitionJeu.Terminé;
            break;
         case TransitionJeu.Terminé:
            break;
      }
   }
}
