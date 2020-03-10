using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Ship
    {
		private int fieldlength;

		public int FieldLength
		{
			get { return fieldlength; }
			set { fieldlength = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private bool placed = false;

		public bool Placed
		{
			get { return placed; }
			set { placed = value; }
		}



		public Ship(int fieldlength,string shipname)
		{
			this.FieldLength = fieldlength;
			this.Name = shipname;
		}

	}
}
