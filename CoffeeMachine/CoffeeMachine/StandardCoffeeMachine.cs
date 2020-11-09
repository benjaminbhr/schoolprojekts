using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class StandardCoffeeMachine:IHotDrinkMachine
    {
        double WaterAmount { get; set; }

        private bool filterInserted;

        public bool FilterInserted
        {
            get { return filterInserted; }
            set { filterInserted = value; }
        }

        private EProductType productType;

        public EProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }


        public void InsertFilter()
        {
            FilterInserted = true;
        }

        public void FillWater(int cupNr)
        {
            double waterAmount = 0.5 * cupNr;
            WaterAmount = waterAmount;
        }

        public string BrewProduct(int cupNr)
        {
            FillWater(cupNr);
            InsertFilter();
            InsertProduct();
            return cupNr.ToString() + " Cups of " + ProductType.ToString() + " Has been brewed!";
        }

        public string InsertProduct()
        {
            return ProductType.ToString() + " Have been inserted!";
        }

        public StandardCoffeeMachine()
        {
            this.ProductType = EProductType.BeanCoffee;
        }
    }
}
