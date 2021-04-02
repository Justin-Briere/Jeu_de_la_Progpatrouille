using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallPosition
{
    // 0000 -> NO WALLS
    // 1111 -> LEFT,RIGHT,UP,DOWN
    OUEST = 1, // 0001
    EST = 2, // 0010
    NORD = 4, // 0100
    SUD = 8, // 1000

    VISITED = 128, // 1000 0000
}

public struct Position
{
    public int X;
    public int Y;
}

public struct Neighbour
{
    public Position Position;
    public WallPosition WallAdjacent;
}
public class CreationLab : MonoBehaviour
{
    private static WallPosition GetOppositeWall(WallPosition wall)
    {
        switch (wall)
        {
            case WallPosition.EST: return WallPosition.OUEST;
            case WallPosition.OUEST: return WallPosition.EST;
            case WallPosition.NORD: return WallPosition.SUD;
            case WallPosition.SUD: return WallPosition.NORD;
            default: return WallPosition.OUEST;
        }
    }

    private static WallPosition[,] ApplyRecursiveBacktracker(WallPosition[,] maze, int width, int height)
    {
        // here we make changes
        var rng = new System.Random(/*seed*/);
        var positionStack = new Stack<Position>();
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        maze[position.X, position.Y] |= WallPosition.VISITED;  // 1000 1111
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = TrouverCasNonVisiter(current, maze, width, height);

            if (neighbours.Count > 0)
            {
                positionStack.Push(current);

                var randIndex = rng.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randIndex];

                var nPosition = randomNeighbour.Position;
                maze[current.X, current.Y] &= ~randomNeighbour.WallAdjacent;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.WallAdjacent);
                maze[nPosition.X, nPosition.Y] |= WallPosition.VISITED;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    private static List<Neighbour> TrouverCasNonVisiter(Position p, WallPosition[,] labyrinthe, int largeur, int hauteur)
    {
        var listeVoisins = new List<Neighbour>();

        if (p.X > 0) // left
        {
            if (!labyrinthe[p.X - 1, p.Y].HasFlag(WallPosition.VISITED))
            {
                listeVoisins.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    WallAdjacent = WallPosition.OUEST
                });
            }
        }

        if (p.Y > 0) // DOWN
        {
            if (!labyrinthe[p.X, p.Y - 1].HasFlag(WallPosition.VISITED))
            {
                listeVoisins.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    WallAdjacent = WallPosition.SUD
                });
            }
        }

        if (p.Y < hauteur - 1) // UP
        {
            if (!labyrinthe[p.X, p.Y + 1].HasFlag(WallPosition.VISITED))
            {
                listeVoisins.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    WallAdjacent = WallPosition.NORD
                });
            }
        }

        if (p.X < largeur - 1) // RIGHT
        {
            if (!labyrinthe[p.X + 1, p.Y].HasFlag(WallPosition.VISITED))
            {
                listeVoisins.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    WallAdjacent = WallPosition.EST
                });
            }
        }

        return listeVoisins;
    }

    public static WallPosition[,] GenererWalls(int largeur, int hauteur)
    {
        WallPosition[,] maze = new WallPosition[largeur, hauteur];
        WallPosition wallPosInitial = WallPosition.EST | WallPosition.OUEST | WallPosition.NORD | WallPosition.SUD;
        for (int i = 0; i < largeur; ++i)
        {
            for (int j = 0; j < hauteur; ++j)
            {
                maze[i, j] = wallPosInitial;  // 1111
            }
        }

        return ApplyRecursiveBacktracker(maze, largeur, hauteur);
    }
}
