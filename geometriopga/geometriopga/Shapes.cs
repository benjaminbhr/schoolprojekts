using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public class Shapes
    {
		private EShapeType shape;

		public EShapeType Shape
		{
			get { return shape; }
			protected set { shape = value; }
		}

	}
}
