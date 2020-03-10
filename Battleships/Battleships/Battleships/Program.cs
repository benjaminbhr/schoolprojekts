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
        public static void CreateEnemyArea(PlayArea enemyarea)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (enemyarea.EnemyFields[i, j].Taken)
                    {
                        enemyarea.EnemyFields[i, j].ShipHit();
                        Console.Write($"[(XX)]");
                    }
                    else
                    {
                        Console.Write($"[({enemyarea.EnemyFields[i, j].ColumnNumber}|{enemyarea.EnemyFields[i, j].RowNumber})]");
                    }
                }
                Console.Write($"\n");
            }
        }
        static void Main(string[] args)
        {
            PlayArea playArea = new PlayArea();
            PlayArea enemyArea = new PlayArea();
            RandomShipPlacer placer = new RandomShipPlacer();
            playArea.GenerateArea();
            enemyArea.GenerateArea();
            enemyArea.GenerateEnemyShips();
            CreatePlayerArea(playArea);
            Console.WriteLine(" ");
            placer.PlaceShip(enemyArea.EnemyShips, 0, enemyArea.EnemyFields);
            Console.ReadLine();
            placer.PlaceShip(enemyArea.EnemyShips, 1, enemyArea.EnemyFields);
            Console.ReadLine();
            placer.PlaceShip(enemyArea.EnemyShips, 2, enemyArea.EnemyFields);
            Console.ReadLine();
            placer.PlaceShip(enemyArea.EnemyShips, 3, enemyArea.EnemyFields);
            Console.ReadLine();
            placer.PlaceShip(enemyArea.EnemyShips, 4, enemyArea.EnemyFields);
            CreateEnemyArea(enemyArea);
            Console.WriteLine("");
            Console.ReadLine();
        }
    }
}
