using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Strings
{
    class DuplicateCharsInStringUsingBits
    {
        static void Main(string[] args)
        {
            //Note:cant find count of duplicates using bits
            var str = "finding";
            FindDuplicates(str);
            FindDuplicates("madamm");
        }

        private static void FindDuplicates(string str)
        {
            int H = 0; 
            int x = 0;
            for(int i=0; i< str.Length; i++)
            {
                x = 1;
                x = x << (str[i] - 97);
                if((H & x) > 0)
                {
                    Console.WriteLine("{0} is duplicate",str[i]);
                }
                else
                {
                    H = H | x;
                }
            }
        }
    }
}
