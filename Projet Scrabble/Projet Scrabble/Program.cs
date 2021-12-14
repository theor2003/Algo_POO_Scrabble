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
            Joueur Maelle = new Joueur("Maelle", 0, null);
            Joueur Théo2 = new Joueur("Joueurs.txt");
            List<Joueur> joueurs = new List<Joueur>();
            joueurs.Add(Théo);
            joueurs.Add(Maelle);
            //joueurs.Add(Théo3);
            Jeu game = new Jeu(joueurs);
            game.Partie(r);
        }
    }
}
