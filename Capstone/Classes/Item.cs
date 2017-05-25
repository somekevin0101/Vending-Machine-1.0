using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public abstract class Item
    {

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        private decimal price;
        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        
        public virtual string Consume()
        {
            
            return "yummy";
        }
    }
}
