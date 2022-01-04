using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Misc
{
    class MagicNumber
    {
        static void Main(string[] args)
        {
            // A magic number of n means,
            // represent n in binary and then for every bit multiply with 5 power starting from 1
            int n = 6;
            int ans = 0;
            int baseNum = 5;

            while(n >0)
            {
                int lsb = n & 1;
                n = n >> 1;
                ans = ans + lsb * baseNum;
                baseNum = baseNum * 5;
            }
            Console.Write(ans);

        }
    }
}
