using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class DrawEventArgs :EventArgs
    {
        public Player[] Players { get; set; }

        public DrawEventArgs(Player[] players)
        {
            this.Players = players;
        }
    }
}
