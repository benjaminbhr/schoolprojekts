using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    public class Sparrow:Bird,IFly
    {
        public override string Eat()
        {
            return "I eat grains and seeds primarily!";
        }

        public override string Sound()
        {
            return "My sound is a rather simple song of one or a series of cheep or chirrup notes";
        }

        public string Fly()
        {
            return "I fly at very high altitudes!";
        }
    }
}
