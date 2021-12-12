using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToStringJeton()
        {
            string lettre = "A";
            int scorelettre = 0;
            int quantite = 0;
            string resultat = "A ;";
            Jeton jeton = new Jeton(lettre, scorelettre, quantite);
            string jet = jeton.ToString();
            Assert.AreEqual<string>(resultat, jet);
        }

        [TestMethod]
        public void TestToStringSac_Jeton()
        {
            Jeton j1 = new Jeton("A", 0, 0);
            Jeton j2 = new Jeton("B", 0, 0);
            Sac_Jeton s = new Sac_Jeton();
            s.ListeJeton.Add(j1);
            s.ListeJeton.Add(j2);
            string resultat = "Ce sac contient : \nA ; B ; ";
            string c = s.toString();
            Assert.AreEqual<string>(resultat, c);

        }

        [TestMethod]
        public void TestToStringDictionnaire()
        {
            Dictionnaire dico = new Dictionnaire(patch);
            string resultat = "Il y a 0 dans le dictionnaire.";
            string d = dico.toString();
            Assert.AreEqual<string>(resultat, d);
        }

        [TestMethod]
        public void TestToStringJoueur()
        {
            string nom = "A";
            int score = 0;
            string resultat =
            }



    }

}
