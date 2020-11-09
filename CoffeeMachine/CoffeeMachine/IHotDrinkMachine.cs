﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public interface IHotDrinkMachine
    { 
        void FillWater(int cupsnr);

        string BrewProduct(int cupsnr);

        string InsertProduct();
    }
}
