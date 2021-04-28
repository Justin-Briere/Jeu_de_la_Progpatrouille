using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;
public class Dijkstra : MonoBehaviour
{
    /// <summary>
    /// CETTE CLASSE RESSEMBLE BEAUCOUP À BFS. L'UNIQUE DIFFÉRENCE EST LA FACON DONT NOUS VÉRIFIONS LES POINTS
    /// EN EFFET, AU LIEU D'OBSERVER SI CELLE-CI A DÉJÀ ÉTÉ VÉRIFIER, NOUS COMPARONS LA DISTANCE POUR SE RENDRE À UN MÊME POINT
    /// ET REJETTONS CELUI-CI SI LA DISTANCE EST PLUS GRANDE QU'UNE PRÉCEDEMMENT TROUVÉ
    /// </summary>
    
        int LargeurCarte;
        int HauteurCarte;
        char[,] CarteAffiché;
        int distanceMax;
        int valeurDéplacement = 1;

        public Dijkstra(Carte maCarte)
        {
            Stopwatch chronomètre = new Stopwatch();
            LargeurCarte = maCarte.LargeurCarte;
            HauteurCarte = maCarte.HauteurCarte;
            distanceMax = LargeurCarte * HauteurCarte;
            Noeuds[,] tabNoeuds = new Noeuds[HauteurCarte, LargeurCarte];
            CarteAffiché = new char[HauteurCarte, LargeurCarte];

            //ÉTAPE #1 :    CRÉER LE TABLEAU CONTENANT LES MUR... UN TABLEAU DE "NOEUDS", 
            //              CONTENANT FALSE SI IL Y A UN MUR ET TRUE DANS LE CAS CONTRAIRE
            tabNoeuds = CreerTableau(tabNoeuds, maCarte);
            chronomètre.Start();

            //ÉTAPE #2 :    CHERCHER LE TRAJET POUR SE RENDRE DE LA SOURCE JUSQU'À LA DESTINATION
            var file = ChercheDestination(maCarte, tabNoeuds);
            chronomètre.Stop();

            //ÉTAPE #3 :    AFFICHER LE TABLEAU, AVEC LES MURS, LES POINT DISPONIBLE, AINSI QUE LES TRAJET
            //              QUE NOUS AVONS TROUVÉ À L'ÉTAPE #2
            if (file[maCarte.PositionDestination.Y, maCarte.PositionDestination.X].Précurseur != null)
                AfficherMatrice(maCarte, file, chronomètre);
            else
                Console.WriteLine("Il y a aucune solution trouvé  ");
        }

        /// <summary>
        /// CETTE FONCTION RECOIT LA CARTE DONNÉ, AINSI QUE CELLE RETOUCHÉ À L'ÉTAPE #1
        /// ELLE SERT À TROUVER LE CHEMIN, ET "BREAK" DÈS QU'ELLE EN TROUVE UN. CELA NOUS DONNE DONC LE CHEMIN LE PLUS COURT
        /// </summary>
        /// <param name="maCarte"></param>
        /// <param name="TabNoeuds"></param>
        /// <returns></returns>
        private Noeuds[,] ChercheDestination(Carte maCarte, Noeuds[,] TabNoeuds)
        {
            Queue<Noeuds> file = new Queue<Noeuds>(); 
            var rng = new System.Random(/*seed*/);

            Noeuds positionActuelle = TabNoeuds[maCarte.PositionSource.Y, maCarte.PositionSource.X];
            positionActuelle.distance = 0;
         
            positionActuelle.Visitée = true;   
            file.Enqueue(positionActuelle);
            //int i = 0;
            while (file.Count > 0)
            {
                
                var current = file.Dequeue();
                current.Visitée = true;
                var ListeVoisins = TrouverVoisins(current, TabNoeuds);
                if (ListeVoisins.Count > 0)
                {
                    file.Enqueue(current);

                    var randIndex = rng.Next(0, ListeVoisins.Count);
                    var randomNeighbour = ListeVoisins[randIndex];
                    randomNeighbour.Précurseur = current;
                    randomNeighbour.Visitée = true;
                    file.Enqueue(randomNeighbour);
                }
            }

            return TabNoeuds;
        }

        /// <summary>
        /// AVANT DE LES AJOUTER DANS LES POINTS VISITÉ, IL FAUT OBSERVER AUX ALENTOURS, PAR NORD, EST, SUD ET OUEST AUX ALENTOURS
        /// ELLE VÉRIFIER AUSSI L'ÉTAT DES POINTS AUX ALENTOURS,
        /// ILS DOIVENT ÊTRE : DANS LES LIMITES DE LA CARTES, ET APPELLE EstAccessible() POUR LES 2 AUTRES VÉRIFICATIONS
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="tabNoeuds"></param>
        /// <returns></returns>
        private List<Noeuds> TrouverVoisins(Noeuds pts, Noeuds[,] tabNoeuds)
        {

            List<Noeuds> ListV = new List<Noeuds>();
            int x = pts.ValeurPosition.X;
            int y = pts.ValeurPosition.Y;
            if (dansLaCarte(x, y - 1) && !tabNoeuds[y - 1, x].Visitée && tabNoeuds[y - 1, x].EstAccessible)
                ListV.Add(tabNoeuds[y - 1, x]);
            if (dansLaCarte(x + 1, y) && !tabNoeuds[y, x + 1].Visitée && tabNoeuds[y, x + 1].EstAccessible )
                ListV.Add(tabNoeuds[y, x + 1]);
            if (dansLaCarte(x, y + 1) && !tabNoeuds[y + 1, x].Visitée && tabNoeuds[y + 1, x].EstAccessible )
                ListV.Add(tabNoeuds[y + 1, x]);
            if (dansLaCarte(x - 1, y) && !tabNoeuds[y, x - 1].Visitée && tabNoeuds[y, x - 1].EstAccessible)
                ListV.Add(tabNoeuds[y, x - 1]);
            return ListV;
        }

        /// <summary>
        /// FONCTION SERVANT À DÉTERMINER SI LE POINT EST DANS LES LIMITES DE LA CARTE
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public bool dansLaCarte(int X, int Y)
        {
            return (X >= 0 && X < LargeurCarte && Y >= 0 && Y < HauteurCarte);
        }

        /// <summary>
        /// C'EST L'ÉTAPE #1 : ON CREER UN TABLEAU SEMBLABLE À CELUI RECU PAR LA CLASSE CARTE, MAIS ON L'ADAPTE UN PEU
        /// NOTAMENT EN CREEANT UN TABLEAU DE "NOEUDS"
        /// </summary>
        /// <param name="tabNoeuds"></param>
        /// <param name="maCarte"></param>
        /// <returns></returns>
        public Noeuds[,] CreerTableau(Noeuds[,] tabNoeuds, Carte maCarte)
        {

            for (int i = 0; i < maCarte.HauteurCarte; ++i)
            {
                for (int j = 0; j < maCarte.LargeurCarte; ++j)
                {
                    tabNoeuds[i, j] = new Noeuds(j, i, maCarte[i, j], distanceMax);
                }
            }
            return tabNoeuds;
        }

        /// <summary>
        /// L'ÉTAPE #3 : ON AFFICHE LA CARTE AVEC LE CHEMIN QUE NOUS AVONS EMPRUNTÉ POUR SE RENDRE À LA DESTINATION
        /// AUSSI, LA FONCTION S'OCCUPE D'AFFICHER QUELQUES STATISTIQUES, COMME LE TEMPS, LA DISTANCE ET LE NOMBRE DE NOEUDS VÉRIFIÉ
        /// </summary>
        /// <param name="maCarte"></param>
        /// <param name="file"></param>
        /// <param name="chronomètre"></param>
        public void AfficherMatrice(Carte maCarte, Noeuds[,] file, Stopwatch chronomètre)
        {
            var chemin = ConstruireChemin(maCarte, file);
            var distance = chemin.Count;
            int NoeudsVérifiés = 0;
            CarteAffiché[maCarte.PositionSource.Y, maCarte.PositionSource.X] += 'S';
            CarteAffiché[maCarte.PositionDestination.Y, maCarte.PositionDestination.X] += 'D';
            Noeuds points = null;
            var Nmap = new char[maCarte.HauteurCarte * 2 + 1, maCarte.LargeurCarte * 2 + 1];
            string a = new string('=', 50);
            Console.WriteLine(a);
            Console.WriteLine($"Dijkstra map : {maCarte}");
            for (int i = 0; i < maCarte.HauteurCarte * 2 + 1; ++i)
            {
                for (int j = 0; j < maCarte.LargeurCarte * 2 + 1; ++j)
                {
                   Nmap[j,i] += '#';

                }
            }
            for (int i = 0; i < maCarte.HauteurCarte; ++i)
            {
                for (int j = 0; j < maCarte.LargeurCarte; ++j)
                {
                    var chemin2 = ConstruireChemin(maCarte, file, file[j,i].ValeurPosition);
                    while (chemin2.Count != 0)
                    {
                        points = chemin2.Pop();
                        if (Nmap[points.ValeurPosition.Y * 2 + 1, points.ValeurPosition.X * 2 + 1] != 'o')
                            Nmap[points.ValeurPosition.Y * 2 + 1, points.ValeurPosition.X * 2 + 1] += 'o';
                        if (dansLaCarte(i, j) && !(file[j,i].Précurseur == null))
                        {
                         
                            var X = Average(points.Précurseur.ValeurPosition.X, points.ValeurPosition.X) * 2 + 1;
                            var Y = Average(points.Précurseur.ValeurPosition.Y, points.ValeurPosition.Y) * 2 + 1;
                            if (Nmap[(int)Y, (int)X] != 'o')
                            Nmap[(int)Y, (int)X] += 'o'; 
                            ++NoeudsVérifiés;

                        }
                    }
                }
            }
            /// Print la MAP
            for (int i = 1; i < maCarte.HauteurCarte * 2 + 1; ++i)
            {
                for (int j = 1; j < maCarte.LargeurCarte * 2 + 1; ++j)
                {
                  
                    var test = Nmap[j, i] == '#' ? '*' : 'o';
                    
                        if ((i == 3 && j == 3) || (i == 39 && j == 35))
                            test = 'D';

                    Console.Write(test);
                }

                Console.WriteLine();
            }
            Console.WriteLine($"Temps d'exécution : {chronomètre.Elapsed.TotalMilliseconds} millisecondes");
            Console.WriteLine($"la Distance est de : {distance + 1 }");
            Console.WriteLine($"Le nombre de noeuds visité est de : {NoeudsVérifiés - 1}");
        }

        /// <summary>
        /// UNE FOIS LE CHEMIN TROUVÉ PAR L'ÉTAPE #2, IL FAUT REAGARDER TOUS LES PRÉCURSEURS
        /// AFIN DE RETRACER LE CHEMIN QUE NOUS AVONS UTILISÉ
        /// </summary>
        /// <param name="maCarte"></param>
        /// <param name="TabNoeuds"></param>
        /// <returns></returns>
        private Stack<Noeuds> ConstruireChemin(Carte maCarte, Noeuds[,] TabNoeuds)
        {
            Stack<Noeuds> chemin = new Stack<Noeuds>();

            Noeuds pts = TabNoeuds[maCarte.PositionDestination.Y, maCarte.PositionDestination.X];

            while (TabNoeuds[pts.ValeurPosition.Y, pts.ValeurPosition.X].Précurseur != null)
            {
                pts = TabNoeuds[pts.ValeurPosition.Y, pts.ValeurPosition.X].Précurseur;
                chemin.Push(pts);
            }
            chemin.Pop();
            return chemin;
        }
        public static float Average(int a, int b)
        {
            
            return (float)(a+b)/2;
        }

        private Stack<Noeuds> ConstruireChemin(Carte maCarte, Noeuds[,] TabNoeuds,Point2D pts )
        {
            Stack<Noeuds> chemin = new Stack<Noeuds>();
            Noeuds points = TabNoeuds[pts.Y, pts.X];

            while (TabNoeuds[points.ValeurPosition.Y, points.ValeurPosition.X].Précurseur != null)
            {
                 points = TabNoeuds[points.ValeurPosition.Y, points.ValeurPosition.X].Précurseur;
                chemin.Push(points);
            }
            if (chemin.Count != 0)
            chemin.Pop();
            return chemin;
        }

        /// <summary>
        /// RECOIT LA DISTNCE OÙ NOUS SOMME ET LA DISTANCE OÙ NOUS VOULONS ALLER
        /// LA FONCTION EST À RENVOYER S'IL EST VRAIS QUE LA DISTANCE D'OÙ NOUS VENONS + LE COÛT DU DÉPLACEMENT EST
        /// INFÉRIEUR À LA DISTANCE DÉJA COMPRISE DANS LE BLOC OÙ NOUS VOULONS ALLER.
        /// SI OUI, LA FONCTION TROUVERVOISIN() S'OCCUPERA DE CHANGER LA FACON DE SE RENDRE À CE POINT "X"
        /// </summary>
        /// <param name="TabNoeudsFinale"></param>
        /// <param name="TabNoeudsInitiale"></param>
        /// <returns></returns>
        private bool MINValue(int TabNoeudsFinale, int TabNoeudsInitiale)

        {
            return TabNoeudsFinale > TabNoeudsInitiale + valeurDéplacement;
        }
    
}
