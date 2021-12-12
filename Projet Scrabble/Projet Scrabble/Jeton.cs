﻿using System;

public class Jeton
{
        //attribut
        private string lettre;
        private int scorelettre;
        private int quantite; 

        //constructeur
        public Jeton(string lettre, int scorelettre, int quantite)
        {
            this.lettre = lettre;
            this.scorelettre = scorelettre;
            this.quantite = quantite;
        }

        public Jeton (string lines)
        {   
            string[]tab = lines.Split(";");
            this.lettre = tab[0];
            this.scorelettre = Convert.ToInt32(tab[1]);
            this.quantite = Convert.ToInt32(tab[2]);

        }

        //propriété
        public string Lettre
        {
            get {return this.lettre; }
            set { this.lettre = value; }
        }

        public override string ToString()  //qui retourne une chaîne de caractères qui décrit un jeton.
        {
            return "Le jeton a pour lettre : " + this.lettre + " qui a pour score : " + this.scorelettre +  "et il y en a :" + this.quantite; 
        }
}
