using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Revision
    {
        static void Main(string[] args)
        {
            string str = "abcd";
            Perm("", str);
        }

        private static void Perm(string processed, string unProcesed)
        {
            if(string.IsNullOrEmpty(unProcesed))
            {
                Console.WriteLine(processed);
                return;
            }

            char ch = unProcesed[0];

            for (int i = 0; i <= processed.Length ; i++)
            {
                string first = processed.Substring(0, i);
                string second = processed.Length >= 1 ? processed.Substring(i, processed.Length - i) : "";
                Perm(first + ch + second, unProcesed.Substring(1, unProcesed.Length - 1));
            }
        }
    }
}
