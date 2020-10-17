using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Strings
{
    class DuplicateCharsInString
    {
        static void Main(string[] args)
        {
            var str = "finding";
            FindDuplicates(str);
            FindDuplicates("madamm");
        }

        private static void FindDuplicates(string str)
        {
            var h = new int[26];
            for(int i=0; i<26; i++)
            {
                h[i] = 0;
            }

            for(int i=0; i< str.Length; i++)
            {
                var index = str[i] - 97;
                h[index]++;
            }

            for(int i =0;i<h.Length;i++)
            {
                if(h[i] > 1)
                {
                    char c = (char)(i + 97);
                    Console.WriteLine("{0} is duplicate, occurred {1} times", c, h[i]);
                }
            }
        }
    }
}
