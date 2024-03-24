using NUnit.Framework;
using System.Net.WebSockets;

namespace CodeWars.Tests
{
    [TestFixture]
    public class BulbMazeTests
    {
        private static Random rnd = new Random();

        [TestCase("xo oxox", ExpectedResult = true)]
        [TestCase("xo  oxox", ExpectedResult = false)]
        [TestCase("xo ox xo", ExpectedResult = true)]
        [TestCase("xooxxo", ExpectedResult = false)]
        [TestCase("xxxxxx", ExpectedResult = false)]
        [TestCase("oooooo", ExpectedResult = false)]
        [TestCase("      ", ExpectedResult = true)]
        [TestCase(" ox", ExpectedResult = true)]
        [TestCase("xo", ExpectedResult = true)]
        [TestCase("x", ExpectedResult = true)]
        [TestCase("o", ExpectedResult = false)]
        public bool Sample_Cases(string s) => Kata.BulbMaze(s);

        [Test]
        public void Random_Cases()
        {
            var arr = GenerateStrings();
            foreach(var s in arr)
            {
                var actual = Kata.BulbMaze(s);
                var expected = s.Where((x, i) => i % 2 == 0 && x == 'o' || i % 2 != 0 && x == 'x').Count() == 0;
                Assert.That(actual, Is.EqualTo(expected), $"maze = {s}");
            }
        }

        private string[] GenerateStrings()
        {
            string[] arr = new string[100];
            for (int i = 0; i < 100; i++)
            {
                var type = rnd.Next(0, 2) == 0 ? true : false;
                var l = rnd.Next(1, 20);
                for(int j = 0; j < l; j++)
                {
                    var lt = "";
                    if(type)
                    {
                        var ltType = rnd.Next(0, 2) == 0 ? true : false;
                        lt = ltType && i % 2 == 0 ? "x" : ltType ? "o" : " ";
                    }
                    else
                    {
                        var ltType = rnd.Next(0, 3);
                        lt = ltType == 0 ? "x" : ltType == 1 ? "o" : " ";
                    }
                    arr[i] += lt;
                }
            }
            return arr;
        }
    }


}
