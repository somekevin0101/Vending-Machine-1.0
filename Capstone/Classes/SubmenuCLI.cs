using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class SubmenuCLI
    {
        private VendingMachFileWriter vmfw;

        public void Display()
        {
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";
            string fullPath = Path.Combine(directory, filename);
            vmfw = new VendingMachFileWriter(fullPath);

            directory = Environment.CurrentDirectory;
            filename = "vendingmachine.csv";
            fullPath = Path.Combine(directory, filename);
            VendingMachFileReader vmfr = new VendingMachFileReader();
            Dictionary<string, List<Item>> inventory = vmfr.ReadFile(fullPath);

            VendingMachine vend = new VendingMachine(inventory);

            while (true)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("(Q) Return to Main Menu");

                string input = Console.ReadLine();

                if (input == "1" || input == "(1)")
                {
                    decimal moneyParsed = 0;

                    Console.WriteLine("Please enter a dollar amount(1, 2, 5, 10,)");
                    string moneyInput = Console.ReadLine();
                    Decimal.TryParse(moneyInput, out moneyParsed);

                    Console.WriteLine("Money balance is $ " + vend.FeedMoney(moneyParsed));
                }

                else if (input == "2" || input == "(2)")
                {
                    Console.WriteLine("Which slot would you like to choose?");

                    string slotInput = Console.ReadLine();
                    if (vend.IsSoldOut(slotInput))
                    {
                        Console.WriteLine("I'm sorry that item is sold out, please try again with another choice.");
                    }
                    else if (vend.InsufficientFunds(slotInput))
                    {
                        Console.WriteLine("I'm sorry you do not have enough money");
                    }

                    vend.Purchase(slotInput);
                }
                else if (input == "3" || input == "(3)")
                {
                    vend.CompleteTransaction(vend.Balance);

                }

                else if (input == "Q" || input == "(Q)" || input == "q" || input == "(q)")
                {
                    Console.WriteLine("Returning to Main Menu");
                    break;
                }
            }
        }
    }
}


