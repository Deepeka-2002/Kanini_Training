using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBconnect
{
    internal class Search : DB
    {
        String sql;
        SqlCommand command;
        SqlDataReader sdr;

        // Search using different contexts
        public void SearchBook()
        {
            Console.WriteLine("1. Search using author");
            Console.WriteLine("2. Search using title");
            Console.WriteLine("3. Search using publisher");
            Console.WriteLine("4. Search using Language");
           
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch(choice)
            {
                case 1: // Author search

                    Console.Write("Enter author name to search: ");
                    sql = "Select * from books where Author = @Author";
                    command = new SqlCommand(sql, Conn);
                    command.Parameters.Add(new SqlParameter("@Author", Console.ReadLine()));
                    sdr = command.ExecuteReader();
                    if(!sdr.HasRows)
                    {
                        Console.WriteLine("No search results");
                    }
                    Console.WriteLine() ;
                   Console.WriteLine("Category id     Title                                  Author                 ISBN                 Publisher               Edition         Language ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    while (sdr.Read())
                    {

                        Console.WriteLine(sdr[0] + "               " + sdr[1] + "               " + sdr[2] + "       " + sdr[3] + "        " + sdr[4] + "        " + sdr[5] + "        " + sdr[6]);
                    }
                    break;

                case 2: // Book title search

                    Console.Write("Enter Book title to search: ");
                    sql = "Select * from books where Title = @Title";
                    command = new SqlCommand(sql, Conn);
                    command.Parameters.Add(new SqlParameter("@Title", Console.ReadLine()));
                    sdr= command.ExecuteReader();
                    if (!sdr.HasRows)
                    {
                        Console.WriteLine("No search results");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Category id     Title                                  Author                 ISBN                 Publisher               Edition         Language ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    while (sdr.Read())
                    {
                       
                        Console.WriteLine(sdr[0] + "               " + sdr[1] + "               " + sdr[2] + "       " + sdr[3] + "        " + sdr[4] + "        " + sdr[5] + "        " + sdr[6]);
                    }
                    break;

                case 3: // Publisher search

                    Console.Write("Enter Publisher name to search: ");
                    sql = "Select * from books where Publisher = @Publisher";
                    command = new SqlCommand(sql, Conn);
                    command.Parameters.Add(new SqlParameter("@Publisher", Console.ReadLine()));
                    sdr = command.ExecuteReader();
                    if (!sdr.HasRows)
                    {
                        Console.WriteLine("No search results");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Category id     Title                                  Author                 ISBN                 Publisher               Edition         Language ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    while (sdr.Read())
                    {
                       
                        Console.WriteLine(sdr[0] + "               " + sdr[1] + "               " + sdr[2] + "       " + sdr[3] + "        " + sdr[4] + "        " + sdr[5] + "        " + sdr[6]);
                    }
                    break;

                case 4: //Language search

                    Console.Write("Enter book language to search: ");
                    sql = "Select * from books where Language = @Language";
                    command = new SqlCommand(sql, Conn);
                    command.Parameters.Add(new SqlParameter("@Language", Console.ReadLine()));
                    sdr = command.ExecuteReader();
                    if (!sdr.HasRows)
                    {
                        Console.WriteLine("No search results");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Category id     Title                                  Author                 ISBN                 Publisher               Edition         Language ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
                    while (sdr.Read())
                    {
                        
                        Console.WriteLine(sdr[0] + "               " + sdr[1] + "               " + sdr[2] + "       " + sdr[3] + "        " + sdr[4] + "        " + sdr[5] + "        " + sdr[6]);
                    }
                    break;

                default:

                    Console.WriteLine("Enter valid input");
                    break;

            }
          
        }

    }
}
