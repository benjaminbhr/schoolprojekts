using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Field
    {
		private int columnnumber;

		public int ColumnNumber
		{
			get { return columnnumber; }
			set { columnnumber = value; }
		}
		private int rownumber;

		public int RowNumber
		{
			get { return rownumber; }
			set { rownumber = value; }
		}

		private bool taken;

		public bool Taken
		{
			get { return taken; }
			set { taken = value; }
		}
		private bool hit;

		public bool Hit
		{
			get { return hit; }
			set { hit = value; }
		}



		public void ShipHit()
		{
			this.Hit = true;
		}


		public Field(int columnnum,int rownum)
		{
			this.ColumnNumber = columnnum;
			this.RowNumber = rownum;
		}

	}
}
