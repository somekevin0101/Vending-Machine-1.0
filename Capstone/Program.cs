using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;


namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineCLI vend = new VendingMachineCLI();
            vend.Display();
        }
    }
}
