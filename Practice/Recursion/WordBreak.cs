using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class WordBreak
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5263186#overview

            var dict = new List<string> { "i", "like", "sam", "sung", "samsung", "mobile"};
            string str = "ilikesamsungmobile";
            Console.WriteLine(WordCount(dict, dict.Count,0, str));
        }

        private static int WordCount(List<string> dict, int dictCount, int currentCount, string str)
        {
            if (dictCount == currentCount+1) return 1;
            int counter = 0;

            if (str.StartsWith(dict[currentCount]))
            {
                str = str.Replace(dict[currentCount], "");
                counter = counter + WordCount(dict, dictCount, currentCount + 1, str);
            }
            counter = counter + WordCount(dict, dictCount, currentCount + 1, str);
            return counter;
        }
    }
}
