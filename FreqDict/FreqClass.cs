using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FreqDict
{
    class FreqClass
    {
        public Dictionary<string, int> FreqCount(string path)
        {
            Dictionary<string, int> dict = null;

            if (!File.Exists(path) || (!Path.GetExtension(path).EndsWith("txt") && !Path.GetExtension(path).EndsWith("doc")
                && !Path.GetExtension(path).EndsWith("docx") && !Path.GetExtension(path).EndsWith("rtf")))
<<<<<<< HEAD
=======
            {
>>>>>>> master
                return dict;

            dict = new Dictionary<string, int>();

            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream, Encoding.Default);

            string text = reader.ReadToEnd();

            reader.Close();
            stream.Close();

            MatchCollection matches = Regex.Matches(text, "[A-Z|a-z]+");

            foreach (Match match in matches)
            {
                if (!dict.ContainsKey(match.Value))
                    dict.Add(match.Value, 1);
                else
                    dict[match.Value]++;
            }

            return dict;
        }
    }
}
