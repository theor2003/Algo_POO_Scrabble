using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Sac_Jeton
{

	private List<Jeton> jeton; //List de tous les jetons encore dans le sac

	public Sac_Jeton(string path= "Jetons.txt") //crée une instance de sac de jeton a partir d'un fichier .txt, par défaut Jetons.txt
	{
		this.jeton = new List<Jeton>();
		string[] text = File.ReadAllLines(path);
		for ( int i = 0 ; i < text.Length; i++)
        {
			string[] tab = text[i].Split(";");
			Jeton a_ajouter = new Jeton(tab[0], Convert.ToInt32(tab[1]), Convert.ToInt32(tab[2]));
			this.jeton.Add(a_ajouter);
		}
	}


	public Jeton Retire_Jeton(Random r) // tire au hasard un jeton parmi les possibles et le retire du sac
	{
		int rang = 0;
		Jeton tiré;
		do
		{
			rang = r.Next(0,27);
			tiré = this.jeton[rang]; //tire un jeton au hasard
		} while (tiré.Quantite == 0); //dans le cas ou on tire un jeton avec une quantité égale a 0
		this.jeton[rang].Quantite = this.jeton[rang].Quantite - 1; //enleve un de quantite du jeton tiré
		return tiré;
	}

	public override string ToString() // retourne une description du Sac de jetons
	{
		string description = "Ce sac contient :";
		for(int i = 0; i < 27; i++)
        {
			description += "\n" + this.jeton[i].Quantite + " jeton.s " + this.jeton[i].Lettre + " chacun de ces jetons vaut " + this.jeton[i].Score;
		}
		return description;
	}

}




