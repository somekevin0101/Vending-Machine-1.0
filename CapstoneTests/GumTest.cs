using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class GumTest
    {
        [TestMethod]
        public void ConsumeMethod()
        {
            Gum gumNoise = new Gum("name", 2.35M);
            Assert.AreEqual("Chew Chew! Yum", gumNoise.Consume());
        }
    }
}
