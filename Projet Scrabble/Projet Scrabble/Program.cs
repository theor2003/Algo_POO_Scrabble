using System;
using System.IO;

namespace Projet_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:/Users/Théo/source/repos/Projet Scrabble/Projet Scrabble/joueur.txt
            Joueur Théo = new Joueur("Théoooooo", 0, null);
            Joueur Théo2 = new Joueur("joueur.txt");
            Console.WriteLine(Théo.Nom);
            Console.WriteLine(Théo.Score);
            /*foreach(string element in Théo2.Mots_trouves)
            {
                Console.WriteLine(element);
            }
            Théo2.Add_Mot("Mael");*/
            Théo.Add_Score(10);
            Console.WriteLine(Théo.Score);
            //Test 101
        }
    }
}
