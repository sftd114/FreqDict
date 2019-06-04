using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FreqDict
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void PathTest()
        {
            FreqClass freq = new FreqClass();
            Dictionary<string, int> result = freq.FreqCount(@"");

            if (result == null)
                Assert.Fail();
        }

        [Test]
        public void ExtensionTest()
        {
            FreqClass freq = new FreqClass();
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\Hydrangeas.jpg");

            if (result == null)
                Assert.Fail();
        }

        [Test]
        public void WordCountTest()
        {
            FreqClass freq = new FreqClass();
            Dictionary<string, int> result = freq.FreqCount(@"C:\Users\setup\Documents\test1.txt");

            if (result.Count != 542)
                Assert.Fail();
        }

        [Test]
        public void FreqTest()
        {
            FreqClass freq = new FreqClass();
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
    }
}
