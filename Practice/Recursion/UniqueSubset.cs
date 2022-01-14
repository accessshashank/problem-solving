using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class UniqueSubset
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5282968#overview
            int[] arr = new int[] { 1, 2, 2};
            var result = SubsetsWithDup(arr) ;

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }
        }

        private static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            Subsets(nums, 0, new List<int>(), result);
            return result; 
        }

        private static void Subsets(int[] nums, int startIndex, IList<int> oneResult, IList<IList<int>> result)
        {
            result.Add(new List<int>(oneResult));

            var n = nums.Length;

            for (int i = startIndex; i < n; i++)
            {
                if (i > startIndex && nums[i - 1] == nums[i]) continue;

                oneResult.Add(nums[i]);
                Subsets(nums, i + 1, oneResult, result);
                oneResult.RemoveAt(oneResult.Count - 1);
            }
        }
    }
}
