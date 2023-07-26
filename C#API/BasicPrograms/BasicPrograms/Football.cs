using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Football
    {
        private int wins;
        private int draws;
        private int losses;

        public int Wins { get => wins; set => wins = value; }
        public int Draws { get => draws; set => draws = value; }
        public int Losses { get => losses; set => losses = value; }

        public int FootballPoints(int wins, int draws, int losses)
        {
            int result = (wins * 3) + (draws * 1) + (losses * 0);
            return result;
        }
    }
}

