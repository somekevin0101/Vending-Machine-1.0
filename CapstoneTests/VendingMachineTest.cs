using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void CompleteTransactionChange()
        {
            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            VendingMachine testVend = new VendingMachine(inventory);
            testVend.FeedMoney(10);
            List<Item> allPurchases = new List<Item>();
            allPurchases.Add(new Candy("stuff", 1.50M));
            allPurchases.Add(new Gum("zing", .75M));
            allPurchases.Add(new Chips("pop", .75M));

            Assert.AreEqual(0.00M, testVend.CompleteTransaction(allPurchases));
        }
        [TestMethod]
        public void FeedMoneyTest()
        {
            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            VendingMachine testVend = new VendingMachine(inventory);

            Assert.AreEqual(5.00M, testVend.FeedMoney(5));
            Assert.AreEqual(15.00M, testVend.FeedMoney(10));
            Assert.AreEqual(115.00M, testVend.FeedMoney(100));

        }
        [TestMethod]
        public void DoesKeyExistTest()
        {
            List<Item> allPurchases = new List<Item>();
            allPurchases.Add(new Candy("stuff", 1.50M));
            allPurchases.Add(new Gum("zing", .75M));
            allPurchases.Add(new Chips("pop", .75M));

            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            inventory.Add("A1", allPurchases);
            VendingMachine testVend = new VendingMachine(inventory);

            Assert.AreEqual(false, testVend.DoesSlotExist("A1"));
            Assert.AreEqual(true, testVend.DoesSlotExist("B1"));

        }
        [TestMethod]
        public void IsSoldOutTest()
        {
            List<Item> allPurchases = new List<Item>();
            allPurchases.Add(new Candy("stuff", 1.50M));
            //allPurchases.Add(new Gum("zing", .75M));
            //allPurchases.Add(new Chips("pop", .75M));

            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            inventory.Add("A1", allPurchases);
            VendingMachine testVend = new VendingMachine(inventory);

            Assert.AreEqual(false, testVend.IsSoldOut("A1"));
            testVend.Purchase("A1");
            Assert.AreEqual(true, testVend.IsSoldOut("A1"));

        }
        [TestMethod]
        public void InsufficientFundsTest()
        {
            List<Item> allPurchases = new List<Item>();
            allPurchases.Add(new Candy("stuff", 1.50M));
            allPurchases.Add(new Gum("zing", .75M));
            //allPurchases.Add(new Chips("pop", .75M));

            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            inventory.Add("A1", allPurchases);
            VendingMachine testVend = new VendingMachine(inventory);
            testVend.FeedMoney(2);

            Assert.AreEqual(false, testVend.InsufficientFunds("A1"));
            testVend.Purchase("A1");
            Assert.AreEqual(true, testVend.InsufficientFunds("A1"));

        }
    }
}
