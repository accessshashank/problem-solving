using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.LinkedList
{
    class HappyNumber
    {
        static void Main(string[] args)
        {
            // start with positive number replace number by sum of squares of its digits.
            // repeat this until number becomes 1 or loops endlessly in a cycle    
            // numbers ending 1 are happy
            // we will utilize cycle/loop in linked list concept

            int number = 19;
            Console.WriteLine(number.ToString() + " is happy - " + IsHappy(number));
        }

        private static bool IsHappy(int number)
        {
            int slow = number;
            int fast = number;

            do
            {
                slow = SquaresOfDigits(slow);
                fast = SquaresOfDigits(SquaresOfDigits(fast));

            } while (slow != fast);

            if (slow == 1) return true;
            return false;

        }

        private static int SquaresOfDigits(int number)
        {
            int ans = 0;
            while(number > 0)
            {
                int remainder = number % 10;
                ans = ans + remainder * remainder;
                number = number / 10;
            }
            return ans;
        }
    }
}
