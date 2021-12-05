using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Maze
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(TravelMazeRecursive(3,3));
            TravelMazeRecursivePrintPath("", 3, 3);
        }

        //count of paths from 3,3 to 1,1. user can move right or down
        private static int TravelMazeRecursive(int row, int col)
        {
            if (row == 1 || col == 1) return 1;

            int left = TravelMazeRecursive(row - 1, col);
            int right = TravelMazeRecursive(row, col - 1);
            return left + right;
        }

        //count of paths from 3,3 to 1,1. user can move right or down
        private static void TravelMazeRecursivePrintPath(string processed, int row, int col)
        {
            if (row == 1 && col == 1)
            {
                Console.WriteLine(processed);
                return;
            }

            if(row == 1)
            {
                TravelMazeRecursivePrintPath(processed + "R", row, col - 1);
            }
            else if(col == 1)
            {
                TravelMazeRecursivePrintPath(processed + "D", row - 1, col);
            }
            else
            {
                TravelMazeRecursivePrintPath(processed + "R", row, col - 1);
                TravelMazeRecursivePrintPath(processed + "D", row - 1, col);
            }

        }
    }
}
