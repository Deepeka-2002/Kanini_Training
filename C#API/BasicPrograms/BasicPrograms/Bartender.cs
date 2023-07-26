using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Bartender
    {
        private int age;
        private bool breaktime;

        public int Age { get => age; set => age = value; }
        public bool Breaktime { get => breaktime; set => breaktime = value; }

        public bool ShouldServeDrinks(int age, bool breaktime)
        {
            if ((age >= 18) && (breaktime == false))
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
