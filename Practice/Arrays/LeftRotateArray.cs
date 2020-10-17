using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class LeftRotateArray
    {
        static void Main(string[] args)
        {
            var chars = new char [] { 'W','E','L','C','O','M','E'};
            LeftRotate(chars);
        }

        private static void LeftRotate(char[] chars)
        {
            var length = chars.Length;
            int rotationCount = 1;
            while(rotationCount <= length)
            {
                var firstChar = chars[0];
                for (int i = 0; i < length - 1; i++)
                {
                    chars[i] = chars[i + 1];
                }
                chars[length - 1] = firstChar;

                Console.WriteLine(string.Join("",chars));
                rotationCount++;
            }
            
        }
    }
}
