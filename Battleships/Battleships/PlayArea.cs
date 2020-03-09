using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class PlayArea
    {
        private Field[,] fields = new Field[8,8];

        public Field[,] Fields
        {
            get { return fields; }
        }


        public void GenerateArea()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    fields[i, j] = new Field(i + 1, j + 1);
                }
            }
        }

        public void PlaceShip(int rownum,int colnum,Ship ship,bool horizontal)
        {
            for (int i = 0; i < ship.FieldLength; i++)
            {
                
                if (Fields[rownum,colnum].Taken)
                {

                }
                else
                {
                    Fields[rownum-1, colnum-1].Taken = true;
                    colnum++;
                }
            }
        }

        public Array GetFields()
        {
            return Fields;
        }
    }
}
