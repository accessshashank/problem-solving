using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DivideAndConquer
{
    class HouseThief
    {
        static void Main(string[] args)
        {
            // n houses built in a line, each of which has some value in it
            // thief is going to steel max value from these houses
            // he cant steal in adjacent houses
            // find max stolen value

            int[] houseValues = new int[] { 6, 7, 1, 30, 8, 2, 4 };

            Console.WriteLine(Steal(houseValues, 0));
        }

        private static int Steal(int[] houseValues, int currentIndex)
        {
            if (currentIndex >= houseValues.Length) return 0;

            int steelCurrentHouse = houseValues[currentIndex] + Steal(houseValues, currentIndex + 2);
            int skipCurrentHouse = Steal(houseValues, currentIndex + 1);

            return Math.Max(steelCurrentHouse, skipCurrentHouse);
        }
    }
}
