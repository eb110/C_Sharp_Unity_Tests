using CodeWars.Bit;
using NUnit.Framework;
using System.Linq.Expressions;

namespace CodeWars.Tests
{
    [TestFixture]
    public class BitShiftTests
    {
        private int[][][] bitArrays = [[[0, 0, 0, 0, 0, 0, 0, 1],
            [0, 0, 0, 0, 0, 0, 1, 0],
            [0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 0, 0, 1, 0, 0, 0],
            [0, 0, 0, 1, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0, 0, 0], [0, 1, 0, 0, 0, 0, 0, 0], [1, 0, 0, 0, 0, 0, 0, 0]],
            [[0, 0, 0, 0, 0, 0, 1, 1], [0, 0, 0, 0, 0, 1, 1, 0], [0, 0, 0, 0, 1, 1, 0, 0], [0, 0, 0, 1, 1, 0, 0, 0], [0, 0, 1, 1, 0, 0, 0, 0],
                [0, 1, 1, 0, 0, 0, 0, 0], [1, 1, 0, 0, 0, 0, 0, 0]],
            [[0, 0, 0, 0, 0, 1, 1, 1], [0, 0, 0, 0, 1, 1, 1, 0], [0, 0, 0, 1, 1, 1, 0, 0], [0, 0, 1, 1, 1, 0, 0, 0],
                [0, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 0, 0, 0, 0, 0]]];

        [TestCase]
        public void Test_Shifting_1()
        {
            var expected = bitArrays[0];
            var actual = new BitShift().BitMarch(1);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Shifting_2()
        {
            var expected = bitArrays[1];
            var actual = new BitShift().BitMarch(2);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Shifting_3()
        {
            var expected = bitArrays[2];
            var actual = new BitShift().BitMarch(3);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Random_Test_Case()
        {
            for (int i = 4; i <= 8; i++)
            {
                var actual = new BitShift().BitMarch(i);
                var expected = GenerateRandomSolution(i);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private int[][] GenerateRandomSolution(int n)
        {
            n = (int)Math.Pow(2, n) - 1;
            var res = new List<int[]>();
            while (n < 256)
            {
                var wsad = Convert.ToString(n, 2).PadLeft(8, '0')
                    .Select(x => (int)x - 48);
                res.Add(wsad.ToArray());
                n *= 2;
            }
            return res.ToArray();
        }
    }
}
