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

        public void Display(VendingMachine vend)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";
            string fullPath = Path.Combine(directory, filename);
            vmfw = new VendingMachFileWriter(fullPath);
            List<Item> allPurchases = new List<Item>();




            while (true)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("(Q) Return to Main Menu");

                string input = Console.ReadLine().ToUpper();

                if (input == "1" || input == "(1)")
                {
                    decimal moneyParsed = 0;

                    Console.WriteLine("Please enter a dollar amount(1, 2, 5, 10,)");
                    string moneyInput = Console.ReadLine();
                    Decimal.TryParse(moneyInput, out moneyParsed);
                    vend.FeedMoney(moneyParsed);
                    Console.WriteLine("Money balance is $ " + vend.Balance);
                    vmfw.LogMessage("FEED MONEY:     " + moneyParsed.ToString("C") + "      " + vend.Balance.ToString("C"));
                }

                else if (input == "2" || input == "(2)")
                {
                    Console.WriteLine("Which slot would you like to choose?");

                    string slotInput = Console.ReadLine().ToUpper();
                    if (vend.IsSoldOut(slotInput))
                    {
                        Console.WriteLine("I'm sorry that item is sold out, please try again with another choice.");
                    }
                    else if (vend.InsufficientFunds(slotInput))
                    {
                        Console.WriteLine("I'm sorry you do not have enough money");
                        
                    }
                    else
                    {
                        Item purchasedItem = vend.Purchase(slotInput);
                        allPurchases.Add(purchasedItem);
                        Console.WriteLine("you have purchased " + purchasedItem.Name);
                        Console.WriteLine("your new balance is " + vend.Balance);
                        
                    }
                }
                else if (input == "3" || input == "(3)")
                {
                    vend.CompleteTransaction(vend.Balance, allPurchases);
                    vmfw.LogMessage("GIVE CHANGE :" + vend.Balance.ToString("C") + "      " + vend.Balance.ToString("C"));
                    string salesPath = Path.Combine(directory, "salesreport.txt");
                    vmfw = new VendingMachFileWriter(salesPath);
                    decimal totalSales = 0;
                    foreach (Item item in allPurchases)
                    {
                        vmfw.SalesReport(item.Name + "|" + item.Price);
                        totalSales += item.Price;
                    }
                    vmfw.SalesReport("");
                    vmfw.SalesReport("**TOTAL SALES** " + totalSales.ToString("C"));
                }

                else if (input == "Q" || input == "(Q)")
                {
                    Console.WriteLine("Returning to Main Menu");
                    break;
                }
            }
        }
    }
}


