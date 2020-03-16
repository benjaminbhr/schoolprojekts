using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Machine
    {
        public Drink[] drinkstorage = new Drink[5];
        public Snack[] snackstorage = new Snack[5];

        /// <summary>
        /// This is the admin login, it lets you access the refill methods for drinks and snacks
        /// </summary>
        /// <param name="userinput">this would fx be the console.readline where the user inputs his data</param>
        /// <returns>True or false depending if it matches the set admin code</returns>
        public bool AdminLogin(int userinput)
        {
            int code = 3220;
            bool adminornot = false;
            if (userinput == code)
            {
                adminornot = true;
            }
            return adminornot;
        }

        /// <summary>
        /// Counts the amount of drinks in the array that aren't == null.
        /// </summary>
        /// <returns>containing the count</returns>
        public int DrinksLeft()
        {
            int count = 5;
            for (int i = 0; i < drinkstorage.Length; i++)
            {
                if (drinkstorage[i] == null)
                {
                    count--;
                }
            }
            return count;
        }
        /// <summary>
        /// Counts the amount of snacks in the array that aren't == null.
        /// </summary>
        /// <returns>Int containing the count</returns>
        public int SnacksLeft()
        {
            int count = 0;
            for (int i = 0; i < snackstorage.Length; i++)
            {
                if (snackstorage[i] == null)
                {

                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// this refills the array with new objects.
        /// </summary>
        public void FillDrinkStorage()
        {
            for (int i = 0; i < drinkstorage.Length; i++)
            {
                drinkstorage[i] = new Drink("Coca-Cola",1,500,"bottle");
            }
        }

        /// <summary>
        /// this refills the array with new objects
        /// </summary>
        public void FillSnackStorage()
        {
            for (int i = 0; i < snackstorage.Length; i++)
            {
                snackstorage[i] = new Snack("Sour-creme chips", 2, 100);
            }
        }

    }

            

    }
