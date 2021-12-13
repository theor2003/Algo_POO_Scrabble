using System;
using System.IO;

public class Plateau
{
	private string[,] lettres_tab;
	private string[,] bonus;
	private Dictionnaire dictionnaire;	
	
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
	public bool Intersection(string mot, int ligne, int colonne, char direction) // qui vérifie que le mot à placer a bien une intersection avec un des mots dejà placé
	{
		bool intersection = false;
		
		if (direction == 'h')
        {
			for (int i = 0; i < mot.Length; i++)
            {
				if (lettres_tab[ligne,colonne] != "   ")
                {
					intersection = true;
                }
            }
        }
		else if (direction == 'v')
        {
			for (int j = 0; j < mot.Length; j++)
            {
				if (lettres_tab[ligne, colonne] != "   ")
                {
					intersection = true;
                }
            }
        }
		return intersection;


		
	}

	public bool DansPlateau(string mot, int ligne, int colonne, char direction) // qui vérifie que le mot rentre bien dans le plateau (nb de lettre <= 15)
	{
		bool dansplateau = true;

		if (direction == 'h')
		{
			for (int i = 0; i < mot.Length; i++)
			{
				if ((mot.Length + colonne) > lettres_tab.GetLength(0))
				{
					Console.WriteLine((mot.Length + colonne));
					dansplateau = false;
				}

			}
		}

		if (direction == 'v')
		{
			for (int j = 0; j < mot.Length; j++)
			{
				if ((mot.Length + ligne) > lettres_tab.GetLength(1))
				{
					dansplateau = false;
				}
			}
		}
		return dansplateau;
	}

	public bool MotsDicoVerticale() // qui vérifie que les mots verticale appartiennent au dictionnaire
	{
		bool motdicov = false;

		for (int i = 0; i < lettres_tab.GetLength(0); i++)
		{
			for (int j = 0; j < lettres_tab.GetLength(1); j++)
			{
				if (lettres_tab[i, j] != "   ")
				{
					string mot = lettres_tab[i, j];
					int compteur = 1;
					string lettre = lettres_tab[i, j + 1];

					while (lettre != "   ")
					{
						mot = mot + lettre;
						compteur++;
						lettre = lettres_tab[i, j + compteur];
					}

					if (dictionnaire.RechDichoRecursif(0, dictionnaire.mots[mot.Length - 2].Length, mot) == false)
					{
						motdicov = false;
					}
				}
			}
		}
		return motdicov;
	}

	public bool MotsDicoHorizontale() // qui vérifie que les mots verticale appartiennent au dictionnaire
	{
		bool motdicoh = false;

		for (int i = 0; i < lettres_tab.GetLength(1); i++)
		{
			for (int j = 0; j < lettres_tab.GetLength(0); j++)
			{
				if (lettres_tab[i, j] != "   ")
				{
					string mot = lettres_tab[i, j];
					int compteur = 1;
					string lettre = lettres_tab[i, j + 1];

					while (lettre != "   ")
					{
						mot = mot + lettre;
						lettre = lettres_tab[i, j];
						compteur++;
						Console.Write(mot);
					}

					if (dictionnaire.RechDichoRecursif(0, dictionnaire.mots[mot.Length - 2].Length, mot) == false)
					{
						motdicoh = false;
					}
				}
			}
		}
		return motdicoh;

		public bool LaMain(int mot) //Les lettres de la main utiles au mot appartiennent bien à la main
		{
			bool lamain = false;	

        }
	}
}
