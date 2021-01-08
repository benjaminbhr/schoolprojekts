using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    public class Player
    {
        public List<ICard> Hand { get;set; }

        public Player(List<ICard> hand)
        {
            this.Hand = hand;
        }
    }
}
