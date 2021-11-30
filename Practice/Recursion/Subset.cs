using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class Subsets
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3 };
            var result = Subset(arr);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static List<List<int>> Subset(int[] arr)
        {
            var outer = new List<List<int>>();
            outer.Add(new List<int>());
            foreach (var item in arr)
            {
                int n = outer.Count;
                for(int i=0; i< n; i++)
                {
                    List<int> inner = new List<int>(outer[i]);
                    inner.Add(item);
                    outer.Add(inner);
                }
            }
            return outer;
        }
    }
}
