using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class PalindromeUsingRecursion
    {
        static void Main(string[] args)
        {

            var str = "madam";
            bool isPlaindrome = Palindrome(str);
            Console.WriteLine("{0} is palindrome : {1}",str, isPlaindrome);
            str = "abcdedcba";
            isPlaindrome = Palindrome(str);
            Console.WriteLine("{0} is palindrome : {1}", str, isPlaindrome);
            str = "sharhs";
            isPlaindrome = Palindrome(str);
            Console.WriteLine("{0} is palindrome : {1}", str, isPlaindrome);
        }

        private static bool Palindrome(string str)
        {
            if (str.Length == 1) return true;
            return str[0] == str[str.Length - 1] && Palindrome(str.Substring(1, str.Length - 2));
        }
    }
}
