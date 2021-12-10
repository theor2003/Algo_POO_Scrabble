using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Sac_Jeton
{

	//attribut
	private List<char> jeton;
	private char jetonTiree;

	//constructeur
	public Sac_Jeton(List<char> jeton = null)
	{
		this.jeton = new List<char>();
		Random r = new Random();
		Retire_Jeton(r);

	}


	public static void Readfile()
	{
		string[] lines = File.ReadAllLines("Jetons.txt");
		//string[] tab = lines.Split(",");

		foreach (string line in lines)

			Console.WriteLine(line);
		Console.ReadKey();

		// faire un tablo de string + split readallline, colonne 0 : la lettre, colonne 1 :Le score, colonne 2 : nb de jeton

	}

	public char Retire_Jeton(Random r) // cette méthode permet de tirer au hasard un jeton parmi les possibles
	{
		this.jetonTiree = this.jeton[r.Next(0, jeton.Count)];
		return this.jetonTiree;

	}

	public override string ToString() // qui retourne une chaîne de caractères qui décrit en synthèse le contenu du Sac_Jetons
	{
		return "La lettre : " + this.jetonTiree + ", a un score de : " + /*this.scorejeton +*/ " et est dupliqué ";
	}

}




