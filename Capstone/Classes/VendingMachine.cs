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
            // this method will take any amount, the submenu limits the dollar-type inputs to 1, 2, 5, 10
            
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
            string directory = Directory.GetCurrentDirectory();
            string file = "log.txt";
            string fullPath = Path.Combine(directory, file);
            VendingMachFileWriter log = new VendingMachFileWriter(fullPath);

            List<Item> items = inventory[slot];
            Item purchasedItem = items[0];
            items.RemoveAt(0);
            string oldBalance = balance.ToString();
            balance -= purchasedItem.Price;
            log.LogMessage(purchasedItem.Name + " " + slot + "   " + oldBalance + "    " + balance);
            return purchasedItem;
        }
        public bool DoesKeyExist(string slot)
        {

            return !(inventory.ContainsKey(slot));
        }


        public bool IsSoldOut(string slot)
        {
            List<Item> items = inventory[slot];
            return items.Count == 0;
        }
        public bool InsufficientFunds(string slot)
        {
            List<Item> items = inventory[slot];
            return items[0].Price > balance;

        }
        public decimal CompleteTransaction(List<Item> allPurchases)
        {
            Console.WriteLine("Enjoy your meal!");
            foreach(Item food in allPurchases)
            {
                Console.WriteLine(food.Consume());
            }
            int quarters = (int)(balance / .25M);
            balance = balance - (quarters * .25M);
            int dimes = (int)(balance / .10M);
            balance = balance - (dimes * .10M);
            int nickles = (int)(balance / .05M);
            balance = balance - (nickles * .05M);

            Console.WriteLine("Your Change is " + quarters + " quarters, " + dimes + " dimes, " + nickles + " nickles");
            return balance;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("VENDING MACHINE");
            sb.AppendLine("Slot ID     Name            Quantity       Cost");
            foreach(KeyValuePair<string , List<Item>> kvp in inventory)
            {
                sb.AppendLine(kvp.Key + "\t" + kvp.Value[0].Name.PadRight(24) + kvp.Value.Count.ToString().PadRight(11)
                + kvp.Value[0].Price);
            }
            return sb.ToString();
        }

    }
}
