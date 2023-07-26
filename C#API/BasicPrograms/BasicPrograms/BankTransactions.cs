/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{

    public class BankTransactions
    {
        private int custid;
        private long accno;
        private string accname = "", status = "";
        private decimal balance, creditamt, debitamt;

    
        public void ReadCustomerDetails()
        {
            Console.WriteLine("Enter Customer id," + "accno, name, balance");
            custid=Convert.ToInt32(Console.ReadLine());
            accno=Convert.ToInt32(Console.ReadLine());
            accname = Console.ReadLine();
            balance=Convert.ToDecimal(Console.ReadLine());
            status = "InActive";
            creditamt = debitamt = 0;

        }
        public void PerformTransactions()

        {
            Console.WriteLine("1.Credit 2.Debit");
            int ch= Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.Write("Enter Credit Amount: ");
                    creditamt= Convert.ToDecimal(Console.ReadLine());
                    balance += creditamt;
                    status = "Active";
                    break;
                case 2:
                    Console.Write("Enter Debit Amount: ");
                    debitamt= Convert.ToDecimal(Console.ReadLine());   
                    balance -= debitamt;
                    status="Active";
                    break; 
               default:
                    Console.WriteLine("Invalid input");
                    break;

            }

        }
        public void WriteCustomerDetails()
        {
            Console.WriteLine($"Name: {accname} -- Balance: {balance} -- Status: {status}");
        }

        public static void Main(string[] args)
        {
            BankTransactions bankTransactions = new BankTransactions();
            bankTransactions.ReadCustomerDetails();
            bankTransactions.PerformTransactions();
            bankTransactions.WriteCustomerDetails();
        }
        


    }
}
*/