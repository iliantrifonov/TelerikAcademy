using System;

namespace AcademyTasks
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int variation = int.Parse(Console.ReadLine());
            string[] a = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            int[] pleasureArr = new int[a.Length];
            for (int i = 0; i < pleasureArr.Length; i++)
            {
                pleasureArr[i] = int.Parse(a[i]);
            }

            int minNum = int.MaxValue;
            int minIndex = int.MaxValue;
            int maxNum = int.MinValue;
            int maxIndex = int.MinValue;
            int firstIndex = 0;
            int lastIndex = 0;
            for (int i = 0; i < pleasureArr.Length; i++)
            {
                if (pleasureArr[i] < minNum)
                {
                    minNum = pleasureArr[i];
                    minIndex = i;
                }
                if (pleasureArr[i] > maxNum)
                {
                    maxNum = pleasureArr[i];
                    maxIndex = i;
                }
                if (Math.Abs(pleasureArr[i] - minNum) >= variation || Math.Abs(pleasureArr[i] - maxNum) >= variation)
                {
                    if (Math.Abs(pleasureArr[i] - minNum) >= variation)
                    {
                        firstIndex = minIndex;
                    }
                    else
                    {
                        firstIndex = maxIndex;
                    }
                    lastIndex = i;
                    break;
                }
                if (i == pleasureArr.Length - 1)
                {
                    Console.WriteLine(pleasureArr.Length); return;
                }
            }
            int count = 1;
            if (firstIndex % 2 == 0)
            {
                count += firstIndex / 2;
                if ((lastIndex - firstIndex) % 2 == 0)
                {
                    count += (lastIndex - firstIndex) / 2;
                }
                else
                {
                    count += (lastIndex - firstIndex) / 2 + 1;
                }
            }
            else
            {
                count += firstIndex / 2 + 1;
                if ((lastIndex - firstIndex) % 2 == 0)
                {
                    count += (lastIndex - firstIndex) / 2;
                }
                else
                {
                    count += (lastIndex - firstIndex) / 2 + 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}
