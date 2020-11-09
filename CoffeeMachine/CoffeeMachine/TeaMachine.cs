using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class TeaMachine:IHotDrinkMachine
    {
        double WaterAmount { get; set; }

        private EProductType productType;

        public EProductType ProductType
        {
            get { return productType; }
            private set { productType = value; }
        }


        public void FillWater(int cupNr)
        {
            double waterAmount = 0.5 * cupNr;
            WaterAmount = waterAmount;
        }
        public string BrewProduct(int cupNr)
        {
            FillWater(cupNr);
            InsertProduct();
            return cupNr.ToString() + " Cups of " + ProductType.ToString() + " Has been brewed!";
        }

        public string InsertProduct()
        {
            return ProductType.ToString() + " Have been inserted!";
        }

        public TeaMachine()
        {
            this.ProductType = EProductType.Tea;
        }
    }
}
