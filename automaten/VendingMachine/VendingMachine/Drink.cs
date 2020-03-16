using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Drink:Product
    {
        /// <summary>
        /// how many milliliters in the drink
        /// </summary>
        private int amount;

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// what type of container fx bottle or can
        /// </summary>
        private string container;

        public string Container
        {
            get { return container; }
            set { container = value; }
        }



        public Drink(string name, int number, int amount, string container)
        {
            this.Name = name;
            this.Number = number;
            this.Amount = amount;
            this.Container = container;
        }
    }
}
