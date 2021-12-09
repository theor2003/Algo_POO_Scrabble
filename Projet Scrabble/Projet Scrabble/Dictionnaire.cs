using System;
using System.Collections.Generic;

public class Dictionnaire
{
	private string[,] mots;
	private string langue;
	public Dictionnaire(string[,] mots,string langue)
    {
		this.mots = mots;
		this.langue = langue;
	}
	public override string ToString()
    {
		return "a";
    }
}
