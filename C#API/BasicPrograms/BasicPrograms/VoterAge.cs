using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Person
    {
        private int age;

        public int Age { get => age; set => age = value; }

        public static bool CheckAge(int age)
        {
            if (age < 18 ||age > 120)
            {
                throw new ArithmeticException(" Not Eligible for voting.");
            }
            else
            {
                return true; 
            }

        }

    }
}


