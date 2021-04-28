using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public class Noeuds 
{
    public bool EstAccessible { get; private set; }

    public Noeuds Précurseur;

    public bool Visitée;
    public bool EstPrécurseur;
    public double distanceLigneDroite;
    public char Symbole;
    public Point2D ValeurPosition { get; private set; }

    public int distance;


    public Noeuds(int x, int y, bool accessible) // constructeur de Noeuds
    {
        ValeurPosition = new Point2D(x, y);
        EstAccessible = accessible;
        Précurseur = null;
        Visitée = false;
        Symbole = accessible ? '.' : '*';
        EstPrécurseur = false;


    }
    public Noeuds(int x, int y, bool accessible, int longueur) // constructeur de Noeuds
    {
        ValeurPosition = new Point2D(x, y);
        EstAccessible = accessible;
        Précurseur = null;
        Symbole = accessible ? '.' : '*';
        distance = longueur;
    }
    public Noeuds(int x, int y, bool accessible, double distanceLigneDroite) // constructeur de Noeuds
    {
        ValeurPosition = new Point2D(x, y);
        EstAccessible = accessible;
        Précurseur = null;
        Visitée = false;
        Symbole = accessible ? '.' : '*';
        EstPrécurseur = false;
        distanceLigneDroite = 400;

    }
}
