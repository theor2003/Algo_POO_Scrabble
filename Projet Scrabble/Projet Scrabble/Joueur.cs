using System;
using System.IO;

public class Joueur
{
	private string nom;
	private int score;
	private string[] mots_trouves;

	public Joueur(string nom,int score=0,string[] mots_trouves=null)
    {
		this.nom = nom;
		this.score = score;
		this.mots_trouves = mots_trouves;
    }
	public Joueur(string path)
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
}
