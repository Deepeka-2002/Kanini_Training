using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Gamble
    {
        private double prob;
        private int prize;
        private int pay;

        public double Prob { get => prob; set => prob = value; }
        public int Prize { get => prize; set => prize = value; }
        public int Pay { get => pay; set => pay = value; }

        public bool ProfitableGamble(double prob, int prize, int pay)
        {
            if (prob * prize > pay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
