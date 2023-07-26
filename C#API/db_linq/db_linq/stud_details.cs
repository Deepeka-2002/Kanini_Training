using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace db_linq
{
    internal class Stud_details
    {
        DBClsDataContext dBcontext = new DBClsDataContext();
        public void Readstud_details()
        {
            //DBClsDataContext dBcontext = new DBClsDataContext();
             /*var res = from st in dBcontext.stud_details
                      where st.rno >= 4
                      select st;
            */
            var res = dBcontext.stud_details.Where(st => st.rno > 3);

            foreach (var r in res)
            {
                Console.WriteLine(r.rno + " " + r.name);
            }
        }

        public void Countmin_max() 
        {
            var count = (from st in dBcontext.stud_details
                        select st).Count();
            Console.WriteLine("Rows : " + count);

           
            var max =  (from st in dBcontext.stud_details
                       select st.rno).Max();
            Console.WriteLine("Max: " +max);

            int min = (int)dBcontext.stud_details.Min(st => st.rno);
            Console.WriteLine("Min : " + min);
        }
       
    }
}
