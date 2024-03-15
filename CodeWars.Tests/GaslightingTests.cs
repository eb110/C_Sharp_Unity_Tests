using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CodeWars.Tests
{
    [TestFixture]
    public class GaslightingTests
    {
        private static Random rnd = new Random();

        [TestCase("snack", "snake", new char[] {'c'}, ExpectedResult = true)]
        [TestCase("snack", "snack", new char[] {'s', 'n', 'a', 'c', 'k'}, ExpectedResult = false)]
        [TestCase("snake", "snack", new char[] { 'c' }, ExpectedResult = true)]
        [TestCase("ping", "pong", new char[] { 'p', 'n', 'g' }, ExpectedResult = false)]
        [TestCase("ping", "pong", new char[] { 'i' }, ExpectedResult = true)]
        public bool Sample_Cases(string s, string y, char[] f) => Kata.Gaslighting(s, y, f);

        [Test]
        public void RandomTests()
        {
            var arrs = GenerateStringsArr();
            foreach(var arr in arrs)
            {
                var actual = Kata.Gaslighting(arr[0], arr[1], arr[2].ToCharArray());
                var expected = arr[0].Where((x, i) => arr[1][i] != x && (arr[2].Contains(x) || arr[2].Contains(arr[1][i]))).Count() > 0;
                Assert.That(actual, Is.EqualTo(expected), $"shirt: {arr[0]}, yours: {arr[1]}, friend: {arr[2]}");
            }
        }
        
        private string[][] GenerateStringsArr()
        {
            string[][] arr = new string[100][];
            for (int i = 0; i < 100; i++)
            {
                int l = rnd.Next(1, 50);
                arr[i] = new string[3];
                HashSet<char> chars = new HashSet<char>();
                for (int j = 0; j < l; j++)
                {
                    char lt = (char)rnd.Next(97, 123);
                    arr[i][0] += lt;
                    arr[i][1] += rnd.Next(0, 2) == 0 ? lt : (char)rnd.Next(97, 123);
                    if (arr[i][0][j] != arr[i][1][j])
                    {
                        chars.Add(arr[i][0][j]);
                        chars.Add(arr[i][1][j]);
                    }
                }

                l = rnd.Next(1, l + 1);
                bool isGasl = rnd.Next(0, 2) == 0;
                arr[i][2] = "";
                for (int j = 0; j < l; j++)
                {
                    if (isGasl && rnd.Next(0, 2) == 0 && chars.Count != 0)
                    {
                        char lt = chars.First();
                        chars.Remove(lt);
                        arr[i][2] += arr[i][2].Contains(lt) ? "" : lt;
                    }
                    else
                    {
                        var lt = (char)rnd.Next(97, 123);
                        if (!chars.Contains(lt))
                            arr[i][2] += arr[i][2].Contains(lt) ? "" : lt;
                    }
                }
            }
            return arr;
        }
    }

}