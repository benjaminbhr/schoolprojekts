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

		public Ship(int fieldlength)
		{
			this.FieldLength = fieldlength;
		}

	}
}
