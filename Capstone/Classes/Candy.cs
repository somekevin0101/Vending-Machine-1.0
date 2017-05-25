using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Candy : Item
    {
        public Candy(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
