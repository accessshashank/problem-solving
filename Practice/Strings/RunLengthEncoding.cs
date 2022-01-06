using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Strings
{
    class RunLengthEncoding
    {
        static void Main(string[] args)
        {
            string input = "aaabbcddeeeff";
            Console.WriteLine(Encode(input));
            Console.WriteLine(Encode("abcd"));

            Console.WriteLine(EncodeAnother(input));
            Console.WriteLine(EncodeAnother("abcd"));
        }

        private static string EncodeAnother(string input)
        {
            int len = input.Length;
            string output = "";
            for(int i=0; i<len;i++)
            {
                int count = 1;
                while(i < len-1 && input[i] == input[i+1])
                {
                    count++;
                    i++;
                }
                output = count > 1 ? output + input[i] + count.ToString() : output + input[i];
            }

            return output;
        }

        private static string Encode(string input)
        {
            int[] arr = new int[26];
            for(int i =0; i<26;i++)
            {
                arr[i] = 0;
            }

            foreach (var ch in input.ToCharArray())
            {
                int index = ch - 97;
                arr[index]++;
            }

            string output = "";
            for(int i=0;arr[i] > 0 && i<=25;i++)
            {
                char ch = (char)(i + 97);
                output = arr[i] > 1 ? output + ch + arr[i] : output + ch;
            }

            return output;
        }
    }
}
