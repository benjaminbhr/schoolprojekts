using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    public class CardGenerator
    {
        public List<ICard> GenerateDeck()
        {
            List<ICard> card = new List<ICard>();
            foreach (var suite in (Suites[]) Enum.GetValues(typeof(Suites)))
            {
                card.AddRange(GenerateNumberCards(suite));
            }
            foreach (var picture in (Pictures[])Enum.GetValues(typeof(Pictures)))
            {
                card.AddRange(GeneratePictureCards(picture));
            }
            return card;
        }

        public List<ICard> GenerateNumberCards(Suites suite)
        {
            List<ICard> cards = new List<ICard>();
            for (int i = 1; i <= 10; i++)
            {
                ICard card = new NumberCard(i,suite);
                cards.Add(card);
            }
            return cards;
        }

        public List<ICard> GeneratePictureCards(Pictures picture)
        {
            List<ICard> cards = new List<ICard>();
            if (picture == Pictures.Jack)
            {
                cards.Add(new PictureCard(picture,Suites.Spades));
                cards.Add(new PictureCard(picture,Suites.Hearts));
                cards.Add(new PictureCard(picture,Suites.Diamonds));
            }
            else
            {
                cards.Add(new PictureCard(picture, Suites.Clubs));
                cards.Add(new PictureCard(picture, Suites.Hearts));
                cards.Add(new PictureCard(picture, Suites.Spades));
                cards.Add(new PictureCard(picture, Suites.Diamonds));
            }

            return cards;
        }
    }
}
