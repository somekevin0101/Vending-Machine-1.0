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
        private Dictionary<string, List<Item>> inventory;

        private decimal balance = 0;
        public decimal Balance
        {
            get { return this.balance; }
        }

        public decimal FeedMoney(decimal userMoneyInput)
        {
            // this method will take any amount, 
            // the submenu limits the dollar-type inputs to 1, 2, 5, 10
            
            balance += userMoneyInput;
            
            return balance;
        }

        public VendingMachine(Dictionary<string, List<Item>> inventory)
        {
            this.inventory = inventory;
        }

        public Item Purchase(string slot)
        {
            if (!DoesSlotExist(slot))
            {
                throw new VendingMachineException($"{slot} does not exist in the vending machine.");
            }
            if (IsSoldOut(slot))
            {
                throw new VendingMachineException($"The item at {slot} is sold out.");
            }
            if (InsufficientFunds(slot))
            {
                throw new VendingMachineException($"You don't have enough to purchase the item at {slot}");
            }

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

        public bool DoesSlotExist(string slot)
        {
            return (inventory.ContainsKey(slot));
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

        public Change CompleteTransaction()
        {
            Change change = new Change(balance);
            balance = 0;
                        
            return change;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("VENDING MACHINE");
            sb.AppendLine("Slot ID     Name            Quantity       Cost");
            foreach(KeyValuePair<string , List<Item>> kvp in inventory)
            {
                if (kvp.Value.Count != 0)
                {
                    sb.AppendLine(kvp.Key + "\t" + kvp.Value[0].Name.PadRight(24) + kvp.Value.Count.ToString().PadRight(11)
                + kvp.Value[0].Price);
                }
                else
                {
                    sb.AppendLine($"{kvp.Key} \t SOLD OUT!");
                }
            }
            return sb.ToString();
        }

    }
}
