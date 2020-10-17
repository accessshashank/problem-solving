using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Strings
{
    class Anagrams
    {
        static void Main(string[] args)
        {
            var str1 = "verbose";
            var str2 = "observe";
            CheckAnagram(str1, str2);
            str1 = "decimal";
            str2 = "medical";
            CheckAnagram(str1, str2);
            str1 = "shashank";
            str2 = "shashaki";
            CheckAnagram(str1, str2);
        }

        private static void CheckAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                Console.WriteLine("{0} and {1} are NOT anagrams", str1, str2);
                return;
            }

            var h = new int[26];
            for(int i=0; i<str1.Length; i++)
            {
                h[str1[i] - 97]++;
            }

            for (int i = 0; i < str2.Length; i++)
            {
                h[str2[i] - 97]--;
            }

            bool isAnagram = true;
            for(int i=0; i<h.Length;i++)
            {
                if(h[i] != 0)
                {
                    isAnagram = false;
                    break;
                }
            }

            if(isAnagram)
            {
                Console.WriteLine("{0} and {1} are anagrams", str1, str2);
            }
            else
            {
                Console.WriteLine("{0} and {1} are NOT anagrams", str1, str2);
            }
        }
    }
}
