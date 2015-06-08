namespace _01.Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/429
    /// </summary>
    public class Program
    {
        public static int CountPermutations = 0;

        public static SortedSet<string> Results = new SortedSet<string>();

        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var arr = new List<Frame>(count);
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();

                var split = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                arr.Add(new Frame(int.Parse(split[0]), int.Parse(split[1])));
            }

            arr.Sort();
            PermuteRep(arr, 0, arr.Count);

            var newSet = new HashSet<string>(Results);

            foreach (var item in Results)
            {
                var split = item.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var list = new List<Frame>();
                foreach (var elem in split)
                {
                    list.Add(new Frame(elem));
                }

                SwapInner(newSet, 0, list);
            }

            foreach (var item in newSet)
            {
                Results.Add(item);
            }

            Console.WriteLine(Results.Count);
            var result = new StringBuilder(100);
            foreach (var item in Results)
            {
                result.AppendLine(item);
            }

            Console.WriteLine(result);
        }

        private static string Get(List<Frame> frames)
        {
            return string.Join(" | ", frames);
        }

        private static void SwapInner(HashSet<string> newSet, int index, List<Frame> arr)
        {
            if (index >= arr.Count)
            {
                newSet.Add(Get(arr));
                return;
            }

            SwapInner(newSet, index + 1, arr);
            arr[index].SwapFirstAndSecond();
            SwapInner(newSet, index + 1, arr);
            arr[index].SwapFirstAndSecond();
        }

        private static void PermuteRep(List<Frame> arr, int start, int n)
        {
            Results.Add(Get(arr));

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left].CompareTo(arr[right]) != 0)
                    {
                        Frame temp = new Frame(arr[left].First, arr[left].Second);
                        arr[left] = new Frame(arr[right].First, arr[right].Second);
                        arr[right] = new Frame(temp.First, temp.Second);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = new Frame(arr[i + 1].First, arr[i + 1].Second);
                }

                arr[n - 1] = new Frame(firstElement.First, firstElement.Second);
            }
        }
    }
}