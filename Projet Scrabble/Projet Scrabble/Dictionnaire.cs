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

	public Dictionnaire(List<string>[] mots,string langue) //constructeur direct
    {
		this.mots = mots;
		this.langue = langue;
	}

	public Dictionnaire(string path, string langue) //constructeur avec le fichier .txt
    {
		this.langue = langue;
		string[] dico = File.ReadAllLines(path); //conversion du .txt en tableau de strings
		List<string>[] mots = new List<string>[dico.Length/2]; //création du tableau de List de string
		for(int i = 0;i< dico.Length / 2; i++) //on itère pour toutes les longueurs de mots différentes
		{
			mots[i] = new List<string>(); //initialisation de la List au rang i
			string[] mot_long = dico[2*i+1].Split(' '); //séparation de la string de mots en un tableau de mots individuels
			for(int j = 0; j < mot_long.Length; j++) //itération sur le tableau de mot précedement créé
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

    internal bool RechDichoRecursif(int v, object length, string mot)
    {
        throw new NotImplementedException();
    }
}
