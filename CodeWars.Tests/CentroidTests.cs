using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CodeWars.Tests
{
    [TestFixture]
    public class CentroidTests
    {
        private static Random rnd = new Random();

        [Test]
        public void Sample_Test_1()
        {
            var arrs = new int[][] { new int[] { 1, 0, 5 }, new int[] { 0, 1, 5 }, new int[] { 2, 2, 5 } };
            var actual = Kata.Centroid(arrs);
            var expected = new double[] { 1, 1, 5 };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Sample_Test_2()
        {
            var arrs = new int[][] { new int[] { 7, 0, 5 }, new int[] { 3, 1, 5 }, new int[] { 2, 1, 5 } };
            var actual = Kata.Centroid(arrs);
            var expected = new double[] { 4, 0.67, 5 };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RandomTests()
        {
            var arrs = GenerateArrs();
            foreach (var arr in arrs)
            {
                var actual = Kata.Centroid(arr);
                var expected = new double[] {Math.Round(arr.Select(x => x[0]).Average(), 2),
                Math.Round(arr.Select(x => x[1]).Average(), 2),
                Math.Round(arr.Select(x => x[2]).Average(), 2) }; ;
                Assert.That(actual, Is.EqualTo(expected), "arr: [[" + String.Join(", ", arr.Select(x => x[0])) +
                    "]\n [" + String.Join(", ", arr.Select(x => x[1])) + "]\n [" + String.Join(", ", arr.Select(x => x[2])) + "]]");
            }
        }

        private int[][][] GenerateArrs()
        {
            var res = new int[100][][];

            for (int i = 0; i < 100; i++)
            {
                res[i] = new int[3][];
                res[i][0] = new int[] { rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100) };
                res[i][1] = new int[] { rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100) };
                res[i][2] = new int[] { rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100) };
            }

            return res;
        }
    }
}
