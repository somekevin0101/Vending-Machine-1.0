using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChipsTest
    {
        [TestMethod]
        public void ConsumeMethod()
        {
            Chips chipsNoise = new Chips("name", 2.25M);

            Assert.AreEqual("Crunch Crunch, Yum!", chipsNoise.Consume());
        }
    }
}
