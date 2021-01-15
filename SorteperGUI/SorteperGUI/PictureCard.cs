using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    class PictureCard : ICard, IPictureCard
    {
        public Suites Suite { get; set; }
        public Pictures Picture { get; set; }

        public PictureCard(Pictures picture, Suites suite)
        {
            this.Suite = suite;
            this.Picture = picture;
        }
    }
}
