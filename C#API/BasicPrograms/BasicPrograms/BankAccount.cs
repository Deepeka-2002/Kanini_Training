/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class BankAccount
    {
        private int custid;
        private string name;
        private long accno;
        private double balance;
        private string status;

        public BankAccount(int custid, string name, long accno, double balance, string status)
        {
            this.Custid = custid;
            this.Name = name;
            this.Accno = accno;
            this.Balance = balance;
            this.Status = status;
        }

        public int Custid { get => custid; set => custid = value; }
        public string Name { get => name; set => name = value; }
        public long Accno { get => accno; set => accno = value; }
        public double Balance { get => balance; set => balance = value; }
        public string Status { get => status; set => status = value; }

        public  void Checkaccstatus(long accno, out int custid, out string name, out double balance, out string status)
        {
            if (custid == Custid)
            {
                accno = Accno;
                name = Name;
                balance = Balance;
                status= Status;
            }
            
        }
        public void Checkaccstatus(long accno)
        {
            if (custid == Custid)
            {
                accno = Accno;
                name = Name;
                balance = Balance;
                status = Status;
            }

        }
    }
}
*/