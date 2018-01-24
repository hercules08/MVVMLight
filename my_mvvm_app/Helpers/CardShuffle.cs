using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_mvvm_app.Model;

namespace my_mvvm_app.Helpers
{
    public class CardShuffle
    {
        static Random rng = new Random();
        static int Shuffles = 0;

        public static List<Cards> Shuffle(List<Cards> footballCards, int numberOfShuffles)
        {
            if(Shuffles < numberOfShuffles)
            {
                int n = footballCards.Count;
                while(n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = footballCards[k];
                    footballCards[k] = footballCards[n];
                    footballCards[n] = value;
                }
                Shuffles++;
                Shuffle(footballCards, numberOfShuffles);
            }

            return footballCards;
        }
    }
}
