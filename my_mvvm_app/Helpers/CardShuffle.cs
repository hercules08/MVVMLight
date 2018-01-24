using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_mvvm_app.Model;

namespace my_mvvm_app.Helpers
{
    public static class CardShuffle
    {
        static Random rng = new Random();
        static int Shuffles = 0;
        public static List<Cards> Shuffle(this List<Cards> list, int shuffles)
        {
            if (Shuffles < shuffles)
            {
                int n = list.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = list[k];
                    list[k] = list[n];
                    list[n] = value;
                }
                Shuffles++;
                Shuffle(list, shuffles);
            }
            return list;
        }
    }
}
