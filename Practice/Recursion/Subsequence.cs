using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Subsequence
    {
        static void Main(string[] args)
        {
            Subseq("" , "abc");
        }

        private static void Subseq(string processed, string unprocessed)
        {
            if(string.IsNullOrEmpty(unprocessed))
            {
                Console.WriteLine(processed);
                return;
            }

            var ch = unprocessed[0];

            Subseq(processed + ch, unprocessed.Substring(1, unprocessed.Length - 1));
            Subseq(processed , unprocessed.Substring(1, unprocessed.Length - 1));
        }
    }
}
