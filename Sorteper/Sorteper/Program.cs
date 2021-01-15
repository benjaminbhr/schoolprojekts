using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            CardGenerator generator = new CardGenerator();
            var deck = generator.GenerateDeck();
            List<ICard> shuffleddeck = manager.ShuffleCards(deck);
            Player[] players = new Player[2];
            players[0] = new Player(new List<ICard>());
            players[1] = new Player(new List<ICard>());
            manager.DealCardsToPlayers(shuffleddeck,players);
            //manager.MakePair(players[0]);

            Console.WriteLine("This is player 1's Hand!");
            foreach (var VARIABLE in players[0].Hand)
            {
                switch (VARIABLE.GetType().Name)
                {
                    case "NumberCard":
                        Console.WriteLine(((NumberCard)VARIABLE).Number + " of " + VARIABLE.Suite);
                        break;
                    case "PictureCard":
                        Console.WriteLine(((PictureCard)VARIABLE).Picture + " of " + VARIABLE.Suite);
                        break;
                }
            }

            Console.WriteLine("\n This is player 2's Hand!");
            foreach (var VARIABLE in players[1].Hand)
            {
                switch (VARIABLE.GetType().Name)
                {
                    case "NumberCard":
                        Console.WriteLine(((NumberCard)VARIABLE).Number + " of " + VARIABLE.Suite);
                        break;
                    case "PictureCard":
                        Console.WriteLine(((PictureCard)VARIABLE).Picture + " of " + VARIABLE.Suite);
                        break;
                }
            }


            Console.ReadLine();
        }
    }
}
