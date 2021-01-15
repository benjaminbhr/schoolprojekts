using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper
{
    public class GameManager
    {
        public IEnumerable<List<T>> SplitList<T>(List<T> bigList, int nSize)
        {
            for (int i = 0; i < bigList.Count; i += nSize)
            {
                yield return bigList.GetRange(i, Math.Min(nSize, bigList.Count - i)).ToList();
            }
        }

        public IEnumerable<List<ICard>> PrepareListsOfCards(List<ICard> bigCardList,int players)
        {
            int cardCount = bigCardList.Count();
            int dividedNumber = cardCount / players;
            int remainder = bigCardList.Count() - dividedNumber * players;
            int highestNumber = dividedNumber + remainder;
            IEnumerable<List<ICard>> lists = SplitList(bigCardList, highestNumber);
            return lists;
        }

        public void DealCardsToPlayers(List<ICard> cardLists, Player[] players)
        {
            var IELists = PrepareListsOfCards(cardLists, players.Length);
            int i = 0;
            foreach (var VARIABLE in IELists)
            {
                players.ElementAt(i).Hand = VARIABLE;
                i++;
            }
        }
        public List<ICard> ShuffleCards(List<ICard> deck)
        {
            var shuffledcards = deck.OrderBy(a => Guid.NewGuid()).ToList();
            return shuffledcards;
        }

        public List<ICard> MakePair(Player player)
        {
            List<NumberCard> numberCards = new List<NumberCard>();
            List<PictureCard> pictureCards = new List<PictureCard>();
            foreach (var VARIABLE in player.Hand)
            {
                if (VARIABLE.GetType().Name == "NumberCard")
                {
                    numberCards.Add(((NumberCard)VARIABLE));
                }
                else
                {
                    pictureCards.Add(((PictureCard)VARIABLE));
                }
            }
            var query = numberCards.GroupBy(x => x.Number)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            var query2 = pictureCards.GroupBy(x => x.Picture)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            return player.Hand;
        }

    }
}
