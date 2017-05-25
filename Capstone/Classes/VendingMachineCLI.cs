using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        public void Display()
        {
            PrintHeader();

            while (true)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                Console.WriteLine("");
                Console.WriteLine("What option do you want to select?");

                string input = Console.ReadLine();

                if (input == "1" || input == "(1)")
                {
                    Console.WriteLine("These are the items for sale");

                }
                else if (input == "2" || input == "(2)")
                {
                    SubmenuCLI subMenu = new SubmenuCLI();
                    subMenu.Display();
                }
                else if (input == "Q" || input == "q" || input == "(Q)" || input == "(q)")
                {
                    Console.WriteLine("Thank you for using Vending Machine, have a good day!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }

        }


        private void PrintHeader()
        {
            Console.WriteLine("******WELOME TO VENDING MACHINE 1.0*******");
            Console.WriteLine("");

            
        }

    }
}
