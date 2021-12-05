using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class LetterCombinationOfPhoneNumber
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<char, string>();
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "ghi");
            dict.Add('5', "jkl");
            dict.Add('6', "mno");
            dict.Add('7', "pqrs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxyz");
            var combos = letterCombinations(dict, "", "23456789");
            var returnValues = new List<string>();
            foreach (var item in combos)
            {
                string str = "";
                StringBuilder builder = new StringBuilder();
                foreach (var ch in item.ToCharArray())
                {
                    builder.Append(dict[ch]);
                }
                returnValues.Add(builder.ToString());
            }

            string digits = "234";
            var items = letterCombinationsAnother(dict, digits, "", 0);
        }

        private static List<string> letterCombinationsAnother(Dictionary<char, string> dict, string digits, string current, int index)
        {
            var allStrings = new List<string>();
            if(index == digits.Length)
            {
                allStrings.Add(current);
                return allStrings;
            }

            string chars = dict[digits[index]];
            foreach (var ch in chars.ToCharArray())
            {
                var belowStrings = letterCombinationsAnother(dict, digits, current + ch, index+1);
                allStrings.AddRange(belowStrings);
            }
            return allStrings;
        }

        private static List<string> letterCombinations(Dictionary<char, string> dict, string processed, string unprocessed)
        {
            var allStrings = new List<string>();

            if(string.IsNullOrEmpty(unprocessed))
            {
                allStrings.Add(processed);
                return allStrings;
            }

            char ch = unprocessed[0];

            for(int i=0;i<=processed.Length;i++)
            {
                string first = processed.Substring(0, i);
                string second = processed.Length >= 1 ? processed.Substring(i, processed.Length - i) : "";
                var belowStrings = letterCombinations(dict, first + ch + second, unprocessed.Substring(1, unprocessed.Length - 1));
                allStrings.AddRange(belowStrings);
            }

            return allStrings;
        }
    }
}
