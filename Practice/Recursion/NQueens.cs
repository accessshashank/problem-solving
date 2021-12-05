using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class NQueens
    {
        static void Main(string[] args)
        {
            const int size = 4;
            bool[, ] board = new bool[size, size] { 
            {false, false, false, false },
            {false, false, false, false },
            {false, false, false, false },
            {false, false, false, false }
            };

            int pathsCount = NQueensRecur(board, size, 0);

            Console.WriteLine("Total Paths = "+pathsCount);
        }

        private static int NQueensRecur(bool[,] board, int size, int row)
        {
            if(row == size)
            {
                for(int i=0; i < size; i++)
                {
                    for(int j=0; j< size; j++)
                    {
                        Console.Write(board[i, j] ? "Q" : "X");
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("------------------------");
                return 1;
            }
            int count = 0;

            for(int col = 0; col < size; col++)
            {
                if(IsSafe(board, size, row, col))
                {
                    board[row, col] = true;
                    count += NQueensRecur(board, size, row + 1);
                    board[row, col] = false;
                }
            }
            return count;
        }

        private static bool IsSafe(bool[,] board, int size, int row, int col)
        {
            for(int i=0; i<size; i++)
            {
                if (board[row, i] == true)
                    return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (board[i, col] == true)
                    return false;
            }

            int copyRow = row;
            int copyCol = col;

            while(copyRow >= 0 && copyCol >=0)
            {
                if (board[copyRow, copyCol] == true) return false;
                copyRow--;
                copyCol--; 
            }

            copyRow = row;
            copyCol = col;

            while (copyRow >= 0 && copyCol < size)
            {
                if (board[copyRow, copyCol] == true) return false;
                copyRow--;
                copyCol++;
            }

            return true;
        }
    }
}
