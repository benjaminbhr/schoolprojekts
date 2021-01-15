using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class GameManager
    {
        public bool HasDrawn = false;
        public int Turn = 0;
        public string GameSummary = null;

        public Player[] Players = new Player[2];
        public event EventHandler GameFinished;



        public IEnumerable<List<T>> SplitList<T>(List<T> bigList, int nSize)
        {
            for (int i = 0; i < bigList.Count; i += nSize)
            {
                yield return bigList.GetRange(i, Math.Min(nSize, bigList.Count - i)).ToList();
            }
        }

        public IEnumerable<List<ICard>> PrepareListsOfCards(List<ICard> bigCardList, int players)
        {
            int cardCount = bigCardList.Count();
            int dividedNumber = cardCount / players;
            int remainder = bigCardList.Count() - dividedNumber * players;
            int highestNumber = dividedNumber + remainder;
            IEnumerable<List<ICard>> lists = SplitList(bigCardList, highestNumber);
            return lists;
        }

        public void DealCardsToPlayers(List<ICard> cardLists)
        {
            var IELists = PrepareListsOfCards(cardLists, Players.Length);
            int i = 0;
            foreach (var VARIABLE in IELists)
            {
                Players.ElementAt(i).Hand = VARIABLE;
                i++;
            }
        }
        public List<ICard> ShuffleCards(List<ICard> deck)
        {
            var shuffledcards = deck.OrderBy(a => Guid.NewGuid()).ToList();
            return shuffledcards;
        }

        public void EndTurn()
        {
            if (Turn == 0 && HasDrawn)
            {
                Turn = 1;
                bool temp = true;
                IsGameFinished();
                ((ComputerPlayer)Players[1]).DrawCard(Players);
                while (temp)
                {
                    temp = ((ComputerPlayer)Players[1]).MakePair();
                }
                HasDrawn = false;
                Turn = 0;
            }
            else
            {
                Turn = 0;
                IsGameFinished();
            }
        }

        public void IsGameFinished()
        {
            if (Players[0].Hand.Count == 0 && Players[1].Hand.Count == 1)
            {
                GameSummary = $"{Players[0].Name} WON, {Players[1].Name} LOST";
                GameFinished?.Invoke(this, new GameFinishedEventArgs(true));
            }
            else if (Players[1].Hand.Count == 0 && Players[0].Hand.Count == 1)
            {
                GameSummary = $"{Players[0].Name} LOST, {Players[1].Name} WON";
                GameFinished?.Invoke(this, new GameFinishedEventArgs(true));
            }
        }

        public void StartGame()
        {
            CardGenerator generator = new CardGenerator();
            var deck = generator.GenerateDeck();
            List<ICard> shuffleddeck = ShuffleCards(deck);
            DealCardsToPlayers(shuffleddeck);
        }
        public GameManager(Player[] players)
        {
            this.Players = players;
            StartGame();
        }

    }
}
