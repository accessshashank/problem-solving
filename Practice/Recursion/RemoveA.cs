using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class RemoveA
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Remove("baccada"));
        }

        private static string Remove(string str)
        {
            if (str == null || str == "")
                return "";

            if(str[0] == 'a')
            {
                return Remove(str.Substring(1, str.Length - 1));
            }
            else
            {
                return str[0] + Remove(str.Substring(1, str.Length - 1));
            }

        }
    }
}
