using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Sac_Jeton
{

	//attribut
	private List<Jeton> jeton;
	private Jeton jetonTiree;

	//constructeur
	public Sac_Jeton(List<char> jeton = null)
	{
		this.jeton = new List<Jeton>();
		//Random r = new Random();
		//Retire_Jeton(r);

		string[] text = File.ReadAllText("Jetons.txt");
		
		for ( i = 0 ; i < jeton.Count; i++)
        {
			string[] tab = lines.Split(";");
			Jeton jetonTiree = new Jeton (jetonTiree[i]);
			jeton.Add(jetonTiree);
		}


	}


	public char Retire_Jeton(Random r) // cette méthode permet de tirer au hasard un jeton parmi les possibles
	{
		this.jetonTiree = this.jeton[r.Next(0, jeton.Count)];
		return this.jetonTiree;

		// int index = r.Next(jeton.Count);
		//return jeton[index];

	}

	public override string ToString() // qui retourne une chaîne de caractères qui décrit en synthèse le contenu du Sac_Jetons
	{
		return "La lettre : " + this.jetonTiree + ", a un score de : " + /*this.scorejeton +*/ " et est dupliqué ";
	}

}




