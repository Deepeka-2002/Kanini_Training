using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnect
{
    internal class DB1
    {
        /*
        public  void CreateTable()
        {
           
            SqlCommand cmd = new SqlCommand("create table stud_details(rno int, name nvarchar(20))", conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created");
            
        }
        public void  InsertTable()
        {
            SqlCommand cmd = new SqlCommand("insert into stud_details values(12,'Deepi')", conn);

            if (conn != null)
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Row inserted");
            }
        }

        public void UpdateTable()
        {
            SqlCommand cmd = new SqlCommand("update stud_details set rno=1  where name='Deepi'",conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Row updated");
        }
        public void DeleteTable()
        {
            SqlCommand cmd = new SqlCommand("Delete stud_details ", conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Row Deleted");
        }*/
        /* public void ReadTable()
         {
             SqlCommand cmd = new SqlCommand("Select * from menu", conn);
             SqlDataReader sdr;
             if (conn != null)
             {

                 sdr = cmd.ExecuteReader();
                 if (!sdr.HasRows)
                 {
                     Console.WriteLine("Table is empty");
                 }
                 while (sdr.Read())
                 {
                     Console.WriteLine(sdr["product_id"] + " " + sdr["product_name"]+ " " + sdr["price"] );
                 }
             }
         }*/

        /*
        public void Points()
        {
            cmd = new SqlCommand(" select s.customer_id,  sum(price*10) from sales s join menu m on  m.product_id = s.product_id group by s.customer_id", conn);
            sdr = cmd.ExecuteReader();
            Console.WriteLine("Qn5 :");
            if(!sdr.HasRows)
            {
                Console.WriteLine("Table is Empty");
            }
            while(sdr.Read())
            {
                Console.WriteLine(sdr["customer_id"] + " " + sdr[1]);
            }
            Console.WriteLine();
            sdr.Close();
        }

        public void TotalItems()
        {
            cmd = new SqlCommand("select s.customer_id, count(s.product_id), sum(m.price) from sales s join menu m on m.product_id = s.product_id join members mem on mem.Customer_id = s.customer_id where s.order_date > mem.join_date group by s.customer_id", conn);
            sdr= cmd.ExecuteReader();
            Console.WriteLine("Qn4 :");
            if (!sdr.HasRows)
            {
                Console.WriteLine("Table is empty");
            }
            while(sdr.Read())
            {
                Console.WriteLine(sdr["customer_id"] + " " + sdr[1] + " " + sdr[2]);
            }
            Console.WriteLine();
            sdr.Close();
        }
        public void MostPurchased()
        {
            cmd = new SqlCommand("select Top 1 m.product_name, count(s.product_id) from menu m join sales s on m.product_id = s.product_id group by m.product_name order by count(s.product_id) desc", conn);
            sdr= cmd.ExecuteReader();
            Console.WriteLine("Qn3 :");
            if (!sdr.HasRows)
            {
                Console.WriteLine("Table is empty");
            }
            while(sdr.Read())
            {
                Console.WriteLine(sdr["product_name"] + " " + sdr[1]);
            }
            Console.WriteLine();
            sdr.Close();
        }
        public void DisplayDetails()
        {
            cmd = new SqlCommand("Select s.customer_id, Sum(m.price) from menu m join sales s on m.product_id = s.product_id group by s.customer_id", conn);
            sdr = cmd.ExecuteReader();
            Console.WriteLine("Qn1 :");
            if (!sdr.HasRows)
                {
                    Console.WriteLine("Table is empty");
                }
                while(sdr.Read())
                {
                    Console.WriteLine(sdr["customer_id"] + " " + sdr[1]); 
                }
            sdr.Close();
            Console.WriteLine();

        }

        public void DaysVisited()
        {
           cmd = new SqlCommand("select customer_id, count(distinct(order_date)) from sales group by customer_id", conn);
                sdr= cmd.ExecuteReader();
            Console.WriteLine("Qn2 :");
            if (!sdr.HasRows)
                {
                    Console.WriteLine("Table is empty");
                }
                else
                {
                    while(sdr.Read())
                    {
                        Console.WriteLine(sdr["customer_id"] + " " + sdr[1]);
                    }
                }
            Console.WriteLine();
            sdr.Close();
        }*/

        /*
        public void AddBook()
        {
            string sql = "INSERT INTO Books (Categoryid,Title, Author, ISBN, Publisher, Edition, Language) " +
                     "VALUES (@Title, @Author, @ISBN, @Publisher, @Edition, @Language)";
            command = new SqlCommand(sql, conn);
            {
                // Add parameter values to the command
       
                command.Parameters.Add(new SqlParameter("@Categoryid", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar,50));
       
                command.Parameters.Add(new SqlParameter("@Author", SqlDbType.NVarChar,20));
                command.Parameters.Add(new SqlParameter("@ISBN", SqlDbType.NVarChar,10));
                command.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.NVarChar,20));
                command.Parameters.Add(new SqlParameter("@Edition", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Language", SqlDbType.NVarChar,30));


                // Execute the command
                command.ExecuteNonQuery();
                Console.WriteLine("Data inserted");
            }
        }
        */

        /*
        public void CloseConn(string connect)
        {
            if (conn != null)
            {
               
                conn.Close();
                Console.WriteLine("Connection Closed");
            }
        }
       */
    }
}
