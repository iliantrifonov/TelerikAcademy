namespace _02.ColoredRabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// downloads.academy.telerik.com/svn/algo-academy/2012-10-Combinatorics/All%20problems/Problem%202.zip
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] replies = new int[count];
            for (int i = 0; i < count; i++)
            {
                replies[i] = int.Parse(Console.ReadLine());
            }

            int answer = GetMinimum(replies);
            Console.WriteLine(answer);
        }

        private static int GetMinimum(int[] replies)
        {
            var uniqueReplies = new Dictionary<int, int>();
            int result = 0;
            for (int i = 0; i < replies.Length; i++)
            {
                if (uniqueReplies.ContainsKey(replies[i] + 1))
                {
                    uniqueReplies[replies[i] + 1] += 1;
                }
                else
                {
                    uniqueReplies.Add(replies[i] + 1, 1);
                }
            }

            foreach (var reply in uniqueReplies)
            {
                var answers = reply.Value;
                if (answers > reply.Key)
                {
                    if (reply.Key == 0)
                    {
                        result += reply.Value;
                        continue;
                    }

                    if (answers % reply.Key == 0)
                    {
                        answers /= reply.Key;
                    }
                    else
                    {
                        answers /= reply.Key;
                        answers += 1;
                    }
                }
                else
                {
                    answers = 1;
                }

                result += (reply.Key * answers);
            }

            return result;
        }
    }
}
