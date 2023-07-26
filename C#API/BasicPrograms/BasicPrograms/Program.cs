using BasicPrograms;
using System.Data.SqlClient;
using System.Linq.Expressions;

class Program
{
    string fileName = @"mytest.txt";
    string[] ArrLines;
    string str;
    int n, i;
    public  static void Main(String[] args)
    {
        
        Console.Write("\n\n Create and write some line of text which does not contain a given string in a line  :\n");
        Console.Write("------------------------------------------------------------------------------------------\n");
        WriteTextFile write = new WriteTextFile();
        write.FileExists();
        Console.Write(" Input the string to ignore the line : ");
        str = Console.ReadLine();
        Console.Write(" Input number of lines to write in the file  : ");
        n = Convert.ToInt32(Console.ReadLine());
        ArrLines = new string[n];
        Console.Write(" Input {0} strings below :\n", n);
        for (int i = 0; i < n; i++)
        {
            Console.Write(" Input line {0} : ", i + 1);
            ArrLines[i] = Console.ReadLine();
        }


        /*public static void Main(string[] args)
        {

            Console.WriteLine("Enter the string: ");
            string inputString = Console.ReadLine();
            RemoveChars removeChars= new RemoveChars();
            string outputString = removeChars.RemoveDuplicateChars(inputString);
            Console.WriteLine(outputString);
        }
        */
        /* public static void Main(string[] args)
         {
             string fromCurrency="", toCurrency="";
             var converter = new CurrencyConverter();

                 while (true)
                 {
                     Console.WriteLine("Choose a conversion type :");
                     Console.WriteLine("1. USD to INR");
                     Console.WriteLine("2. INR to USD");
                     Console.WriteLine("3. USD to EUR");
                     Console.WriteLine("4. EUR to USD");
                     Console.WriteLine("5. INR to EUR");
                     Console.WriteLine("6. EUR to INR");
                     Console.WriteLine("0. Exit");

                     int choice = int.Parse(Console.ReadLine());

                     if (choice == 0)
                     {
                         break;
                     }

                     Console.WriteLine("Enter amount: ");
                     double amount = double.Parse(Console.ReadLine());


                     switch (choice)
                     {
                         case 1:
                         fromCurrency = "USD";
                         toCurrency = "INR";
                         break;
                         case 2: fromCurrency = "INR";
                         toCurrency = "USD";
                         break;
                         case 3: fromCurrency = "USD";
                         toCurrency = "EUR";
                         break;
                         case 4: fromCurrency = "EUR";
                         toCurrency = "USD";
                         break;
                         case 5: fromCurrency = "INR"; 
                         toCurrency = "EUR"; 
                         break;
                         case 6: fromCurrency = "EUR"; 
                         toCurrency = "INR"; 
                         break;
                         default:
                         Console.WriteLine("Invalid choice");
                         break;
                     }

                     double result = converter.Convert(fromCurrency, toCurrency, amount);

                     Console.WriteLine($"{amount} {fromCurrency} = {result} {toCurrency}");
                     Console.WriteLine();
                 }
             }*/
    }
