
namespace CodeWars.Bit
{
    public class BitShift : IBitShift
    {
        public int[][] BitMarch(int n)
        {
            n = (int)Math.Pow(2, n) - 1;
            var res = new List<int[]>();
            while(n < 256)
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
