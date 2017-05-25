using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachine
    {
        [TestMethod]
        public void CompleteTransactionChange()
        {
            VendingMachine testVend = new VendingMachine();

            //Assert.AreEqual("Your Change is 6 quarters, 1 dimes, 1 nickles", testVend.CompleteTransaction(1.65));

        }
    }
}
