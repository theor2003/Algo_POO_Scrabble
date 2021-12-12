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
            int scorelettre = 1;
            int quantite = 9;
            string resultat = "A;";
            Jeton jeton = new Jeton(lettre, scorelettre, quantite);
            string jet = jeton.ToString();
            Assert.AreEqual<string>(resultat, jet);
        }

        [TestMethod]
        public void TestToStringSac_Jetons()
        {
            Jeton j1 = new Jeton("A", 1, 9);
            Jeton j2 = new Jeton("B", 0, 0);
            Sac_Jeton sac = new Sac_Jeton();
            sac.jeton.Add(j1);
            sac.jeton.Add(j2);
            string resultat = "Ce sac contient : \nA ; B ; ";
            string c = sac.ToString();
            Assert.AreEqual<string>(resultat, c);

        }

        [TestMethod]
        public void TestToStringDictionnaire()
        {
            Dictionnaire dico = new Dictionnaire("A", "A") ;
            string resultat = "Il y a 0 dans le dictionnaire.";
            string d = dico.ToString();
            Assert.AreEqual<string>(resultat, d);
        }

       /* [TestMethod]
        //public void TestToStringJoueur()
        {
            string nom = "A";
            int score = 1;
            string resultat = 
            }*/



    }

}
