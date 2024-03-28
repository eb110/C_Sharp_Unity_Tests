using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    
    public class CanIPlayTests
    {
        private static Random rnd = new Random();

        [TestCase(12, 10, 14, ExpectedResult = true)]
        [TestCase(12, 13, 14, ExpectedResult = false)]
        [TestCase(15, 12, 15, ExpectedResult = false)]
        [TestCase(23, 22, 1, ExpectedResult = true)]
        public bool Sample_Cases(int n, int s, int e) => Kata.CanIPlay(n, s, e);

        [TestCase(9, 10, 11, ExpectedResult = false)]
        [TestCase(12, 12, 13, ExpectedResult = true)]
        [TestCase(13, 10, 15, ExpectedResult = true)]
        [TestCase(14, 9, 14, ExpectedResult = false)]
        [TestCase(15, 8, 12, ExpectedResult = false)]
        [TestCase(20, 21, 1, ExpectedResult = false)]
        [TestCase(21, 21, 6, ExpectedResult = true)]
        [TestCase(17, 15, 3, ExpectedResult = true)]
        [TestCase(0, 22, 1, ExpectedResult = true)]
        [TestCase(1, 22, 1, ExpectedResult = false)]
        [TestCase(3, 23, 2, ExpectedResult = false)]
        [TestCase(20, 0, 23, ExpectedResult = true)]
        [TestCase(14, 2, 9, ExpectedResult = false)]
        [TestCase(9, 20, 11, ExpectedResult = true)]
        [TestCase(23, 23, 0, ExpectedResult = true)]
        [TestCase(11, 2, 9, ExpectedResult = false)]
        [TestCase(0, 20, 23, ExpectedResult = false)]
        [TestCase(4, 0, 3, ExpectedResult = false)]
        [TestCase(6, 2, 10, ExpectedResult = true)]
        public bool Fixed_Tests(int n, int s, int e) => Kata.CanIPlay(n, s, e);

        [Test]
        public void Random_Tests()
        {
            for(int i = 0; i < 100; i++)
            {
                int now = rnd.Next(0, 25);
                int start = rnd.Next(0, 25);
                int end = (start + rnd.Next(1, 25)) % 24;
                var actual = Kata.CanIPlay(now, start, end);
                var expected = end < start && (now >= start || now < end) || now >= start && now < end;
                Assert.That(actual, Is.EqualTo(expected), $"now = {now}, start = {start}, end = {end}");
            }
        }
    }
}
