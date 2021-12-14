﻿using System;
using System.Collections.Generic;

public class Jeu
{
	private Dictionnaire mondico;
	private Plateau monplateau;
	private Sac_Jeton monsac_jeton;
	private List<Joueur> joueurs;
	private int timer;
	private static int nb_tour=0;
	public Jeu(List<Joueur> joueurs, string path_plateau=null,string path_sac= "Jetons.txt", string path_dico="Francais.txt",string langue_dico = "Francais")
	{
		this.joueurs = joueurs;
		this.mondico = new Dictionnaire(path_dico, langue_dico);
        if (path_plateau == null)
        {
			this.monplateau = new Plateau();
		}
        else
        {
			this.monplateau = new Plateau(path_plateau);
		}
		this.monsac_jeton = new Sac_Jeton(path_sac);
		nb_tour = 0;
		Console.WriteLine("Saisir le temps max pour trouver un mot : ");
		this.timer = Convert.ToInt32(Console.ReadLine());
	}
	public bool Tour(Joueur joueur,Random r)
    {
		string answer = null;
		int ligne;
		int colonne;
		char direction;
		joueur.Piocher_Necessaire(this.monsac_jeton, r);
		bool possible = true;
        if (this.monsac_jeton.Nb_Jetons > 0 && nb_tour!=0)
        {
			do
			{
				Console.Clear();
				this.monplateau.toString();
				Console.WriteLine(joueur.ToString());
				Console.WriteLine("Quel mot voulez vous placer ?");
				answer = Console.ReadLine();
				Console.WriteLine("Quelle ligne ?");
				ligne = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Quelle colonne ?");
				colonne = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Quelle direction (h ou v) ?");
				direction = Convert.ToChar(Console.ReadLine());
				Console.WriteLine(this.monplateau.Test_Plateau(answer, ligne, colonne, direction, this.mondico, joueur, this.monsac_jeton, r));
				Console.WriteLine(this.monplateau.Placement_Horizontal(answer, ligne, colonne));
				Console.WriteLine(this.monplateau.Appartenance_Dico(answer, this.mondico));
				Console.WriteLine(this.monplateau.Appartenance_Main_Et_Mots_Croise(answer, joueur, ligne, colonne, direction));
				//Console.WriteLine("."+this.monplateau.Lettres_tab[0, 0]+".");
			} while (this.monplateau.Test_Plateau(answer, ligne, colonne, direction, this.mondico, joueur, this.monsac_jeton, r) == false);
		}
		else if (nb_tour == 0)
        {
            do
            {
				Console.Clear();
				this.monplateau.toString();
				Console.WriteLine(joueur.ToString());
				Console.WriteLine("Quel mot voulez vous placer ?");
				answer = Console.ReadLine();
				Console.WriteLine("Quelle direction (h ou v) ?");
				direction = Convert.ToChar(Console.ReadLine());
			} while (this.monplateau.Test_Plateau(answer, 8, 8, direction, this.mondico, joueur, this.monsac_jeton, r) == false);
		}
		nb_tour++;
		return possible;
    }
	public void Partie(Random r)
    {
		int nb_joueurs = this.joueurs.Count;
		int joueur_en_cour = 0;
		while(this.Tour(this.joueurs[joueur_en_cour], r) && nb_tour<2)
        {
			joueur_en_cour++;
			if (joueur_en_cour == nb_joueurs)
			{
				joueur_en_cour = 0;
			}
		}
		Console.Clear();
		Console.WriteLine("Partie terminée");
		Console.Write("Le gagnant est ");
		int index_gagnant = 0;
		for(int i = 0; i < nb_joueurs; i++)
        {
            if (this.joueurs[i].Score > this.joueurs[index_gagnant].Score)
            {
				index_gagnant = i;
            }
        }
		Console.WriteLine(this.joueurs[index_gagnant].Nom + " avec un score de " + this.joueurs[index_gagnant].Score + " pts");
		Console.WriteLine("\ntous les scores :");
		foreach(Joueur element in this.joueurs)
        {
			Console.WriteLine("- " + element.Nom + " : " + element.Score + " pts");
        }
    }
}