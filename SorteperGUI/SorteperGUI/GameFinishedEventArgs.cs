using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class GameFinishedEventArgs : EventArgs
    {
        public bool IsFinished { get; set; }

        public GameFinishedEventArgs(bool finished)
        {
            this.IsFinished = finished;
        }
    }
}
