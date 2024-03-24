using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CodeWars.Tests
{
    [TestFixture]
    public class Make2dListTests
    {
        private static Random rnd = new Random();

        [Test]
        public void SampleTest_1()
        {
            var b = (BigInteger)1;
            var actual = Kata.Make2dList(b, 2, 3);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b++, b++, b++ }, new List<BigInteger> {b++, b++, b++ } };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_2()
        {
            var b = (BigInteger)2;
            var actual = Kata.Make2dList(b, 3, 4);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b++, b++, b++, b++ },
                new List<BigInteger> {b++, b++, b++, b++ },
               new List<BigInteger> {b++, b++, b++, b++}};
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_3()
        {
            var b = (BigInteger)5;
            var actual = Kata.Make2dList(b, 6, 1);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b++ },
                new List<BigInteger> {b++ },
            new List<BigInteger> {b++ },
            new List<BigInteger> {b++},
            new List<BigInteger> {b++},
            new List<BigInteger> {b++}};
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_4()
        {
            var b = (BigInteger)7;
            var actual = Kata.Make2dList(b, 1, 1);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b} };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_5()
        {
            var b = (BigInteger)0;
            var actual = Kata.Make2dList(b, 1, 0);
            var expected = new List<List<BigInteger>>() { new List<BigInteger>() };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_6()
        {
            var b = (BigInteger)(-20);
            var actual = Kata.Make2dList(b, 2, 2);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b++, b++}, new List<BigInteger> {b++, b++ } };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SampleTest_7()
        {
            var b = (BigInteger)Math.Pow(10, 10);
            var actual = Kata.Make2dList(b, 2, 2);
            var expected = new List<List<BigInteger>>()
            { new List<BigInteger> {b++, b++ }, new List<BigInteger> {b++, b++} };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RandomTests()
        {
            for(int i = 0; i < 20; i++)
            {
                BigInteger b = (BigInteger)Math.Pow(rnd.Next(-10, 11), rnd.Next(0, 21));
                int r = rnd.Next(1, 1001);
                int c = rnd.Next(0, 1001);
                var actual = Kata.Make2dList(b, r, c);
                var expected = GenerateSolution(b, r, c);
                Assert.That(actual, Is.EqualTo(expected), $"head = {b}, row = {r}, col = {c}");
            }
        }

        private List<List<BigInteger>> GenerateSolution(BigInteger b, int r, int c)
        {
            var res = new List<List<BigInteger>>();
            for (int i = 0; i < r; i++)
            {
                res.Add(new List<BigInteger>());
                for (int j = 0; j < c; j++) res[i].Add(b++);
            }
            return res;
        }
    }
}
