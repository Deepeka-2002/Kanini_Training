using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace db_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stud_details stud = new Stud_details();
            stud.Readstud_details();
            stud.Countmin_max();
            Console.ReadLine();
        }
    }
}
