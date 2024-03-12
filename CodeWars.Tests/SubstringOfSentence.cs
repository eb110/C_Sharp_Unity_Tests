using CodeWars;
using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class SubstringOfSentence
    {
        private static Random rnd = new Random();

        [TestCase("J-J", ExpectedResult = "J")]
        [TestCase("Z-Z", ExpectedResult = "Z")]
        [TestCase("a-a", ExpectedResult = "a")]
        public string Single_Letters_Range(string sp) => KataOld.GimmeTheLetters(sp);      

        [TestCase("a-b", ExpectedResult = "ab")]
        [TestCase("y-z", ExpectedResult = "yz")]
        [TestCase("H-I", ExpectedResult = "HI")]
        public string Two_Letters_Range(string sp) => KataOld.GimmeTheLetters(sp);

        [TestCase("Q-Z", ExpectedResult = "QRSTUVWXYZ")]
        [TestCase("F-O", ExpectedResult = "FGHIJKLMNO")]
        [TestCase("C-R", ExpectedResult = "CDEFGHIJKLMNOPQR")]
        public string Long_Upercase_Ranges(string sp) => KataOld.GimmeTheLetters(sp);

        [TestCase("h-o", ExpectedResult = "hijklmno")]
        [TestCase("e-k", ExpectedResult = "efghijk")]
        [TestCase("a-q", ExpectedResult = "abcdefghijklmnopq")]
        public string Long_lowercase_Ranges(string sp) => KataOld.GimmeTheLetters(sp);

        [TestCase("a-z", ExpectedResult = "abcdefghijklmnopqrstuvwxyz")]
        [TestCase("A-Z", ExpectedResult = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        public string full_Alphabet_Ranges(string sp) => KataOld.GimmeTheLetters(sp);

        [Test]
        public void RandomTest()
        {
            var arr = RandomStringInput();
            foreach(var ele in arr)
            {
                string actual = KataOld.GimmeTheLetters(ele);
                string expected = string.Concat(Enumerable.Range(ele[0], ele[2] - ele[0] + 1).Select(x => (char)x));
                Assert.That(actual, Is.EqualTo(expected), ele);
            }
        }

        private string[] RandomStringInput()
        {
            string[] arr = new string[100];
            int[] letterCase = [65, 97];
            for(int i = 0; i < 100; i++)
            {
                var lCase = rnd.Next(0, 2);
                var start = rnd.Next(letterCase[lCase], letterCase[lCase] + 26);
                var end = rnd.Next(start, letterCase[lCase] + 26);
                arr[i] = $"{(char)start}-{(char)end}";
            }
            return arr;
        }
    }
}
