using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:/Users/Théo/source/repos/Projet Scrabble/Projet Scrabble/joueur.txt
            /*Joueur Théo = new Joueur("Théoooooo", 0, null);
            Joueur Théo2 = new Joueur("joueur.txt");
            Console.WriteLine(Théo.Nom);
            Console.WriteLine(Théo.Score);*/
            /*foreach(string element in Théo2.Mots_trouves)
            {
                Console.WriteLine(element);
            }
            Théo2.Add_Mot("Mael");*/
            //Théo.Add_Score(10);
            //Console.WriteLine(Théo.Score);
            //Test 114

            /*
            List<string>[] dico = new List<string>[4];
            dico[0] = new List<string>();
            dico[1] = new List<string>();
            dico[2] = new List<string>();
            dico[3] = new List<string>();

            dico[3].Add("Pipou");
            dico[3].Add("Pilou");
            dico[3].Add("Ripou");
            dico[2].Add("Pipa");
            Dictionnaire Larousse = new Dictionnaire(dico, "Francé");
            Console.WriteLine(Larousse.ToString());

            Console.WriteLine(Larousse.RechDichoRecursif("Theo"));
            Console.WriteLine(Larousse.RechDichoRecursif("Pipou"));
            */
            /*
            Dictionnaire Robert = new Dictionnaire("Francais.txt", "Français");
            Console.WriteLine(Robert.ToString());
            */

            /*
            Random r = new Random();
            Sac_Jeton game1 = new Sac_Jeton();
            Console.WriteLine(game1.ToString());
            for(int i = 0; i < 102; i++)
            {
                Jeton tiré = game1.Retire_Jeton(r);
                Console.WriteLine(tiré.Lettre + " " + tiré.Quantite);
            }
            Console.WriteLine(game1.ToString());
            */

            Plateau game1 = new Plateau("InstancePLateau.txt");
            game1.toString();
            Console.WriteLine("J'EN PEUX PLUS AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            
        }
    }
}
