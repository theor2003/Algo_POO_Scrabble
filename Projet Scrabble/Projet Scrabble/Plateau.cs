using System;
using System.IO;

public class Plateau
{
	private string[,] lettres_tab;
	private string[,] bonus;
	//private Dictionnaire dictionnaire;	
	
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
	public bool Test_Plateauu(string mot, int ligne, int colonne, char direction)
    {
		return false;
    }
}