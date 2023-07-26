using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Box
    {
        private int number;

        public int Number { get => number; set => number = value; }

        public int StackBoxes(int number)
        {
            return number * number;
        }

    }
}
