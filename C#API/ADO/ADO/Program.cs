
using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace ADO
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // set up connection string
            string connectionString = "Data Source=LENOVO-DEEPI\\SQLEXPRESS01 ;Initial Catalog = sample ;Integrated Security=True";
            // create connection and data adapter objects
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection opened");

            
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Books", connection);

            // create dataset and fill it with data
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Books");

            // display all books in the dataset
            Console.WriteLine("All Books:");
            foreach (DataRow row in dataSet.Tables["Books"].Rows)
            {
                Console.WriteLine("{0}. {1} by {2} (${3})", row["BookId"], row["Title"], row["AuthorId"], row["Price"]);
            }

            // add a new book to the dataset
            Console.WriteLine("enter book details:");
            DataRow newBook = dataSet.Tables["Books"].NewRow();
            newBook["BookId"] = Console.ReadLine();
            newBook["Title"] = Console.ReadLine();
            newBook["AuthorId"] = Console.ReadLine();
            newBook["Price"] = Console.ReadLine() ; 
            dataSet.Tables["Books"].Rows.Add(newBook);

            // update the database with the changes in the dataset
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet, "Books");

            // display all books in the dataset again
            Console.WriteLine("All Books after adding a new book:");
            foreach (DataRow row in dataSet.Tables["Books"].Rows)
            {
                Console.WriteLine("{0}. {1} by {2} (${3})", row["BookId"], row["Title"], row["AuthorId"], row["Price"]);
            }

            // wait for user input
            Console.ReadLine();

            connection.Close();
        }
    }
}
*/

    class Program
    {
        static string connectionString = "Data Source=LENOVO\\SQLEXPRESS01 ;Initial Catalog=sample; Integrated Security= SSPI";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the online bookstore!");

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. View Books");
                Console.WriteLine("2. Add Book to Cart");
                Console.WriteLine("3. Exit");
                

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewBooks();
                        break;
                    case "2":
                        AddToCart();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for shopping with us!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ViewBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["BookId"]}: {reader["Title"]} by {reader["AuthorId"]} - ${reader["Price"]}");
                }

                reader.Close();
            }
        }

        static void AddToCart()
        {
            Console.WriteLine("Enter the ID of the book you would like to add to your cart:");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books WHERE BookId = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string title = reader["Title"].ToString();
                    decimal price = decimal.Parse(reader["Price"].ToString());
                    reader.Close();

                    query = "INSERT INTO Cart (BookId, Title, Price) VALUES (@BookId, @Title, @Price)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookId", id);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Book added to cart.");
                    }
                    else
                    {
                        Console.WriteLine("Error adding book to cart.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
    }
}
    