using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Recursion
{
    class TowerOfHanoi
    {
        static void Main(string[] args)
        {
            Move(3, 'A', 'B', 'C');
        }

        private static void Move(int n, char source, char intermediate, char destination)
        {
            if (n == 0) return;
            Move(n - 1, source, destination, intermediate);
            Console.WriteLine("Move disk {0} from {1} to {2}", n, source, destination);
            Move(n - 1, intermediate, source, destination);
        }
    }
}
