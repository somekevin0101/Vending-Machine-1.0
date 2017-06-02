using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int numberOfQuarters;
        public int NumberOfQuarters
        {
            get { return this.numberOfQuarters; }
        }

        private int numberOfNickels;
        public int NumberOfNickels
        {
            get { return this.numberOfNickels; }
        }

        private int numberOfDimes;
        public int NumberOfDimes
        {
            get { return this.numberOfDimes; }
        }

        public Change(decimal balance)
        {
            numberOfQuarters = (int)(balance / .25M);
            balance = balance - (numberOfQuarters * .25M);
            numberOfDimes = (int)(balance / .10M);
            balance = balance - (numberOfDimes * .10M);
            numberOfNickels = (int)(balance / .05M);
            balance = balance - (numberOfNickels * .05M);
        }
    }
}
