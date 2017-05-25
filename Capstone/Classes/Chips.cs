using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class Chips : Item
    {
        public Chips(string name, decimal price) : base(name, price)
        {
        }
        public override string Consume()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
