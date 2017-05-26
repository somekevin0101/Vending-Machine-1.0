using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class DrinkTest
    {
        [TestMethod]
        public void ConsumeMethod()
        {
            Capstone.Classes.Drink drinkNoise = new Capstone.Classes.Drink("name", 3.75M);
            Assert.AreEqual("Glug Glug, Yum!", drinkNoise.Consume());
        }
    }
}
