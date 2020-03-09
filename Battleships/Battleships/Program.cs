using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Program
    {
        public static void CreatePlayerArea(PlayArea playArea)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (playArea.Fields[i,j].Taken)
                    {
                        playArea.Fields[i, j].ShipHit();
                        Console.Write($"[(O)]");
                    }
                    else
                    {
                        Console.Write($"[({playArea.Fields[i,j].ColumnNumber}|{playArea.Fields[i,j].RowNumber})]");
                    }
                }
                Console.Write($"\n");
            }
        }
        static void Main(string[] args)
        {
            Ship skib = new Ship(5);
            PlayArea playArea = new PlayArea();
            playArea.GenerateArea();
            playArea.PlaceShip(4,1,skib,true);
            CreatePlayerArea(playArea);
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
