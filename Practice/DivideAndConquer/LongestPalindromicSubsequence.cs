using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class LongestPalindromicSubsequence
    {
        static void Main(string[] args)
        {
            string s = "ELRMENMET"; //EMEME is palindrome
            int startIndex = 0;
            int endIndex = s.Length - 1;

            Console.WriteLine(LPS(s, startIndex, endIndex));
        }

        private static int LPS(string str, int startIndex, int endIndex)
        {
            if (startIndex > endIndex) return 0;
            if (startIndex == endIndex) return 1; //on char only so palindrome size will be 1

            int c1 = 0;
            if(str[startIndex] == str[endIndex])
            {
                c1 = 2 + LPS(str, startIndex + 1, endIndex - 1); // 2 because palindrome will be 2 as per current iteration
            }

            int c2 = LPS(str, startIndex + 1, endIndex);
            int c3 = LPS(str, startIndex, endIndex - 1);

            return Math.Max(c1, Math.Max(c2, c3));
        }
    }
}
