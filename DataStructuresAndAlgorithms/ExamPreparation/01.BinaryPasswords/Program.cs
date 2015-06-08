namespace _01.BinaryPasswords
{
    using System;
    using System.Linq;

    /// <summary>
    /// bgcoder.com/Contests/Practice/DownloadResource/206
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine(1);
                return;
            }

            long result = 1;
            for (int i = 0; i < counter; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
