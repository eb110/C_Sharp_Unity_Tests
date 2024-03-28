using NUnit.Framework;
using System.Text.RegularExpressions;
using System;

namespace CodeWars.Tests
{
    [TestFixture]
    public class CalculateSpeedTests
    {
        private static Random rnd = new Random();

        [TestCase("100m", "10s", ExpectedResult = "22mph")]
        [TestCase("3km", "5min", ExpectedResult = "22mph")]
        [TestCase("35m", "293s", ExpectedResult = "0mph")]
        [TestCase("573km", "39min", ExpectedResult = "548mph")]
        public string Sample_Cases(string d, string t) => Kata.CalculateSpeed(d, t);

        [Test]
        public void Random_Cases()
        {
            for(int i = 0; i < 100; i++)
            {
                var d = $"{rnd.Next(1, 1001)}" + (rnd.Next(0,2) == 0 ? "km" : "m");
                var t = $"{rnd.Next(1, 1001)}" + (rnd.Next(0,2) == 0 ? "min" : "s");
                var actual = Kata.CalculateSpeed(d, t);
                var expected = Calculate_Result(d, t);
                Assert.That(actual, Is.EqualTo(expected), $"distance: {d}, time: {t}");
            }
        }

        private string Calculate_Result(string distance, string time)
        {
            int d = int.Parse(Regex.Replace(distance, @"\D", "")) * (distance.Contains("km") ? 1000 : 1);
            int s = int.Parse(Regex.Replace(time, @"\D", "")) * (time.Contains("min") ? 60 : 1);
            return $"{Math.Round(d * 1.0 / s * 2.23694)}mph";
        }
    }
}
