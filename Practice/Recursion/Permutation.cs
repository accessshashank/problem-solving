using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Permutation
    {
        static void Main(string[] args)
        {
            Perm("", "abc");
        }

        private static void Perm(string processed, string unprocessed)
        {
           if(string.IsNullOrEmpty(unprocessed))
            {
                Console.WriteLine(processed);
                return;
            }

            char ch = unprocessed[0];
           for(int i=0; i<=processed.Length;i++)
            {
                string first = processed.Substring(0, i);
                string second = processed.Length >= 1 ? processed.Substring(i, processed.Length-i) : "";
                Perm(first + ch + second, unprocessed.Substring(1, unprocessed.Length-1));
            }
        }
    }
}
