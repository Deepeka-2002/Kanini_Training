/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class ExcepHandling
    {
        int n1, n2, ans;

        public ExcepHandling(int n1, int n2, int ans)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.ans = ans;
        }

        public int add()
        {
            this.ans = this.n1 + this.n2;
            return this.ans;
        }
        public int mul()
        {
            this.ans = this.n1 * this.n2;
            return this.ans;
        }
        public int div()
        {
            try
            {
                this.ans = this.n1 / this.n2;

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Don't give zero as denominator");

            }
            return this.ans;
        }
    }
}
*/