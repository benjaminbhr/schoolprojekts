using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class NumberCard : ICard
    {
        public int Number { get; set; }
        public Suites Suite { get; set; }

        public NumberCard(int number, Suites suite)
        {
            this.Number = number;
            this.Suite = suite;
        }
    }
}
