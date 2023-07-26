using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class RemoveChars
    {
        public  string RemoveDuplicateChars(string inputString)
        {
            string result = "";
            foreach (char c in inputString)
            {
                if (!result.Contains(c.ToString()))
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
