using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBconnect
{
    internal class DB
    {
        // Connection to database
        SqlConnection conn;

        public SqlConnection Conn { get => conn; set => conn = value; }

        public void OpenConn(string connect)
        {
            Conn = new SqlConnection(connect);
            try
            { 
                Conn.Open();
               
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Connection not established");
            }
        }

    }
}
