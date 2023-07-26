using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class VoterCheck
    {
        public static  List<People> where(People[] people, EligiblityCheck del )
        {
            List<People> voters = new List<People>();
            foreach (People person in people)
            {
                if (del(person))
                {
                    voters.Add(person);
                }

            }
            return voters;
        }
    }
}
