using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class Ending
    {
        public void AddEnding(string[] words, string addon)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i] + addon;
            }

            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
        }


    }
}
