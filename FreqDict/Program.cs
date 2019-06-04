using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreqDict
{
    class Program
    {
        static void Main(string[] args)
        {
            FreqClass freq = new FreqClass();
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\test1.txt");

            foreach (string word in result.Keys)
            {
                Console.WriteLine(word + " " + result[word]);
            }
        }
    }
}
