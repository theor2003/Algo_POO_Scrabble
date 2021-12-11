using System;
using System.Collections.Generic;
using System.IO;

public class Dictionnaire
{
	private List<string>[] mots;
	//On vient donner un tableau de List de mots
	//l'index 0 correspondra à la List de mots de longueur 2
	//l'index x correspondra à la List de mots de longueur x+2
	//la taille maximum théorique de notre tableau est de 13 car le plateau fait 15x15
	
	private string langue;

	public Dictionnaire(List<string>[] mots,string langue)
    {
		this.mots = mots;
		this.langue = langue;
	}

	public Dictionnaire(string path, string langue)
    {
		this.langue = langue;
		string[] dico = File.ReadAllLines(path);
		List<string>[] mots = new List<string>[dico.Length/2];
		for(int i = 0;i< dico.Length / 2; i++)
		{
			mots[i] = new List<string>();
			string[] mot_long = dico[2*i+1].Split(' ');
			for(int j = 0; j < mot_long.Length; j++)
            {
				mots[i].Add(mot_long[j]);
            }
		}
		this.mots = mots;
	}

	public override string ToString()
    {
		string description = "Ce dictionnaire est en " + this.langue + " et contient :";
		for(int i = 2; i < this.mots.Length+2; i++)
        {
			description += "\n" + this.mots[i-2].Count + " mots de longueur " + i; //on vient itérer pour toutes les List de mots
        }
		return description;
    }

	public bool RechDichoRecursif(string mot)
    {
		bool found = false; //on initialise a false notre variable
		for(int i = 0; i < this.mots[mot.Length-2].Count; i++)
        {
			if(this.mots[mot.Length - 2][i]==mot)
            {
				found = true; //dans le cas ou le mot cherché est égal a un des mots du dictionnaire alors on considère qu'il est trouvé
            }
        }
		return found;
    }
}
