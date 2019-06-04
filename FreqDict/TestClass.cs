using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FreqDict
{
    [TestFixture]
    class TestClass
    {
        FreqClass freq = new FreqClass();

        [Test]
        public void PathTest()
        {
            Dictionary<string, int> result = freq.FreqCount(@"");

            if (result == null)
                Assert.Fail();
        }

        [Test]
        public void ExtensionTest()
        {
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\Hydrangeas.jpg");

            if (result == null)
                Assert.Fail();
        }

        [Test]
        public void WordCountTest()
        {
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\test1.txt");

            if (result.Count != 542)
                Assert.Fail();
        }

        [Test]
        public void FreqTest()
        {
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\test1.txt");

            FileStream stream = new FileStream(@"C:\Users\setup\Documents\test1results.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            string line = "";
            string[] split = null;

            foreach (string word in result.Keys)
            {
                line = reader.ReadLine();
                split = line.Split(' ');

                if (!word.Equals(line[1]) || result[word] != Convert.ToInt32(line[2]))
                    Assert.Fail();
            }

            reader.Close();
            stream.Close();
        }

        [Test]
        [TestCase(@"C:\Users\setup\Documents\test1.txt")]
        public void AutoTest(string path)
        {
            Dictionary<string, int> result = freq.FreqCount(path);
            Dictionary<string, int> dict = null;

            if (!File.Exists(path) || (!Path.GetExtension(path).EndsWith("txt") && !Path.GetExtension(path).EndsWith("doc")
                && !Path.GetExtension(path).EndsWith("docx") && !Path.GetExtension(path).EndsWith("rtf")))
                Assert.Fail();

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

            foreach (string word in result.Keys)
            {
                if (!dict.ContainsKey(word) || dict[word] != result[word])
                    Assert.Fail();
            }
        }
    }
}
