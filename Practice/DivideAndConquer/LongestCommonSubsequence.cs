using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class LongestCommonSubsequence
    {
        static void Main(string[] args)
        {
            string s1 = "elephant";
            string s2 = "eretpat";

            Console.WriteLine(LCS(s1, s2, 0, 0));

            s1 = "houdini";
            s2 = "hdupti";

            Console.WriteLine(LCS(s1, s2, 0, 0));
        }

        private static int LCS(string s1, string s2, int i1, int i2)
        {
            if (i1 == s1.Length || i2 == s2.Length)
            {
                return 0;
            }

            int c1 = 0;
            if(s1[i1] == s2[i2])
            {
                c1 = 1 + LCS(s1, s2, i1 + 1, i2 + 1);
            }

            int c2 = LCS(s1, s2, i1 + 1, i2);
            int c3 = LCS(s1, s2, i1, i2 + 1);

            return Math.Max(c1, Math.Max(c2, c3));
        }
    }
}
