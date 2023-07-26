using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBconnect
{
    internal class Giveback :DB
    {
        SqlCommand command;
        SqlParameter param;

        // Return the borrowed book
        public void ReturnBook() 
        {
            Console.Write("Enter your borrowid: ");
            int bid =Convert.ToInt32( Console.ReadLine());

            SqlCommand command = new SqlCommand("dbo.ReturnBook", Conn);
            command.CommandType = CommandType.StoredProcedure;

            param = command.Parameters.Add("@Borrowid", SqlDbType.Int);
            param.Value = bid;

            command.ExecuteNonQuery();
            Console.WriteLine("==================Book returned====================");
            Console.WriteLine();
        }
    }
}
