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
        private string fullPath;
        public VendingMachFileWriter(string fullPath)
        {
            this.fullPath = fullPath;
        }
        public void LogMessage(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(DateTime.UtcNow + " " + message);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error occured writing file " + ex.ToString());
            }

        }
        public void SalesReport(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(message);
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine("Error occured writing file " + ex.ToString());
            }
        }
    }
}

