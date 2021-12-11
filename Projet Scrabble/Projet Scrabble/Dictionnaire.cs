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
		return "Il y a " + nbmot + " dans le dictionnaire francais."; // je sais c'est pas ca mais ca peux aider 
		
	}

	public bool RechDichoRecursif(int debut, int fin, string mot)
	{
		int tailleMot = mot.Length;
		int milieu = (debut + fin) / 2;
		int resultat = String.Compare(mot, dico[tailleMot - 2][milieu]);

		if (debut > fin)
        {
			return false;
        }
		else if (resultat == 0)
		{
			return true;
		}
		else if(resultat > 0)
        {
			return RechDichoRecursif(milieu + 1, fin, mot);
        }
		else if(resultat < 0)
        {
			return RechDichoRecursif(debut , milieu - 1,mot);
        }
		
		
	}
}
