using NUnit.Framework;
using System.Collections.Generic;

namespace CodeWars.Tests
{
    [TestFixture]
    public class BubbleTests
    {
        private static Random rnd = new Random();

        [TestCase]
        public void Should_Return_EmptyList()
        {
            var list = new List<int>() { 1, 2, 3, 4 };
            var actual = Kata.Bubble(list);
            var expected = new List<List<int>>();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Should_Return_OneElementList()
        {
            var list = new List<int>() { 1, 2, 4, 3 };
            var actual = Kata.Bubble(list);
            var expected = new List<List<int>>(){
                new List<int>() { 1,2,3,4 }};
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Should_Return_TwoElementsList()
        {
            var list = new List<int>() { 2,1,4,3 };
            var actual = Kata.Bubble(list);
            var expected = new List<List<int>>(){
                new List<int>() { 1,2,4,3 },
                new List<int>() { 1,2,3,4 }
            };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Should_Return_MultiList()
        {
            var list = new List<int>() { 1, 4, 3, 6, 7, 9, 2, 5, 8 };
            var actual = Kata.Bubble(list);
            var expected = new List<List<int>>(){
                new List<int>(){ 1, 3, 4, 6, 7, 9, 2, 5, 8 },
                new List<int>(){ 1, 3, 4, 6, 7, 2, 9, 5, 8 },
                new List<int>(){ 1, 3, 4, 6, 7, 2, 5, 9, 8 },
                new List<int>(){ 1, 3, 4, 6, 7, 2, 5, 8, 9 },
                new List<int>(){ 1, 3, 4, 6, 2, 7, 5, 8, 9 },
                new List<int>(){ 1, 3, 4, 6, 2, 5, 7, 8, 9 },
                new List<int>(){ 1, 3, 4, 2, 6, 5, 7, 8, 9 },
                new List<int>(){ 1, 3, 4, 2, 5, 6, 7, 8, 9 },
                new List<int>(){ 1, 3, 2, 4, 5, 6, 7, 8, 9 },
                new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RandomTests()
        {
            var lists = AddRandomLists();
            foreach (var list in lists)
            {
                var actual = Kata.Bubble(list.Select(x => x).ToList());
                var expected = GenerateRandomSolution(list.Select(x => x).ToList());
                Assert.That(actual, Is.EqualTo(expected), "List => " + String.Join(", ", list.Select(x => x)));
            }
        }

        private List<List<int>> GenerateRandomSolution(List<int> list)
        {
            var res = new List<List<int>>();
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i] < list[i - 1])
                    {
                        flag = true;
                        int temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;
                        res.Add(list.Select(x => x).ToList());
                    }
                }
            }
            return res;
        }

        private List<List<int>> AddRandomLists()
        {
            var lists = new List<List<int>>();
            for (int i = 0; i < 50; i++)
            {
                int l = rnd.Next(0, 50);
                var list = new List<int>();
                for (int j = 0; j < l; j++)
                {
                    int n = rnd.Next(-100, 100);
                    list.Add(n);
                }
                lists.Add(list);
            }
            return lists;
        }
    }
}
