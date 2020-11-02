using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometriopga
{
    public abstract class Shape
    {
		private EShapeType _shapeType;

		public EShapeType Shape_Type
		{
			get { return _shapeType; }
			protected set { _shapeType = value; }
		}

        public abstract double Area();
    }
}
