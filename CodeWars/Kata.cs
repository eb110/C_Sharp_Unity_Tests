using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        public static string CalculateSpeed(string distance, string time)
        {
            int d = int.Parse(Regex.Replace(distance, @"\D", "")) * (distance.Contains("km") ? 1000 : 1);
            int s = int.Parse(Regex.Replace(time, @"\D", "")) * (time.Contains("min") ? 60 : 1);
            return $"{Math.Round(d * 1.0 / s * 2.23694)}mph";
        }

        private static List<string> pswds = new List<string>();
        public static void SignIn(string pswd) => pswds.Add(pswd);
        public static bool LogIn(string pswd) => pswds.Contains(pswd);
        public static bool CanIPlay(int now, int start, int end) => end < start && (now >= start || now < end)
            || now >= start && now < end;
        public static bool IsItLetter(char c) => new Regex(@"[a-zA-Z]").IsMatch("" + c);
        public static List<List<int>> Bubble(List<int> list)
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
        public static bool DidWeWin(object[][] plays) => plays.Aggregate(0, (sum, x) => x.Length == 0 ? sum + 0 :
        "passrun".Contains((string)x[1]) ? sum + (int)x[0] : ((string)x[1]).Equals("turnover") ? Math.Abs(sum) * -1 : sum - (int)x[0]) > 10;
        public static bool BulbMaze(string maze) =>
            maze.Where((x, i) => i % 2 == 0 && x == 'o' || i % 2 != 0 && x == 'x').Count() == 0;
        public static List<List<BigInteger>> Make2dList(BigInteger head, int row, int col)
        {
            var res = new List<List<BigInteger>>();
            for (int i = 0; i < row; i++)
            {
                res.Add(new List<BigInteger>());
                for (int j = 0; j < col; j++) res[i].Add(head++);
            }
            return res;
        }
        public static int[] ArrayCenter(int[] arr)
        {
            var avg = arr.Average();
            var min = arr.Min();
            return arr.Where(x => Math.Abs(x - avg) < min).ToArray();
        }
        public static int ShortestTime(int n, int m, int[] speeds) =>
            Math.Min((n - 1) * speeds[3], Math.Abs(m - n) * speeds[0] + speeds[1] * 2 + speeds[2] + (n - 1) * speeds[0]);
        public static bool Gaslighting(string shirtWord, string yourWord, char[] friendsLetters) =>
            shirtWord.Where((x, i) => yourWord[i] != x && (friendsLetters.Contains(x) || friendsLetters.Contains(yourWord[i]))).Count() > 0;
        public static double[] Centroid(int[][] c) =>
                new double[] {Math.Round(c.Select(x => x[0]).Average(), 2),
                Math.Round(c.Select(x => x[1]).Average(), 2),
                Math.Round(c.Select(x => x[2]).Average(), 2) };
        public static int StonePick(string[] arr) => Math.Min(arr.Select(x => x == "Cobblestone" ? 1 : 0).Sum() / 3,
                arr.Select(x => x == "Wood" ? 4 : x == "Sticks" ? 1 : 0).Sum() / 2);
        public static bool PossiblyPerfect(string[] key, string[] ans)
        {
            int check = ans.Where((x, i) => x != "_" && x == key[i]).Count();
            return check == 0 || check == key.Where(x => x != "_").Count();
        }
        public static List<int> ReverseMiddle(List<int> list)
        {
            var check = list.Skip(list.Count() / 2 - 1).Take(list.Count() % 2 == 0 ? 2 : 3).Reverse().ToList();
            return check;
        }
        public static bool StepThroughWith(string s) => new Regex(@"(.)\1").IsMatch(s);
    }
}
