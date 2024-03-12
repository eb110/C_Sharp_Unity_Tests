namespace CodeWars
{
    public class KataOld
    {
        public static bool Collinearity(int x1, int y1, int x2, int y2) => x1 * y2 == x2 * y1;

        public static string GimmeTheLetters(string sp) =>
             string.Concat(Enumerable.Range(sp[0], sp[2] - sp[0] + 1).Select(x => (char)x));

        

    } 
}
