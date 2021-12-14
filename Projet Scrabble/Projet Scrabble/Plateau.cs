﻿using System;
using System.IO;

public class Plateau
{
	private string[,] lettres_tab;
	private string[,] bonus;
	
	public Plateau()
	{
		this.lettres_tab = new string[15, 15];
		this.bonus = new string[15, 15];
		string[] bonus_tab = File.ReadAllLines("Bonus.txt");
		for (int i = 0; i < 15; i++)
		{
			string[] bonus_line = bonus_tab[i].Split(";");
			for (int j = 0; j < 15; j++)
			{
				this.bonus[i, j] = bonus_line[j];
			}
		}
	}
	public Plateau(string path)
	{
		this.lettres_tab = new string[15, 15];
		this.bonus = new string[15, 15];
		string[] lettre_tab = File.ReadAllLines(path);
		string[] bonus_tab = File.ReadAllLines("Bonus.txt");
		for (int i = 0; i < 15; i++)
		{
			string[] lettre_line = lettre_tab[i].Split(";");
			string[] bonus_line = bonus_tab[i].Split(";");
			for (int j = 0; j < 15; j++)
			{
				this.lettres_tab[i, j] = lettre_line[j];
				if(lettres_tab[i, j] == "_")
                {
					this.bonus[i, j] = bonus_line[j];
				}
                else
                {
					//this.bonus[i, j] = "  "; //A REMPLACER TEST COULEUR
					this.bonus[i, j] = bonus_line[j];
				}
			}
		}
	}
	public string[,] Lettres_tab
    {
        get { return this.lettres_tab; }
    }
	public string[,] Bonus
    {
        get { return this.bonus; }
    }

	public void toString()
    {
		Console.WriteLine("    A  B  C  D  E  F  G  H  I  J  K  L  M  O  P");
		for (int i = 1; i < 16; i++)
		{
            if (i < 10)
            {

				Console.Write(" " + i + " ");
			}
            else
            {
				Console.Write(i + " ");
			}
			for (int j = 0; j < 15; j++)
			{
				switch(this.bonus[i-1, j])
                {
					case "  ":
						Console.ForegroundColor = ConsoleColor.Black;
						Console.BackgroundColor = ConsoleColor.DarkGreen;
						break;
					case "M3":
						Console.ForegroundColor = ConsoleColor.Black;
						Console.BackgroundColor = ConsoleColor.DarkRed;
						break;
					case "M2":
						Console.ForegroundColor = ConsoleColor.Black;
						Console.BackgroundColor = ConsoleColor.Red;
						break;
					case "L3":
						Console.ForegroundColor = ConsoleColor.Black;
						Console.BackgroundColor = ConsoleColor.DarkBlue;
						break;
					case "L2":
						Console.ForegroundColor = ConsoleColor.Black;
						Console.BackgroundColor = ConsoleColor.Blue;
						break;
				}
				Console.Write(" " + this.Lettres_tab[i-1, j] + " ");
				Console.ResetColor();
			}
			Console.WriteLine();
		}
	}
	public bool Test_Plateau(string mot, int ligne, int colonne, char direction,Dictionnaire dico,Joueur joueur,Sac_Jeton sac,Random r)
    {
		bool possible = true;
		if(direction == 'h')
        {
			possible = this.Placement_Horizontal(mot, ligne, colonne) && this.Appartenance_Dico(mot, dico) && Appartenance_Main_Et_Mots_Croise(mot, joueur, ligne, colonne, direction);
        }
		else if (direction == 'v')
        {
			possible = this.Placement_Vertical(mot, ligne, colonne) && this.Appartenance_Dico(mot, dico) && Appartenance_Main_Et_Mots_Croise(mot, joueur, ligne, colonne, direction);
		}
        if (possible)
        {
			joueur.Add_Score(Calcul_Score(mot, ligne, colonne, direction));
			joueur.Add_Mot(mot);
			this.Placer_Lettres(mot, joueur, ligne, colonne, direction);
			for(int i = 0; i <= 7-joueur.Jeton.Count; i++)
            {
				joueur.Add_Main_Courante(sac.Retire_Jeton(r));
            }
        }
		return possible;
    }
	public bool Placement_Vertical(string mot, int ligne, int colonne)
    {
		return ((mot.Length + ligne - 1) <= 15);
    }
	public bool Placement_Horizontal(string mot, int ligne, int colonne)
    {
		return ((mot.Length + colonne - 1) <= 15);
	}
	public bool Appartenance_Dico(string mot, Dictionnaire dico)
    {
		return dico.RechDichoRecursif(mot);
    }
	public bool Appartenance_Main_Et_Mots_Croise(string mot,Joueur joueur, int ligne, int colonne, char direction)
    {
		bool done = true;
		string LettreEnCours = null;
		for(int i = 0; i < mot.Length; i++)
		{
			LettreEnCours = Convert.ToString(mot[i]);
			if (direction == 'h')
            {
				if (this.lettres_tab[ligne - 1, colonne - 1 + i] != "_" && this.lettres_tab[ligne - 1, colonne - 1 + i] != LettreEnCours)
				{
					done = false;
				}
				if (this.lettres_tab[ligne - 1, colonne - 1 + i] == "_" && (joueur.Is_This_Letter_In_Hand(LettreEnCours) == -1 && joueur.Is_This_Letter_In_Hand("*") == -1))
				{
					done = false;
				}
			}
			else if (direction == 'v')
			{
				if (this.lettres_tab[ligne - 1 + i, colonne - 1] != "_" && this.lettres_tab[ligne - 1, colonne - 1 + i] != LettreEnCours)
				{
					done = false;
				}
				if (this.lettres_tab[ligne - 1 + i, colonne - 1] == "_" && (joueur.Is_This_Letter_In_Hand(LettreEnCours) == -1 && joueur.Is_This_Letter_In_Hand("*") == -1))
				{
					done = false;
				}
			}
        }
		return done;
    }
	public void Placer_Lettres(string mot, Joueur joueur, int ligne, int colonne, char direction)
    {
		string LettreEnCours = null;
		for (int i = 0; i < mot.Length; i++)
		{
			LettreEnCours = Convert.ToString(mot[i]);
			if (direction == 'h')
			{
				if (this.lettres_tab[ligne - 1, colonne - 1 + i] == "_" && (joueur.Is_This_Letter_In_Hand(LettreEnCours) != -1 || joueur.Is_This_Letter_In_Hand("*") != -1))
				{
					joueur.Remove_Main_Courante(LettreEnCours);
					this.lettres_tab[ligne - 1, colonne - 1 + i] = LettreEnCours;
				}
			}
			else if (direction == 'v')
			{
				if (this.lettres_tab[ligne - 1 + i, colonne - 1] == "_" && (joueur.Is_This_Letter_In_Hand(LettreEnCours) != -1 || joueur.Is_This_Letter_In_Hand("*") != -1))
				{
					joueur.Remove_Main_Courante(LettreEnCours);
					this.lettres_tab[ligne - 1 + i, colonne - 1] = LettreEnCours;
				}
			}
		}
	}
	public int Calcul_Score(string mot,int ligne,int colonne,char direction)
    {
		int score = 0;
		int score_pion = 0;
		int multiple_mot = 0;
		string[] score_lettre = File.ReadAllLines("Jetons.txt");
		for (int i = 0; i < mot.Length; i++)
		{
			for (int j = 0; j < 27; j++)
			{
				string[] ligne_lettre = score_lettre[j].Split(";");
				if (Convert.ToString(mot[i]) == ligne_lettre[0])
				{
					score_pion = Convert.ToInt32(ligne_lettre[1]);
				}
			}
			if (direction == 'h')
			{
                switch (this.bonus[ligne - 1, colonne - 1 + i])
                {
					case "M3":
						multiple_mot += 3;
						break;
					case "M2":
						multiple_mot += 2;
						break;
					case "L3":
						score_pion = score_pion * 3;
						break;
					case "L2":
						score_pion = score_pion * 2;
						break;
				}
				this.bonus[ligne - 1, colonne - 1 + i] = "  ";
			}
			else if (direction == 'v')
			{
				switch (this.bonus[ligne - 1 + i, colonne - 1])
				{
					case "M3":
						multiple_mot += 3;
						break;
					case "M2":
						multiple_mot += 2;
						break;
					case "L3":
						score_pion = score_pion * 3;
						break;
					case "L2":
						score_pion = score_pion * 2;
						break;
				}
				this.bonus[ligne - 1 + i, colonne - 1] = "  ";
			}
			score += score_pion;
		}
        if (multiple_mot != 0)
        {
			score = score * multiple_mot;
        }
		return score;
    }
}