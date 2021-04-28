using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class Carte : MonoBehaviour
{
    
        const string CheminAccès = "../../../Cartes/";
        const char Source = 'S';
        const char Destination = 'D';
        const char Accessible = '.';
        const char Inaccessible = '*';
        public int LargeurCarte { get; private set; }
        public int HauteurCarte { get; private set; }

        public Point2D PositionSource { get; private set; }
        public Point2D PositionDestination { get; private set; }

        bool[,] DataCarte;

        public bool this[int y, int x]
        {
            get
            {
                return DataCarte[y, x];
            }
        }

        public Carte(string nomFichier)
        {

            PositionSource = new Point2D(-1, -1);
            PositionDestination = new Point2D(-1, -1);
            string[] donnéesBrutesCarte = LireDonnéesCarte(CheminAccès + nomFichier);
            DataCarte = CréerCarte(donnéesBrutesCarte);
        }

        static string[] LireDonnéesCarte(string nomFichier)
        {
            char[] séparateurs = new char[] { '\t' };
            List<string> listeDonnéeCarte = new List<string>();
            StreamReader fEntrée = new StreamReader(nomFichier);
            while (!fEntrée.EndOfStream)
            {
                string ligneCarte = fEntrée.ReadLine();
                listeDonnéeCarte.Add(ligneCarte);
            }
            fEntrée.Close();
            return listeDonnéeCarte.ToArray();
        }

        bool[,] CréerCarte(string[] donnéesBrutesCarte)
        {

            LargeurCarte = donnéesBrutesCarte.Min(x => x.Length);
            HauteurCarte = donnéesBrutesCarte.Length;
            bool[,] modèleCarte = new bool[HauteurCarte, LargeurCarte];
            for (int y = 0; y < HauteurCarte; ++y)
            {
                for (int x = 0; x < LargeurCarte; ++x)
                {
                    char symbole = donnéesBrutesCarte[y][x];
                    modèleCarte[y, x] = TraiterDonnéeBrute(symbole, x, y);
                }
            }
            return modèleCarte;
        }

        private bool TraiterDonnéeBrute(char symbole, int x, int y)
        {
            if (symbole == Source)
            {
                PositionSource = new Point2D(x, y);
            }
            else
            {
                if (symbole == Destination)
                {
                    PositionDestination = new Point2D(x, y);
                }
            }
            return symbole != Inaccessible;
        }
    }

