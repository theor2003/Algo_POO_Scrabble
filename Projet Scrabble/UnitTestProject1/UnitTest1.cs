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
            string resultat = "Le jeton a pour lettre : A qui a pour score : 1et il y en a : 9";
            Jeton jeton = new Jeton(lettre, scorelettre, quantite);
            string jet = jeton.ToString();
            Assert.AreEqual(resultat, jet);
        }





    }

}
