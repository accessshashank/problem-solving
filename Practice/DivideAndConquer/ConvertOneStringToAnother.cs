using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class ConvertOneStringToAnother
    {
        static void Main(string[] args)
        {
            //we are given strings s1 and s2
            //we need to convert s2 to s1 by inserting, deleting & replacing characters
            //write function to calculate count of minimum number of edit operations

            string s1 = "catch";
            string s2 = "carch";

            Console.WriteLine(FindMinEdits(s1, s2, 0, 0));

            s1 = "table";
            s2 = "tbres";

            Console.WriteLine(FindMinEdits(s1, s2, 0, 0));
        }

        private static int FindMinEdits(string s1, string s2, int i1, int i2)
        {
            if(i1 == s1.Length)
            {
                return s2.Length - i2; // s2 has extra chars which needs to be deleted
            }
            else if(i2 == s2.Length)
            {
                return s1.Length - i1; // s1 has extra chars which need to be inserted into s2
            }

            if (s1[i1] == s2[i2])
                return FindMinEdits(s1, s2, i1 + 1, i2 + 1);

            int count1 = 1 + FindMinEdits(s1, s2, i1 + 1, i2); // Insert
            int count2 = 1 + FindMinEdits(s1, s2, i1, i2 + 1); // Delete
            int count3 = 1 + FindMinEdits(s1, s2, i1 + 1, i2 + 1); // Replace

            return Math.Min(count1, Math.Min(count2, count3));
        }
    }
}
