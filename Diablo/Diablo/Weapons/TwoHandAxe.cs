using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Weapons
{
    class TwoHandAxe:Axe
    {
		public List<string> magic = new List<string>();
		private int distance;

		public int Distance
		{
			get { return distance; }
			set { distance = value; }
		}

		public TwoHandAxe(int damage, string name, int distance) : base(damage, name)
		{
			this.Distance = distance;
		}

		public override string ToString()
		{
			StringBuilder st = new StringBuilder();
			foreach (string item in magic)
			{
				st.Append(item + "\n");
			}
			return base.ToString() + "\nDistance: " + Distance + "\nMagic properties\n" + st.ToString();
		}
	}
}
