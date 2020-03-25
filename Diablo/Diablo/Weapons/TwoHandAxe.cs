using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Weapons
{
    class TwoHandAxe:Axe
    {
		// This list will hold the modifiers put on the weapon when it gets instanciated from the factory.
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

		/// <summary>
		/// String builder for the properties in the list, and also the properties from this class, and the base class.
		/// </summary>
		/// <returns>string</returns>
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
