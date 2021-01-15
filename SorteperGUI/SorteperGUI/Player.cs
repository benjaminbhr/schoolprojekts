using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class Player
    {
        public string Name { get; set; }
        public List<ICard> Hand { get; set; }

        public event EventHandler PlayerHandChanged;
        public event EventHandler DrewCards;


        public Player(List<ICard> hand,string name)
        {
            this.Hand = hand;
            this.Name = name;
        }

        public virtual void MakePair(List<ICard> selectedItems)
        {
            var tempList = Hand;
            List<NumberCard> tempNumber = new List<NumberCard>();
            List<PictureCard> tempPicture = new List<PictureCard>();
            foreach (var item in selectedItems)
            {
                if (item.GetType().Name == "NumberCard")
                {
                    tempNumber.Add(((NumberCard)item));
                }
                else
                {
                    tempPicture.Add(((PictureCard)item));
                }
            }
            if (tempNumber.Count == 2)
            {
                if (tempNumber[0].Number == tempNumber[1].Number)
                {
                    tempList.Remove(tempNumber[0]);
                    tempList.Remove(tempNumber[1]);
                }
            }
            else if (tempPicture.Count == 2)
            {
                string pictureCard0 = tempPicture[0].Picture + " of " + tempPicture[0].Suite;
                string pictureCard1 = tempPicture[0].Picture + " of " + tempPicture[0].Suite;
                if (tempPicture[0].Picture == tempPicture[1].Picture && pictureCard0 != "Jack of Spades" && pictureCard1 != "Jack of Spades")
                {
                    tempList.Remove(tempPicture[0]);
                    tempList.Remove(tempPicture[1]);
                }
            }
            Hand = tempList;
            PlayerHandChanged?.Invoke(this, new HandEventArgs(Hand));
        }
        public virtual bool MakePair()
        {
            return true;
        }

        public virtual void DrawCard(Player[] players)
        {

        }

        public virtual void DrawCard(List<ICard> selectedItem, Player[] players)
        {
            if (selectedItem.Count > 1)
            {
                return;
            }
            else
            {
                players[1].Hand.Remove(selectedItem[0]);
                players[0].Hand.Add(selectedItem[0]);
                DrewCards?.Invoke(this, new DrawEventArgs(players));
            }
        }

        protected virtual void OnHandChanged(EventArgs e)
        {
            PlayerHandChanged?.Invoke(this, e);
        }

        protected virtual void OnDraw(EventArgs e)
        {
            DrewCards?.Invoke(this, e);
        }
    }
}
