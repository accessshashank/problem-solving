using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class DefenseKingdom
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/quiz/5293122#overview
            int width = 15;
            int height = 8;
            var positions = new List<Position> { 
            new Position { AlongWidth = 3, AlongHeight = 8 },
            new Position { AlongWidth = 11, AlongHeight = 2 },
            new Position { AlongWidth = 8, AlongHeight = 6 }};

            Console.WriteLine(DefKin(width, height, positions));
        }

        public static int DefKin(int width, int height, List<Position> positions)
        {
            // adding dummy positions for easier calculations
            positions.Add(new Position { AlongHeight = 0, AlongWidth = 0 });
            positions.Add(new Position { AlongWidth = width+1, AlongHeight = height+1 });

            var maxWidth = GetMaxWidth(positions);
            var maxHeight = GetMaxHeight(positions);

            return maxWidth*maxHeight;
        }

        private static int GetMaxHeight(List<Position> positions)
        {
            positions.Sort((a, b) => { return a.AlongHeight.CompareTo(b.AlongHeight); });

            int maxHeight = 0;
            for (int i = 0; i < positions.Count - 1; i++)
            {
                maxHeight = Math.Max(maxHeight, positions[i + 1].AlongHeight - positions[i].AlongHeight - 1);
            }

            return maxHeight;
        }

        private static int GetMaxWidth(List<Position> positions)
        {
            positions.Sort((a, b) => { return a.AlongWidth.CompareTo(b.AlongWidth); });

            int maxWidth = 0;
            for(int i=0; i<positions.Count-1; i++)
            {
                maxWidth = Math.Max(maxWidth, positions[i + 1].AlongWidth - positions[i].AlongWidth - 1);
            }

            return maxWidth;
        }
    }

    class Position
    {
        public int AlongWidth { get; set; }
        public int AlongHeight { get; set; }
    }
}
