using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class ShortestTimeTests
    {
        private static Random rnd = new Random();

        [TestCase(5, 6, new int[] { 1, 2, 3, 10 }, ExpectedResult = 12)]
        [TestCase(1, 6, new int[] { 1, 2, 3, 10 }, ExpectedResult = 0)]
        [TestCase(5, 5, new int[] { 1, 2, 3, 10 }, ExpectedResult = 11)]
        [TestCase(2, 2, new int[] { 1, 2, 3, 10 }, ExpectedResult = 8)]
        [TestCase(2, 2, new int[] { 2, 3, 4, 10 }, ExpectedResult = 10)]
        [TestCase(5, 4, new int[] { 1, 2, 3, 10 }, ExpectedResult = 12)]
        [TestCase(5, 4, new int[] { 2, 3, 4, 5 }, ExpectedResult = 20)]
        public int Sample_Cases(int n, int m, int[] speeds) => Kata.ShortestTime(n, m, speeds);

        [Test]
        public void RandomTests()
        {
            var arrs = GenerateRandomCases();
            foreach(var arr in arrs)
            {
                var n = arr[0];
                var m = arr[1];
                var speeds = new int[] { arr[2], arr[3], arr[4], arr[5] };
                var el = Math.Abs(m - n) * speeds[0] + speeds[1] * 2 + speeds[2] + (n - 1) * speeds[0];
                var w = (n - 1) * speeds[3];
                var actual = Kata.ShortestTime(n, m, speeds);
                var expected = Math.Min(w, el);
                Assert.That(actual, Is.EqualTo(expected), $"n = {n}, m = {m}, speeds: {string.Join(" ,", speeds.Select(x => x))}");
            }
        }

        private int[][] GenerateRandomCases()
        {
            int[][] arr = new int[100][];
            for(int i = 0; i < 100; i++)
            {
                int[] inj = new int[6];
                inj[0] = rnd.Next(1, 11);
                inj[1] = rnd.Next(1, 11);
                inj[2] = rnd.Next(1, 11);
                inj[3] = rnd.Next(1, 11);
                inj[4] = rnd.Next(1, 11);
                inj[5] = rnd.Next(1, 40);
                arr[i] = inj;
            }
            return arr;
        }
    }
}
