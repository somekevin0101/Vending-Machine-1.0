using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public Drink(string name, decimal price) : base(name, price)
        {
        }
        public override string Consume()
        {
            return "Glug Glug, Yum!";
        }
    }
}
