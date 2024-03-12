using System.Diagnostics.Metrics;

namespace CodeWars
{
    public class Kata1
    {
   
        public int FindBall(Scales scales)
        {
            var res = Traverse(scales, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            return res;
        }

        public int Traverse(Scales scales, int[] arr)
        {
            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).Take(arr.Length / 2).ToArray();
            var check = scales.GetWeight(left, right);
            var res = check == -1 ? left : right;
            if (res.Length == 1)
                return res[0];
            return Traverse(scales, res);
        }
    }

    public class Scales
    {
        private readonly int[] wsad = new int[] { 1, 1, 1, 1, 5, 1, 1, 1 };

        private int limit = 4;
        public int GetWeight(int[] left, int[] right)
        {
            limit = limit - 1;
            // implementacja na podstawie wsad
            return 0;
        }
    }
}
