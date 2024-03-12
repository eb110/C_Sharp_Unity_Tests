using NUnit.Framework;
using System.Collections.Generic;

namespace CodeWars.Tests
{
    [TestFixture]
    public class PossiblyPerfectTests
    {
        private static Random rnd = new Random();

        [TestCase("A_C_B", "ADCEB", ExpectedResult = true)]
        [TestCase("B_B", "BDC", ExpectedResult = false)]
        [TestCase("T_FFF", "FFTTT", ExpectedResult = true)]
        [TestCase("BA__", "BACC", ExpectedResult = true)]
        [TestCase("ABA_", "BACC", ExpectedResult = true)]
        [TestCase("ABC_", "BACC", ExpectedResult = false)]
        [TestCase("B_", "CA", ExpectedResult = true)]
        [TestCase("BA", "CA", ExpectedResult = false)]
        [TestCase("B", "B", ExpectedResult = true)]
        [TestCase("_T__", "TFFF", ExpectedResult = true)]
        [TestCase("_T__", "TTFT", ExpectedResult = true)]
        [TestCase("_TTT", "TTFT", ExpectedResult = false)]
        [TestCase("_TTT", "TTTT", ExpectedResult = true)]
        [TestCase("_TTT", "FFFF", ExpectedResult = true)]
        [TestCase("____", "FFFF", ExpectedResult = true)]
        public bool Sample_Cases(string key, string ans) =>
            Kata.PossiblyPerfect(key.ToCharArray().Select(x => "" + x).ToArray(), 
                ans.ToCharArray().Select(x => "" + x).ToArray());

        [Test]
        public void RandomTests()
        {
            var keys = GenerateKeys();
            var answers = GenerateRandomAnswers(keys);
            for(int i = 0; i < keys.Length; i++)
            {
                var key = keys[i].ToCharArray().Select(x => "" + x).ToArray();
                var ans = answers[i].ToCharArray().Select(x => "" + x).ToArray();
                var actual = Kata.PossiblyPerfect(key, ans);
                var expected = GenerateSolution(key, ans);
                Assert.That(actual, Is.EqualTo(expected), 
                    "Key => " + String.Join(", ", key.Select(x => x)) +
                    "\nAns => " + String.Join(", ", ans.Select(x => x)));
            }
        }

        private bool GenerateSolution(string[] key, string[] ans)
        {
            int check = ans.Where((x, i) => x != "_" && x == key[i]).Count();
            return check == 0 || check == key.Where(x => x != "_").Count();
        }

        private string[] GenerateKeys()
        {
            List<string> keys = new List<string>();
            for (int j = 0; j < 30; j++)
            {
                int l = rnd.Next(0, 12);
                string temp = "";
                for (int i = 0; i < l; i++)
                {
                    var letter = rnd.Next(0, 2) == 0 ? '_' : (char)rnd.Next(65, 91);
                    temp += letter;
                }
                keys.Add(temp);
            }
            return keys.ToArray();
        }

        private string[] GenerateRandomAnswers(string[]keys)
        {
            int l = keys.Length;
            string[] answer = new string[l];
            for(int i = 0; i < l; i++)
            {
                bool swap = rnd.Next(0, 2) == 0 ? true : false;
                string ans = "";
                for(int j = 0; j < keys[i].Length; j++)
                {
                    char letter = keys[i][j];
                    if (letter == '_' || (swap && rnd.Next(0, 2) == 0))
                        ans += (char)rnd.Next(65, 91);
                    else
                        ans += letter;
                }
                answer[i] = ans;
            }
            return answer;
        }
    }
}
