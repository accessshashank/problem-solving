using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GreedyAlgos
{
    class CoinChange
    {
        static void Main(string[] args)
        {
            int amount = 2045;

            var deno = new List<int>();
            deno.Add(1);
            deno.Add(2);
            deno.Add(5);
            deno.Add(10);
            deno.Add(20);
            deno.Add(50);
            deno.Add(100);
            deno.Add(500);
            deno.Add(1000);

            MinCoins(amount, deno);
        }

        private static void MinCoins(int amount, List<int> deno)
        {
            var count = new List<int>();
            while(amount > 0)
            {
                int largestDeno = GetLargestDenominationLessThanCurrentAmount(amount, deno);
                amount = amount - largestDeno;
                count.Add(largestDeno);
            }

            Console.WriteLine(string.Join(",", count));
        }

        private static int GetLargestDenominationLessThanCurrentAmount(int amount, List<int> deno)
        {
            deno.Sort((x, y) => { return y.CompareTo(x); });

            for(int i=0; i<deno.Count;i++)
            {
                if(amount >= deno[i])
                {
                    return deno[i];
                }
            }
            return 0;
        }
    }
}
