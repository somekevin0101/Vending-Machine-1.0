using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTest
    {
        [TestMethod]
        public void ConsumeMethod()
        {
            Candy yumCandy = new Candy("name", 1.50M);

            Assert.AreEqual("Munch Munch, Yum!", yumCandy.Consume());

        }
    }
}
