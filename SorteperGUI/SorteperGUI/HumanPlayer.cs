using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(List<ICard> hand, string name) : base(hand, name)
        {
            this.Hand = hand;
            this.Name = name;
        }
    }
}
