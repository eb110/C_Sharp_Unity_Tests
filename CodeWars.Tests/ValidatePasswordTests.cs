using NUnit.Framework;
using System.Text;

namespace CodeWars.Tests
{
    [TestFixture]
    public class ValidatePasswordTests
    {
        private static Random rnd = new Random();

        [TestCase("Mr. me", true)]
        [TestCase("Bubblehead123", true)]
        [TestCase("This is not a pswd", false)]
        public void Sample_Cases(string pswd, bool signedIn)
        {
            if (signedIn) Kata.SignIn(pswd);
            var actual = Kata.LogIn(pswd);
            Assert.That(actual, Is.EqualTo(signedIn));
        }

        [TestCase("buyMe2", true)]
        [TestCase("twentysixteen", false)]
        [TestCase("buyMe2", true)]
        [TestCase("twentysixteen", true)]
        [TestCase("BuyMe2", false)]
        [TestCase("buyme2", false)]
        [TestCase("TWENTYSIXTEEN", false)]
        public void Basic_Cases(string pswd, bool signedIn) => Sample_Cases(pswd, signedIn);

        [Test]
        public void Random_Cases()
        {
            for(int i = 0; i < 100; i++)
            {
                var example = Create_Example();
                Sample_Cases(example.Item1, example.Item2);
            }
        }

        private Tuple<string, bool> Create_Example()
        {
            string alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            var alphLength = alph.Length;
            var l = rnd.Next(1, 20);
            var word = new StringBuilder(l);
            for(int i = 0; i < l; i++) word.Append(alph[rnd.Next(0, alphLength)]);
            return new Tuple<string, bool>(word.ToString(), rnd.Next(0, 2) == 0);
        }
    }
}
