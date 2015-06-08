using System;
using System.Collections.Generic;

namespace JoroTheRabbit
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arrayOfNums = new int[input.Length];
            for (int i = 0; i < arrayOfNums.Length; i++)
            {
                arrayOfNums[i] = int.Parse(input[i]);
            }
            int maxVisited = 0;
            for (int startIndex = 0; startIndex < arrayOfNums.Length; startIndex++)
            {
                for (int step = 1; step <= arrayOfNums.Length; step++)
                {
                    int index = startIndex;
                    int next = (index + step) % arrayOfNums.Length;
                    int count = 1;
                    while (next != startIndex && arrayOfNums[index] < arrayOfNums[next])
                    {
                        index = next;
                        next = (index + step);
                        if (next > arrayOfNums.Length - 1)
                        {
                            next -= arrayOfNums.Length;
                        }
                        count++;
                    }
                    if (maxVisited < count)
                    {
                        maxVisited = count;
                        //                        if (maxVisited == arrayOfNums.Length)
                        //                        {
                        //                            Console.WriteLine (maxVisited);
                        //                            Environment.Exit(0);
                        //                        }
                    }
                }
            }
            Console.WriteLine(maxVisited);
        }

        public static int GetVisitedPositions(int startIndex, int step, int[] arrayOfNums)
        {
            int index = startIndex;
            int next = (index + step) % arrayOfNums.Length;
            int count = 1;
            while (next != startIndex && arrayOfNums[index] < arrayOfNums[next])
            {
                index = next;
                next = (index + step);
                if (next > arrayOfNums.Length - 1)
                {
                    next -= arrayOfNums.Length;
                }
                count++;
            }
            return count;
        }
    }
}