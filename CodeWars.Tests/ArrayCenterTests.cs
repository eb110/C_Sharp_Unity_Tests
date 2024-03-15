using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class ArrayCenterTests
    {
        private static Random rnd = new Random();

        [TestCase(new int[] { 8, 3, 4, 5, 2, 8 }, ExpectedResult = new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 1 })]
        [TestCase(new int[] { 10, 11, 12, 13, 14 }, ExpectedResult = new int[] { 10, 11, 12, 13, 14 })]
        public int[] SampleTests(int[] arr) => Kata.ArrayCenter(arr);

        [Test]
        public void RandomTests()
        {
            int[][] arrs = GenerateRandomArrarys();
            foreach (int[] arr in arrs)
            {
                var actual = Kata.ArrayCenter(arr.Select(x => x).ToArray());
                var expected = GenerateSolution(arr);
                Assert.That(actual, Is.EqualTo(expected), $"arr: [[{String.Join(", ", arr.Select(x => x))}]");
            }
        }

        private int[] GenerateSolution(int[] arr)
        {
            var avg = arr.Average();
            var min = arr.Min();
            return arr.Where(x => Math.Abs(x - avg) < min).ToArray();
        }

        private int[][] GenerateRandomArrarys()
        {
            int[][] arrs = new int[100][];
            for(int i = 0; i < 100; i++)
            {
                int l = rnd.Next(2, 50);
                arrs[i] = new int[l];
                for (int j = 0; j < l; j++) arrs[i][j] = rnd.Next(1, 351);
            }
            return arrs;
        }
    }
}
