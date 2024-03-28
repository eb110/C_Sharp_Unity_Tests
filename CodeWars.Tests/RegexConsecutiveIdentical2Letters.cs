using NUnit.Framework;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeWars.Tests
{
    [TestFixture]
    public class RegexConsecutiveIdentical2Letters
    {
        private static Random rnd = new Random();

        [TestCase("moon", ExpectedResult = true)]
        [TestCase("test", ExpectedResult = false)]
        [TestCase("glasses", ExpectedResult = true)]
        [TestCase("airplane", ExpectedResult = false)]
        [TestCase("free", ExpectedResult = true)]
        [TestCase("branch", ExpectedResult = false)]
        [TestCase("aardvark", ExpectedResult = true)]
        public bool Should_Work_SomeExamples(string s) => Kata.StepThroughWith(s);

        [Test]
        public void RandomTest()
        {
            var arr = RandomStringInput();
            foreach (var ele in arr)
            {
                bool actual = Kata.StepThroughWith(ele);
                bool expected = new Regex(@"(.)\1").IsMatch(ele);
                Assert.That(actual, Is.EqualTo(expected), ele);
            }
        }

        private string[] RandomStringInput()
        {
            string[] arr = new string[100];
            for (int i = 0; i < 100; i++)
            {
                int wordLength = rnd.Next(1, 11);
                var index = rnd.Next(0, 2) == 0 ? rnd.Next(0, wordLength) : -1;
                StringBuilder word = new StringBuilder(wordLength);
                for(int j = 0; j < wordLength; j++)
                {
                    char letter = (char)rnd.Next('a', 'z' + 1);
                    word.Append(letter);
                    if (index == j)
                    {
                        word.Append(letter);
                        j++;
                    }
                }
                arr[i] = word.ToString();
            }
            return arr;
        }
    }
}
