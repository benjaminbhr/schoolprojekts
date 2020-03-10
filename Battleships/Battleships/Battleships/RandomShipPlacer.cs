using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class RandomShipPlacer
    {

        public int RandomNum()
        {
            Random rnd = new Random();
            int rand = rnd.Next(0,7);
            return rand;
        }
        public void PlaceShip(Ship[] array,int indexnum,Field[,] enemyarray)
        {
            bool runningloop = true;
            while (runningloop)
            {
                List<Field> templist = new List<Field>();
                int rndcol = RandomNum();
                int rndrow = RandomNum();
                bool running = true;
                if (rndrow - array[indexnum].FieldLength >= 0 && rndrow - array[indexnum].FieldLength <= 7)
                {
                    if (rndrow - array[indexnum].FieldLength >= 0 && rndrow - array[indexnum].FieldLength <= 7)
                    {
                        while (running)
                        {
                            for (int j = 0; j < array[indexnum].FieldLength; j++)
                            {
                                if (!enemyarray[rndrow, rndcol].Taken)
                                {
                                    templist.Add(enemyarray[rndcol, rndrow]);
                                    rndrow--;
                                    running = false;
                                }
                                else
                                {
                                    j = 100;
                                    templist.Clear();
                                }
                            }
                        }
                    }
                    else if (rndcol - array[indexnum].FieldLength >= 0 && rndcol - array[indexnum].FieldLength <= 7)
                    {
                        while (running)
                        {
                            for (int i = 0; i < array[indexnum].FieldLength; i++)
                            {
                                if (!enemyarray[rndrow, rndcol].Taken)
                                {
                                    templist.Add(enemyarray[rndcol, rndrow]);
                                    rndcol--;
                                    running = false;
                                }
                                else
                                {
                                    i = 100;
                                    templist.Clear();
                                }
                            }
                        }
                        templist.Add(enemyarray[rndrow, rndcol]);
                        rndcol--;
                    }
                    foreach (Field field in templist)
                    {
                        int tempcolnum = field.ColumnNumber;
                        int temprownum = field.RowNumber;
                        enemyarray[tempcolnum - 1, temprownum - 1].Taken = true;
                        array[indexnum].Placed = true;
                        runningloop = false;
                    }
                }
                else if (rndcol + array[indexnum].FieldLength <= 7 | rndcol + array[indexnum].FieldLength == 7 | rndrow + array[indexnum].FieldLength <= 7 | rndrow + array[indexnum].FieldLength == 0)
                {
                    while (running)
                    {
                        for (int i = 0; i < array[indexnum].FieldLength; i++)
                        {
                            if (!enemyarray[rndrow, rndcol].Taken)
                            {
                                if (rndrow + array[indexnum].FieldLength <= 0)
                                {
                                    rndrow++;
                                    templist.Add(enemyarray[rndrow, rndcol]);
                                }
                                else
                                {
                                    templist.Add(enemyarray[rndrow, rndcol]);
                                    rndcol++;
                                }
                            }
                            else
                            {
                                i = 100;
                                running = false;
                                templist.Clear();
                            }
                            running = false;
                        }
                    }
                    foreach (Field field in templist)
                    {
                        int tempcolnum = field.ColumnNumber;
                        int temprownum = field.RowNumber;
                        enemyarray[temprownum - 1, tempcolnum - 1].Taken = true;
                        array[indexnum].Placed = true;
                        runningloop = false;
                    }
                }
            }
        }
    }
}
