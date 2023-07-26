/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class TeachingStaff:College
    {
        private int eid;
        private string name, dept, favsub;
        private double salary;

        public  TeachingStaff(string collegename, string dept, int pin,int eid, string name, string addr, string favsub, double salary) : base(collegename, addr, pin)
        {
            this.Eid = eid;
            this.Name = name;
            this.Favsub = favsub;
            this.Salary = salary;
            this.Dept = dept;
        }

        public int Eid { get => eid; set => eid = value; }
        public string Name { get => name; set => name = value; }
        public string Dept { get => dept; set => dept = value; }
        public string Favsub { get => favsub; set => favsub = value; }
        public double Salary { get => salary; set => salary = value; }

        public double calculatesalary()
        {
            double da = 0.4;
            double hra = 0.2;
            double allowances = salary + (salary * da) + (salary* hra);
            double pf = 0.25;
            double deductions =salary * pf;
            double netsal = salary + allowances - deductions;
            return netsal;
        }
    }
}
*/