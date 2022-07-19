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
            Console.WriteLine();
            SubSeq(0, new int[] { 3, 1, 2 }, new List<int>());
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

        private static void SubSeq(int index, int[] arr, List<int> temp)
        {
            if(index >= arr.Length)
            {
                Console.WriteLine(string.Join(",", temp));
                return;
            }

            temp.Add(arr[index]);
            SubSeq(index + 1, arr, temp);
            temp.Remove(arr[index]);
            SubSeq(index + 1, arr, temp);
        }
    }
}
