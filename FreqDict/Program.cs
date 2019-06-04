using System;
using System.Collections.Generic;
using System.IO;
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
            FileStream stream = new FileStream(@"C:\Users\setup\Documents\test1results.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream, Encoding.Default);
            int n = 1;

            foreach (string word in result.Keys)
            {
                //Console.WriteLine(word + " " + result[word]);
                writer.WriteLine(n++ + " " + word + " " + result[word]);
            }

            writer.Close();
            stream.Close();
        }
    }
}
