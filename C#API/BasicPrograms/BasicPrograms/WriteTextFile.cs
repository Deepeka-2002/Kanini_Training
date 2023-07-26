using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class WriteTextFile
    {
        string fileName = @"mytest.txt";
        string[] ArrLines;
        string str;
        int n, i;
        string line;
       
        public string FileName { get => fileName; set => fileName = value; }
        public string[] ArrLines1 { get => ArrLines; set => ArrLines = value; }
        public string Str { get => str; set => str = value; }
        public int N { get => n; set => n = value; }
        public int I { get => i; set => i = value; }

        public void FileExists()
        { 

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
            
            using (System.IO.StreamWriter file =  new System.IO.StreamWriter(@"mytest.txt"))
            {
                foreach (string line in ArrLines)
                {
                    if (!line.Contains(str)) 
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                Console.Write("\n The line has ignored which contain the string '{0}'. \n", str);
                Console.Write("\n The content of the file is  :\n", n);
                Console.Write("----------------------------------\n");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(" {0} ", s);
                }
                Console.WriteLine();
            }
       
    }

}
