using System;
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
			string[] bonus_line = bonus_tab[i].Split();
			for(int j = 0; j < 15; j++)
            {
				this.bonus[i, j] = bonus_line[j];
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
}
