namespace _07.TasksInTelerik
{
    using System;
    using System.Linq;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/173
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var tasks = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int neededDifference = int.Parse(Console.ReadLine());

            if (size == 1)
            {
                Console.WriteLine(1);
                return;
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            int neededIndex = -1;
            int minIndex = -1;
            int maxIndex = -1;

            for (int i = 0; i < size; i++)
            {
                var currentNumber = tasks[i];
                if (currentNumber > max)
                {
                    max = currentNumber;
                    maxIndex = i;
                }

                if (currentNumber < min)
                {
                    min = currentNumber;
                    minIndex = i;
                }

                if (max - min >= neededDifference)
                {
                    neededIndex = i;
                    break;
                }
            }

            if (neededIndex == -1)
            {
                Console.WriteLine(size);
                return;
            }


            int firstIndex = Math.Min(minIndex, maxIndex);
            var nextIndex = 0;
            int result = 1;
            while (true)
            {
                if (firstIndex == nextIndex)
                {
                    break;
                }

                if (nextIndex + 1 == firstIndex)
                {
                    nextIndex++;
                    result++;
                    break;
                }

                if (nextIndex + 2 == firstIndex)
                {
                    nextIndex += 2;
                    result++;
                    break;
                }

                nextIndex += 2;
                result++;
            }

            while (true)
            {
                if (neededIndex == nextIndex)
                {
                    break;
                }

                if (nextIndex + 1 == neededIndex)
                {
                    nextIndex++;
                    result++;
                    break;
                }

                if (nextIndex + 2 == neededIndex)
                {
                    nextIndex += 2;
                    result++;
                    break;
                }

                nextIndex += 2;
                result++;
            }

            Console.WriteLine(result);

            //if (firstIndex != 0)
            //{
            //    var distanceToFirstIndex = firstIndex / 2;
            //    if (firstIndex % 2 != 0)
            //    {
            //        distanceToFirstIndex += 1;
            //    }


            //    var distanceFromFirstToNeeded = neededIndex - firstIndex;
            //    if (distanceFromFirstToNeeded % 2 == 0)
            //    {
            //        distanceFromFirstToNeeded /= 2;
            //    }
            //    else
            //    {
            //        distanceFromFirstToNeeded /= 2;
            //        distanceFromFirstToNeeded += 1;
            //    }

            //    Console.WriteLine((distanceFromFirstToNeeded + distanceToFirstIndex) + 1);
            //}
            //else
            //{
            //    if (neededIndex % 2 == 0)
            //    {
            //        Console.WriteLine((neededIndex / 2) + 1);
            //    }
            //    else
            //    {
            //        Console.WriteLine((neededIndex / 2) + 2);
            //    }
            //}
        }
    }
}
