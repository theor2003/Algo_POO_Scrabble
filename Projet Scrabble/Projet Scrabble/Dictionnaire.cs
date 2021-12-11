using System;
using System.Collections.Generic;

public class Dictionnaire
{
	/*private string[,] mots;
	private string langue;

	public Dictionnaire(string[,] mots,string langue)
    {
		this.mots = mots;
		this.langue = langue;
	}

	public override string ToString()
    {
		return "a";
    }*/

	private List<string[]> dico;
	string nomFichier;

	public Dictionnaire(string nomFichier)
	{
		this.dico = new List<string[]>();
	}

	public List<string[]> Dico
	{
		get { return dico; }
	}

	public string toString()
	{
		int nbmot = 0;

		for (int i = 0; i < dico.Count; i++)
		{
			for (int j = 0; j < dico[i].Length; j++)
			{
				nbmot = nbmot + 1;
			}
		}
		return "Il y a " + nbmot + " dans le dictionnaire francais.";
	}
}
