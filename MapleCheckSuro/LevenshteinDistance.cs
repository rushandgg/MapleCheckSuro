using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCheckSuro
{
    public class LevenshteinDistance
    {
        public static int Compute(string s, string t)
        {
            int[,] d = new int[s.Length + 1, t.Length + 1];

            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            for (int i = 0; i <= s.Length; d[i, 0] = i++) { }
            for (int j = 0; j <= t.Length; d[0, j] = j++) { }

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[s.Length, t.Length];
        }
    }
}
