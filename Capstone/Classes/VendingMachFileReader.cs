using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public static class VendingMachFileReader
    {
        public static void ReadFile()
        {
            string directory = Environment.CurrentDirectory;
            string filename = "vendingmachine.csv";

            string fullPath = Path.Combine(directory, filename);

            Dictionary<string, List<Item>> dictionary = new Dictionary<string, List<Item>>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] items = line.Split('|');

                        List<VMItems> items = new List<VMItems>();
                        for (int i = 0; i < 5; i++)
                        {
                            if (slot starts with A)
                            {
                        }
                    }
                }
                dictionary.Add(slot, items);
            }
            }
    }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
}
    }
}
