using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachFileReader
    {
        public Dictionary<string, List<Item>> ReadFile(string fullPath)
        {
            Dictionary<string, List<Item>> inventory = new Dictionary<string, List<Item>>();
            const int SlotIndex = 0;
            const int ProductIndex = 1;
            const int PriceIndex = 2;
            const int InitialQuantity = 5;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split('|');
                        List<Item> items = new List<Item>();
                        if (parts[SlotIndex].StartsWith("A"))
                        {
                            for (int i = 0; i < InitialQuantity; i++)
                            {
                                items.Add(new Chips(parts[ProductIndex], decimal.Parse(parts[PriceIndex])));
                            }
                        }
                        else if (parts[SlotIndex].StartsWith("B"))
                        {
                            for (int i = 0; i < InitialQuantity; i++)
                            {
                                items.Add(new Candy(parts[ProductIndex], decimal.Parse(parts[PriceIndex])));
                            }
                        }
                        else if (parts[SlotIndex].StartsWith("C"))
                        {
                            for (int i = 0; i < InitialQuantity; i++)
                            {
                                items.Add(new Drink(parts[ProductIndex], decimal.Parse(parts[PriceIndex])));
                            }
                        }
                        else if (parts[SlotIndex].StartsWith("D"))
                        {
                            for (int i = 0; i < InitialQuantity; i++)
                            {
                                items.Add(new Gum(parts[ProductIndex], decimal.Parse(parts[PriceIndex])));
                            }
                        }
                        inventory.Add(parts[SlotIndex], items);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            return inventory;
        }
    }
}
