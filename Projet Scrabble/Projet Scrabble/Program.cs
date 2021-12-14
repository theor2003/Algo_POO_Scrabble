using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Joueur Théo = new Joueur("Théoooooo", 0, null);
            Joueur Théo2 = new Joueur("Joueurs.txt");
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(Théo);
            joueurs.Add(Théo2);
            Jeu game = new Jeu(joueurs);
            while (true)
            {
                game.Tour(joueurs[1], r);
            }
        }
    }
}
