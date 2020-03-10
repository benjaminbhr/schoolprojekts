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

        public int RandomNumber()
        {
            Random rnd = new Random();
            int rand = rnd.Next(0,7);
            return rand;
        }

        private Field[,] enemyfields = new Field[8,8];

        public Field[,] EnemyFields
        {
            get { return enemyfields; }
        }

        private Ship[] enemyships = new Ship[5];

        public Ship[] EnemyShips
        {
            get { return enemyships; }
        }


        public Ship[] playerships = new Ship[5];
        


        public void GenerateArea()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    fields[i, j] = new Field(i + 1, j + 1);
                    enemyfields[i, j] = new Field(i + 1, j + 1);
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

        public void GenerateEnemyShips()
        {
            enemyships[0] = new Ship(5,"Carrier");
            enemyships[1] = new Ship(4, "Battleship");
            enemyships[2] = new Ship(3, "Cruiser");
            enemyships[3] = new Ship(3, "Submarine");
            enemyships[4] = new Ship(2, "Destroyer");
        }

        public Array GetFields()
        {
            return Fields;
        }
    }
}
