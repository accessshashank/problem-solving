using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class WordSearch
    {
        public static bool chk = false;
        static void Main(string[] args)
        {
            int rows = 3;
            int cols = 4;
            char[,] board = new char[,] {
            {'A','B','C','E' },
            {'S','F','C','S' },
            {'A','D','E','E' } };

            string word = "ABCCED";
            Console.WriteLine(Process(board, rows, cols, word));
        }

        private static bool Process(char[,] board, int rows, int cols, string word)
        {
            chk = false;
            for(int i = 0; i<rows;i++)
            {
                for(int j=0; j<cols; j++)
                {
                    if(board[i,j] == word[0])
                    {
                        recur(board, i, j, word, 0);
                    }
                }
            }
            return chk;
        }

        private static void recur(char[,] board, int i, int j, string word, int k)
        {
            if(k == word.Length)
            {
                chk = true;
                return;
            }

            if(i < 0 || j < 0 || i > 2 || j > 3 || board[i,j] == '@')
            {
                return;
            }

            if(board[i,j] == word[k])
            {
                char ch = board[i, j];
                board[i, j] = '@';
                recur(board, i, j+1, word, k + 1);
                recur(board, i + 1, j, word, k + 1);
                recur(board, i, j - 1, word, k + 1);
                recur(board, i - 1, j, word, k + 1);
                board[i, j] = ch;
            }
        }
    }
}
