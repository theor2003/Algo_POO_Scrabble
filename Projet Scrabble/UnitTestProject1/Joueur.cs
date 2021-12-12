using System;
using System.Collections.Generic;
using System.IO;

public class Joueur
{
	private string nom;
	private int score;
	private string[] mots_trouves; //tableau de mots que le joueur a trouvé
    private List<Jeton> jeton;

    public Joueur(string nom,int score=0,string[] mots_trouves=null, List<Jeton> jeton=null) //constructeur élément par élément
    {
		this.nom = nom;
		this.score = score;
		this.mots_trouves = mots_trouves;
        this.jeton = jeton;
    }
	public Joueur(string path) //constructeur avec fichier .txt //A MODIFIER POUR ACCOMODER LA FORME DE Joueurs.txt
    {
		string[] info = File.ReadAllLines(path);
		this.nom = info[0];
        if (info.Length >= 1)
        {
			this.score = Convert.ToInt32(info[1]);
            string[] list = new string[info.Length - 2];
            if (info.Length >= 2)
            {
				for(int i = 2; i < info.Length; i++)
                {
					list[i - 2] = info[i];
                }
			}
            this.mots_trouves = list;
		}
        else
        {
			this.score = 0;
			this.mots_trouves = null;
        }
	}
	
    public string Nom
    {
        get
        {
			return this.nom;
        }
    }
	public int Score
    {
        get
        {
			return this.score;
        }
        set
        {
            this.score = value;
        }
    }
	public string[] Mots_trouves
    {
        get
        {
            return this.mots_trouves;
        }
    }

    public void Add_Mot(string mot) //ajoute le mot dans la liste des mots déjà trouvés par le joueur au cours de la partie
    {
        string[] new_list = new string[this.mots_trouves.Length + 1];
        for(int i = 0; i < this.mots_trouves.Length; i++)
        {
            new_list[i] = this.mots_trouves[i];
        }
        new_list[this.mots_trouves.Length] = mot;
        this.mots_trouves = new_list;
    }

    public override string ToString() //retourne une chaîne de caractères qui décrit un joueur.
    {
        if (this.mots_trouves != null) // si le joueur a trouvé au moins un mot
        {
            string text = "Le joueur " + this.nom + " a un score de " + this.score + " points. Il a trouvé les mots suivants :\n";
            for (int i = 0; i < jeton.Count; i++)
            {
                text += this.jeton[i].Lettre + ", ";
            }
            return text;
        }
        else // si il n'y a aucun mots de trouvés
        {
            return "Le joueur " + this.nom + " n'a pas de points, car il n'a trouvé aucun mot.\n";
        }
    }

    public void Add_Score(int val) // qui ajoute une valeur au score
    {
        this.Score = this.Score + val;
    }

    public int Is_This_Letter_In_Hand(string lettre) //vérifie si le joueur a trouvé ce mot
    {
        int index = -1;
        for(int i = 0; i < this.jeton.Count; i++)
        {
            if (this.jeton[i].Lettre == lettre)
            {
                index = i;
            }
        }
        return index;
    }

    public void Add_Main_Courante(Jeton monjeton) //ajoute un jeton à la main courante
    {
        this.jeton.Add(monjeton);
    }

    public void Remove_Main_Courante(Jeton monjeton) //retire un jeton de la main courante 
    {
        if (this.Is_This_Letter_In_Hand(monjeton.Lettre) != -1) //verifie que le jeton est bien dans la main courante
        {
            this.jeton.Remove(monjeton); 
        }
    }
}
