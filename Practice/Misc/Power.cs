using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Misc
{
    class Power
    {
        static void Main(string[] args)
        {
            int baseNum = 3;
            int power = 5; // we are calculating 3 to the power 5
            int ans = 1;
            while(power > 0)
            {
                int lsb = power & 1;
                if(lsb == 1)
                {
                    ans = ans * lsb * baseNum;
                }

                power = power >> 1;
                baseNum = baseNum * baseNum;
            }

            Console.WriteLine(ans);

        }
    }
}
