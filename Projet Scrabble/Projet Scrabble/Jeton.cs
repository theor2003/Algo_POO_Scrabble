using System;

public class Jeton
{
        //attribut
        private char lettre;
        private int scorelettre;

        //constructeur
        public Jeton(char lettre, int scorelettre)
        {
            this.lettre = lettre;
            this.scorelettre = scorelettre;
        }

        //propriété
        public char Lettre
        {
            get {return this.lettre; }
            set { this.lettre = Convert.ToChar(value); }
        }

        public override string ToString()  //qui retourne une chaîne de caractères qui décrit un jeton.
        {
            return "Le jeton a pour lettre : " + this.lettre + " qui a pour score : " + this.scorelettre; ;
        }
}
