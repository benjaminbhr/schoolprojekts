using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Snack:Product
    {
		/// <summary>
		/// how many grams in the snack
		/// </summary>
		private int amount;

		public int Amount
		{
			get { return amount; }
			set { amount = value; }
		}

		public Snack(string name, int number, int amount)
		{
			this.Name = name;
			this.Number = number;
			this.Amount = amount;
		}


	}
}
