﻿using System.Text.RegularExpressions;

namespace CodeWars
{
    public class Kata
    {
        public static int[] ArrayCenter(int[] arr )
        {
            var avg = arr.Average();
            var min = arr.Min();
            return arr.Where(x => Math.Abs(x - avg) < min).ToArray();
        }

        public static int ShortestTime(int n, int m, int[] speeds) =>
            Math.Min((n - 1) * speeds[3], Math.Abs(m - n) * speeds[0] + speeds[1] * 2 + speeds[2] + (n - 1) * speeds[0]);
        public static bool Gaslighting(string shirtWord, string yourWord, char[] friendsLetters) =>
            shirtWord.Where((x, i) => yourWord[i] != x && (friendsLetters.Contains(x) || friendsLetters.Contains(yourWord[i]))).Count() > 0; 
        public static double[] Centroid(int[][]c) => 
                new double[] {Math.Round(c.Select(x => x[0]).Average(), 2),
                Math.Round(c.Select(x => x[1]).Average(), 2),
                Math.Round(c.Select(x => x[2]).Average(), 2) };
        public static int StonePick(string[] arr) => Math.Min(arr.Select(x => x == "Cobblestone" ?  1 : 0).Sum() / 3, 
                arr.Select(x => x == "Wood" ? 4 : x == "Sticks" ? 1 : 0).Sum() / 2);
        public static bool PossiblyPerfect(string[] key, string[] ans)
        {
            int check = ans.Where((x, i) => x != "_" && x == key[i]).Count();
            return check == 0 || check == key.Where(x => x != "_").Count();
        }
        public static List<List<int>> Bubble(List<int> list)
        {
            var res = new List<List<int>>();
            bool flag = true;
            while(flag)
            {
                flag = false;
                for(int i = 1; i < list.Count; i++)
                {
                    if (list[i] < list[i-1]) 
                    {
                        flag = true;
                        int temp = list[i];
                        list[i] = list[i-1];
                        list[i-1] = temp;
                        res.Add(list.Select(x => x).ToList());
                    }
                }
            }
            return res;
        }
        public static List<int> ReverseMiddle(List<int> list) 
        {
            var check =  list.Skip(list.Count() / 2 - 1).Take(list.Count() % 2 == 0 ? 2 : 3).Reverse().ToList();
            return check;
        }
        public static bool StepThroughWith(string s) => new Regex(@"(.)\1").IsMatch(s);
    }
}
