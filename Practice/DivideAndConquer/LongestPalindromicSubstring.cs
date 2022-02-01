using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class LongestPalindromicSubstring
    {
        static void Main(string[] args)
        {
            string str = "MQADASM";
            int len = str.Length-1;
            Console.WriteLine(LPS(str, 0, len - 1));
        }

        private static int LPS(string str, int startIndex, int endIndex)
        {
            if (startIndex > endIndex) return 0;
            if (startIndex == endIndex) return 1;

            int c1 = 0;
            if(str[startIndex] == str[endIndex])
            {
                int remaining = endIndex - startIndex - 1;
                if(remaining == LPS(str, startIndex + 1, endIndex-1))
                {
                    c1 = remaining + 2;
                }
            }

            int c2 = LPS(str, startIndex + 1, endIndex);
            int c3 = LPS(str, startIndex, endIndex - 1);

            return Math.Max(c1, Math.Max(c2, c3));
        }
    }
}
