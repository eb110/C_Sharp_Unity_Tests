using NUnit.Framework;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeWars.Tests
{
    [TestFixture]
    public class DidWeWinTests
    {
        private static Random rnd = new Random();

        [TestCase(new string[] { "8:pass", "5:sack", "3:sack", "5:run" }, false)]
        [TestCase(new string[] { "12:pass", "", "", "" }, true)]
        [TestCase(new string[] { "2:run", "5:pass", "3:sack", "8:pass" }, true)]
        [TestCase(new string[] { "5:pass", "6:turnover", "", "" }, false)]
        public void SampleTests(string[] arr, bool expected)
        {
            object[][] eles = new object[arr.Length][];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length == 0) eles[i] = new object[0];
                else
                {
                    var wsad = arr[i].Split(':');
                    eles[i] = new object[] { int.Parse(wsad[0]), wsad[1] };
                }
            }
            var actual = Kata.DidWeWin(eles);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(new string[] { "5:pass", "5:pass", "10:sack", "10:run" }, false)]
        [TestCase(new string[] { "5:pass", "5:run", "1:run", "" }, true)]
        [TestCase(new string[] { "6:run", "7:sack", "10:sack", "23:pass" }, true)]
        [TestCase(new string[] { "10:turnover", "", "", "" }, false)]
        [TestCase(new string[] { "8:sack", "5:sack", "6:sack", "30:run" }, true)]
        [TestCase(new string[] { "3:run", "3:run", "3:run", "10:turnover" }, false)]
        [TestCase(new string[] { "16:pass", "", "", "" }, true)]
        [TestCase(new string[] { "13:run", "", "", "" }, true)]
        [TestCase(new string[] { "4:pass", "5:run", "1:run", "1:run" }, true)]
        [TestCase(new string[] { "20:sack", "10:run", "10:sack", "35:run" }, true)]
        [TestCase(new string[] { "10:run", "10:sack", "10:pass", "1:sack" }, false)]
        [TestCase(new string[] { "8:pass", "3:pass", "", "" }, true)]
        [TestCase(new string[] { "3:pass", "5:pass", "8:turnover", "" }, false)]
        [TestCase(new string[] { "2:run", "2:pass", "2:run", "2:pass" }, false)]
        [TestCase(new string[] { "1:pass", "6:pass", "8:pass", "" }, true)]
        [TestCase(new string[] { "9:run", "1:run", "3:turnover", "" }, false)]
        public void FixedTests(string[] arr, bool expected) => SampleTests(arr, expected);

        [Test]
        public void RandomTests()
        {
            var arrs = GenerateRandomArray();
            foreach (var arr in arrs) 
            {
                var actual = Kata.DidWeWin(arr);
                var expected = arr.Aggregate(0, (sum, x) => x.Length == 0 ? sum + 0 : "passrun".Contains((string)x[1]) ? 
                sum + (int)x[0] : ((string)x[1]).Equals("turnover") ? Math.Abs(sum) * -1 : sum - (int)x[0]) > 10;
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private object[][][] GenerateRandomArray()
        {
            var opt = new string[] { "pass", "run","pass", "run", "pass", "run", "sack", "turnover" };
            var res = new object[100][][];
            for(int i = 0; i < 100; i++)
            {
                int l = rnd.Next(1, 20);
                res[i] = new object[l][];
                res[i] = res[i].Select(x => new object[0]).ToArray();
                int counter = 0;
                for (int j = 0; j < l; j++)
                {              
                    var ele = rnd.Next(0, opt.Length);
                    var amount = ele < opt.Length - 2 ? rnd.Next(1, 11) : rnd.Next(1, 40);
                    res[i][j] = new object[] { amount, opt[ele] };
                    counter += ele < opt.Length - 2 ? amount : amount * -1;
                    if (counter > 10 || ele == opt.Length - 1)
                        break;
                }
            }
            return res;
        }
    }
}
