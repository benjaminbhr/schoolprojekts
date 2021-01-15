using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class HandEventArgs : EventArgs
    {
        public List<ICard> Hand { get; set; }

        public HandEventArgs(List<ICard> hand)
        {
            Hand = hand;
        }
    }
}
