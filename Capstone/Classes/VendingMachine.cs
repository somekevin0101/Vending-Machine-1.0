using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private decimal balance = 0;
        public decimal Balance
        {
            get { return this.balance; }
            //set { this.balance = value; }
        }

        public decimal FeedMoney(decimal userMoneyInput)
        {
            balance += userMoneyInput;
            return balance;
        }
        private Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
        public VendingMachine(Dictionary<string, List<Item>> inventory)
        {
            this.inventory = inventory;
        }

        public Item Purchase(string slot)
        {
            List<Item> items = inventory[slot];
            Item purchasedItem = items[0];
            items.RemoveAt(0);
            return purchasedItem;
        }

        public bool IsSoldOut(string slot)
        {
            List<Item> items = inventory[slot];
            return items.Count == 0;
        }
        public bool InsufficientFunds(string slot)
        {
            List<Item> items = inventory[slot];
            return items[0].Price < balance;
        }
        public string CompleteTransaction(decimal balance)
        {
            int quarters = (int)(balance / .25M);
            balance = balance - (quarters * .25M);
            int dimes = (int)(balance / .10M);
            balance = balance - (dimes * .10M);
            int nickles = (int)(balance / .05M);
            balance = balance - (nickles * .05M);

            return "Your Change is " + quarters + " quarters, " + dimes + " dimes, " + nickles + " nickles";
        }

    }
}
