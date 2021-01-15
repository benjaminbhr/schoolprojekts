using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteperGUI
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(List<ICard> hand, string name):base (hand,name)
        {
            this.Hand = hand;
            this.Name = name;
        }

        public override bool MakePair()
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                for (int j = 0; j < Hand.Count; j++)
                {
                    if (Hand.ElementAt(i).GetType().Name == "NumberCard" && Hand.ElementAt(j).GetType().Name == "NumberCard")
                    {
                        var numberCardI = ((NumberCard)Hand.ElementAt(i));
                        var numberCardJ = ((NumberCard)Hand.ElementAt(j));
                        if (numberCardI != numberCardJ && numberCardI.Number == numberCardJ.Number)
                        {
                            var tempIObj = Hand.ElementAt(i);
                            var tempJObj = Hand.ElementAt(j);
                            Hand.Remove(tempIObj);
                            Hand.Remove(tempJObj);
                            return true;
                        }
                    }
                    else if (Hand.ElementAt(i).GetType().Name == "PictureCard" && Hand.ElementAt(j).GetType().Name == "PictureCard")
                    {
                        var pictureCardI = ((PictureCard)Hand.ElementAt(i));
                        string pictureCardIString = pictureCardI.Picture + " of " + pictureCardI.Suite;
                        var pictureCardJ = ((PictureCard)Hand.ElementAt(j));
                        string pictureCardJString = pictureCardJ.Picture + " of " + pictureCardJ.Suite;
                        if (pictureCardI != pictureCardJ && pictureCardI.Picture == pictureCardJ.Picture && pictureCardIString != "Jack of Spades" && pictureCardJString != "Jack of Spades")
                        {
                            var tempIObj = Hand.ElementAt(i);
                            var tempJObj = Hand.ElementAt(j);
                            Hand.Remove(tempIObj);
                            Hand.Remove(tempJObj);
                            return true;
                        }
                    }
                }
            }
            OnHandChanged(new HandEventArgs(Hand));
            return false;
        }

        public override void DrawCard(Player[] players)
        {
            Random random = new Random();
            var rnd = random.Next(0, players[0].Hand.Count() - 1);
            Debug.WriteLine(rnd);
            var selectedItem = players[0].Hand.ElementAt(rnd);
            players[0].Hand.Remove(selectedItem);
            players[1].Hand.Add(selectedItem);
            OnDraw(new DrawEventArgs(players));
        }
    }
}
