using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnect
{
    internal class ChooseCategory
    {
        public void ChooseCat() 
        {

            // Categories of books
            Console.WriteLine("Choose category of your book");
            Console.WriteLine("1 for Fiction");
            Console.WriteLine("2 for Non-fiction");
            Console.WriteLine("3 for Science");
            Console.WriteLine("4 for History");
            Console.WriteLine("5 for Biography");

        }

    }
}
