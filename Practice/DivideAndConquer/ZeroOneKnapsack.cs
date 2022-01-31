using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class ZeroOneKnapsack
    {
        static void Main(string[] args)
        {
            // given weights and profits of N items
            //we are asked to put these items in a knapsack which has a capacity C
            //WE CANT BREAK ITEMS INTO SMALLER UNITS, FRACTIONAL UNIT NOT ALLOWED. HINT - SO GREEDY ALSO WONT WORK
            // find max profit from items in knapsack

            string[] items = new string[] { "Mango","Apple", "Banana", "Orange" };
            int[] profits = new int[] {31, 26, 72, 17};
            int[] weights = new int[] { 3, 1, 5, 2 };
            int knapsackCapacity = 7;

            Console.WriteLine(MaximizeProfit(profits, weights, knapsackCapacity, 0));
        }

        private static int MaximizeProfit(int[] profits, int[] weights, int capacityRemaining, int currentIndex)
        {
            if (capacityRemaining == 0 || currentIndex >= profits.Length)
                return 0;

            int profitIncludingElementAtCurrentIndex = 0;

            if(weights[currentIndex] <= capacityRemaining)
            {
                profitIncludingElementAtCurrentIndex = profits[currentIndex] + MaximizeProfit(profits, weights, capacityRemaining - weights[currentIndex], currentIndex + 1);
            }

            int profitExcludingElementAtCurrentIndex = MaximizeProfit(profits, weights, capacityRemaining, currentIndex + 1);

            return Math.Max(profitExcludingElementAtCurrentIndex, profitIncludingElementAtCurrentIndex);
            
        }
    }
}
