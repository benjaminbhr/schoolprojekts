using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeMachine
{
    public class Joke
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public int Id { get; set; }

        public Joke()
        {
            Id++;
        }
    }
}
