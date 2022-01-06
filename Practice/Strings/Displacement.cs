using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Strings
{
    class Displacement
    {
        static void Main(string[] args)
        {
            var direction = "SNNNEWE";

            Console.WriteLine(FindDisplacement(direction));
        }

        private static string FindDisplacement(string direction)
        {
            var origin = new Coordinates { X = 0, Y = 0 };
            foreach (var ch in direction.ToCharArray())
            {
                if (ch == 'E') origin.X++;
                if (ch == 'W') origin.X--;
                if (ch == 'N') origin.Y++;
                if (ch == 'S') origin.Y--;
            }
            var disp = "";
            if (origin.X > 0)
            {
                for (int i = 1; i <= origin.X; i++)
                {
                    disp = disp + "E";
                }
            }
            else
            {
                for (int i = 1; i <= origin.X; i++)
                {
                    disp = disp + "W";

                }

            }

            if (origin.Y > 0)
            {
                for (int i = 1; i <= origin.Y; i++)
                {
                    disp = disp + "N";
                }
            }
            else
            {
                for (int i = 1; i <= origin.Y; i++)
                {
                    disp = disp + "S";

                }

            }

            return disp;

        }
    }

       

    class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
