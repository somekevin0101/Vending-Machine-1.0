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

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split('|');
                        List<Item> items = new List<Item>();
                        if (parts[0].StartsWith("A"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Chips(parts[1], decimal.Parse(parts[2])));
                            }
                        }
                        else if (parts[0].StartsWith("B"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Candy(parts[1], decimal.Parse(parts[2])));
                            }
                        }
                        else if (parts[0].StartsWith("C"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Drink(parts[1], decimal.Parse(parts[2])));
                            }
                        }
                        else if (parts[0].StartsWith("D"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                items.Add(new Gum(parts[1], decimal.Parse(parts[2])));
                            }
                        }
                        inventory.Add(parts[0], items);
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
