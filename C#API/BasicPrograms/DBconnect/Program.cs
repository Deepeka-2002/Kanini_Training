using DBconnect;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor= ConsoleColor.Yellow;
       
        // Connection establishment using stringbuilder
        StringBuilder cnnstr = new StringBuilder("data source= ");
        Console.Write("Enter Data source: ");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append("; Initial Catalog=");
        Console.Write("Enter Database name: ");
        cnnstr.Append(Console.ReadLine());
        cnnstr.Append("; Integrated Security=SSPI;");
        Console.WriteLine(cnnstr);
        Console.WriteLine();

        //Objects creation for different classes
        DB db = new DB();
        ChooseCategory choosecategory = new ChooseCategory();
        Add add = new Add();
        User user = new User();
        Search search = new Search();
        Borrow borrow = new Borrow();
        Giveback giveback = new Giveback();

        // Connection string is passed to different objects in the namespace
        add.OpenConn(cnnstr.ToString());
        user.OpenConn(cnnstr.ToString());
        search.OpenConn(cnnstr.ToString());
        borrow.OpenConn(cnnstr.ToString());
        giveback.OpenConn(cnnstr.ToString());


        // Details which EBOOK includes
        Console.WriteLine("--------------------Ebook Management--------------------");
        Console.WriteLine("1. Add your book(Author preference)");
        Console.WriteLine("2. User Details");
        Console.WriteLine("3. Search book to borrow");
        Console.WriteLine("4. Return Book");
        Console.WriteLine();

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        switch (choice)
        {

            case 1: // Adding books

                choosecategory.ChooseCat();
                Console.WriteLine("Books will be added according to this category");
                Console.WriteLine("--------------------Add your book------------------");
                add.AddBook();
                break;

            case 2: // Entering user details

                Console.WriteLine("-------------------User details---------------------");
                user.UserDetails();
                break;

            case 3: //Search books and borrow

                Console.WriteLine("-------------------Search Book----------------------");
                search.SearchBook();
                Console.Write("Do you want to borrow book?(Yes or No): ");
                string val = Convert.ToString(Console.ReadLine());
                if (val == "Yes")
                {
                    borrow.BorrowBook();
                }
                break;

            case 4: // Return the borrowed book

                Console.WriteLine("-------------------Return Book-----------------------");
                giveback.ReturnBook();
                break;

            default:

                Console.WriteLine("Enter valid input");
                break;

        }
    }
}

    /*
    public static void Main(string[] args)
    {
        DB db = new DB();
        db.OpenConn();
       db.DisplayDetails();
        db.DaysVisited();
        db.MostPurchased();
        db.TotalItems();
        db.Points();

        db.CloseConn();
    }
    */
