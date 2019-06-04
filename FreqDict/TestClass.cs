using System;
using System.Collections.Generic;
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
        }
    }
}
