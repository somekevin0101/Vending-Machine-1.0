using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachFileWriter
    {
        public void VMFileWriter(string path)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "vendingMachine_updated.csv";
            string fullPath = Path.Combine(directory, filename);
        }
        public static void LogMessage(string message)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine(DateTime.UtcNow + method.GetType().Name + "transactionAmount" + VendingMachine.Balance);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error occured writing file " + ex.ToString());
            }

        }
    }
}

