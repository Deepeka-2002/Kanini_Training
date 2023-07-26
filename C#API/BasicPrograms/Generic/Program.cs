using System.Security.Cryptography;
using Generic;

public delegate void MyDelegate(string msg);
class Program
{

    public static void Main(string[] args)
    {
        MyDelegate myDelegate;
        myDelegate= (DelegateUse.Method1);
        myDelegate("Hello");

        myDelegate = (DelegateUse1.Method2);
        myDelegate("Hiiii");

    }

    //static ArithmeticException arithmeticException;
    /*
    static void Swap<T>(ref T num1, ref T num2)
    {
        T temp;
        temp = num1;
        num1 = num2;
        num2 = temp;
    }
    public static void Main(string[] args)
    {
        int num1 =10, num2 =20;
        char c1 = 'A', c2 = 'B';

        Swap<char>(ref c1, ref c2);
        Swap<int>(ref num1, ref num2);

        Console.WriteLine("a={0} , b={1}", num1, num2);
        Console.WriteLine("c={0}, d={1}",c1,c2 );
        */


       // GenericUsage<ArithmeticException> ae = new GenericUsage<ArithmeticException>(arithmeticException);
        /*
        GenericUsage<int> intarr = new GenericUsage<int>(5);

        for(int i=0; i<5; i++) 
        {
            intarr.setarr(i, ((i + 1) * 10));
        }

        for(int i=0; i<5; i++) 
        {
            Console.WriteLine(intarr.getarr(i));
        }

        GenericUsage<char> chararr= new GenericUsage<char>(5);
        for(int i=0; i<5; i++)
        {
            chararr.setarr(i, Convert.ToChar(i+65));
        }
        for(int i=0; i<5; i++)
        {
            Console.WriteLine(chararr.getarr(i));
        }*/

        /*
        GenericUsage<int> guint = new GenericUsage<int>(10);
        GenericUsage<double> gudouble = new GenericUsage<double>(10.746785678);
        GenericUsage<string> gustring = new GenericUsage<string>("Hello");

        Console.WriteLine(guint);
        Console.WriteLine(gudouble);
        Console.WriteLine(gustring);
        */
    }

