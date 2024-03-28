using NUnit.Framework;
using System.Text.RegularExpressions;

namespace CodeWars.Tests
{
    [TestFixture]
    public class IsItLetterTests
    {
        private static Random rnd = new Random();

        [TestCase('a', ExpectedResult = true)]
        [TestCase('1', ExpectedResult = false)]
        public bool Sample_Cases(char c) => Kata.IsItLetter(c);

        [Test]
        public void Random_Cases()
        {
            for(int i = 0; i < 100; i++)
            {
                char c = (char)rnd.Next(32, 137);
                var actual = Kata.IsItLetter(c);
                var expected = new Regex(@"[a-zA-Z]").IsMatch("" + c);
                Assert.That(actual, Is.EqualTo(expected), $"character => \"{c}\"");
            }
        }
    }
  
}
