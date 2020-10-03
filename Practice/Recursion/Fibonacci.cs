using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    // using memoization
    class Fibonacci
    {
        public static int[] store = new int[100];
        static void Main(string[] args)
        {
            for (int i = 0; i < store.Length -1; i++)
            {
                store[i] = -1;
            }

            //0,1,1,2,3,5,8
            int result = Fib(6);
            Console.WriteLine(result);
        }   
        private static int Fib(int n)
        {
            if(n <= 1)
            {
                store[n] = n;
                return n;
            }

            if (store[n - 2] == -1)
                store[n - 2] = Fib(n - 2);

            if (store[n - 1] == -1)
                store[n - 1] = Fib(n - 1);
            

            return store[n - 2] + store[n - 1];
        }
    }
}
