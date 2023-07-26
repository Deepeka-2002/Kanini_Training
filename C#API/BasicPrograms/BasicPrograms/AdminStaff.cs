/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class AdminStaff : College
    {
        private int aeid;
        private string aname;
        private double asalary;

        public AdminStaff(string collegename, string address, int pin, int aeid, string aname, double asalary) : base(collegename, address, pin)
        {
            this.Aeid = aeid;
            this.Aname = aname;
            this.Asalary = asalary;
        }

        public int Aeid { get => aeid; set => aeid = value; }
        public string Aname { get => aname; set => aname = value; }
        public double Asalary { get => asalary; set => asalary = value; }

        public double calculatesalary()
        {
            double da = 0.3;
            double hra = 0.15;
            double allowances = salary + (salary * da) + (salary * hra);
            double pf = 0.20;
            double deductions = salary * pf;
            double netsal = salary + allowances - deductions;
            return netsal;
        }
    }
}
*/