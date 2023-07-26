using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DBconnect
{
    internal class Borrow :DB
    {
        String sql;
        SqlCommand command;
        SqlParameter param;
        SqlDataReader sdr;   
        object email;

        // Borrowbook from fetched results of books
        public void BorrowBook() 
        {
            
            Console.Write("Enter ISBN No of the book you want to borrow: ");
            string isbn = (Console.ReadLine());

            Console.Write("Enter your mail id: ");
            email = (Console.ReadLine());

            SqlCommand command = new SqlCommand("dbo.BorrowBook", Conn);
            command.CommandType = CommandType.StoredProcedure;

            param = command.Parameters.Add("@ISBN", SqlDbType.NVarChar, 10);
            param.Value = isbn;

            param = command.Parameters.Add("@Email", SqlDbType.NVarChar, 20);
            param.Value = email;

            command.ExecuteNonQuery();
            Console.WriteLine("===============Book was borrowed and it will be accessible for you till the due date===============");

            sql = "select MAX(Borrowid) from Book_borrow_master";
            command = new SqlCommand(sql, Conn);
            sdr = command.ExecuteReader();
            while(sdr.Read())
            {
                Console.WriteLine("Your Borrowid is: " + sdr[0]);
            }
          
        }
    }
}
