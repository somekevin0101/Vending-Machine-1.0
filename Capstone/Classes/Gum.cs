using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        public Gum(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public override string Consume()
        {
            return "Chew Chew,! Yum";
        }
    }
}
