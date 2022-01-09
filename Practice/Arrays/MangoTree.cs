using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Arrays
{
    class MangoTree
    {
        static void Main(string[] args)
        {
            //https://www.udemy.com/course/cpp-data-structures-algorithms-prateek-narang/learn/lecture/26886952#overview

            int[,] arr = new int[6, 6] { 
                                        {0, 1, 1, 0, 0, 0 },
                                        {1, 0, 0, 1, 1, 0 },
                                        {0, 1, 0, 0, 0, 0 },
                                        {0, 1, 1, 0, 0, 1 },
                                        {1, 0, 0, 1, 1, 0 },
                                        {0, 1, 0, 0, 0, 0 } };

            FindMax(arr);
        }

        private static void FindMax(int[,] arr)
        {
            int[,] auxiliaryArray = new int[6, 6];
            for(int i=0; i<6;i++)
            {
                for(int j=0; j<6;j++)
                {
                    int areaOfSquare = 0;
                    if(i > 0)
                    {
                        areaOfSquare = areaOfSquare + auxiliaryArray[i - 1, j];
                    }
                    if(j > 0)
                    {
                        areaOfSquare = areaOfSquare + auxiliaryArray[i, j - 1];
                    }
                    if(i > 0 && j > 0)
                    {
                        areaOfSquare = areaOfSquare - auxiliaryArray[i - 1, j - 1];
                    }
                    if(arr[i,j] == 1)
                    {
                        auxiliaryArray[i, j] = 1 + areaOfSquare;
                    }
                    else
                    {
                        auxiliaryArray[i, j] = areaOfSquare;
                    }
                }
            }

            int min = 0;
            int counter = 0;
            int[] minArray = new int[36];
            for (int i = 0; i < 6; i++)
            { 
                for (int j = 0; j < 6; j++)
                {
                    min = int.MaxValue;
                    int S1 = auxiliaryArray[i, j];
                    int S2 = auxiliaryArray[i, 5] - S1;
                    int S3 = auxiliaryArray[5, j] - S1;
                    int S4 = auxiliaryArray[5, 5] - S1 - S2 - S3;
                    min = Math.Min(min, Math.Min(S1, Math.Min(S2, Math.Min(S3, S4))));
                    minArray[counter] = min;
                    counter++;
                }
            }

            int maxInMinArray = 0;
            for(int i=0; i<36;i++)
            {
                maxInMinArray = Math.Max(maxInMinArray, minArray[i]);
            }
            Console.WriteLine(maxInMinArray);
        }
    }
}
