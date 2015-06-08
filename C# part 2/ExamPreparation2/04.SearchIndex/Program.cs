using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SearchIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchWord = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }
            int[] count = new int[n];
            for (int i = 0; i < n; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                string[] source = lines[i].Split(new char[] { ',', '.', '(', ')',  ';', '-',  '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int counter = 0;
                for (int ki = 0; ki < source.Length; ki++)
                {
                    if (source[ki].ToLowerInvariant() == searchWord.ToLowerInvariant())
                    {
                        source[ki] = searchWord.ToUpper();
                        counter++;
                    }
                }
                count[i] = counter;
                StringBuilder sb = new StringBuilder();
                for (int ki = 0; ki < source.Length; ki++)
                {
                    sb.Append(source[ki]);
                    sb.Append(" ");
                }
                sb.Remove(sb.Length - 1, 1);
                lines[i] = sb.ToString();
            }
            Array.Sort(count, lines);
            for (int i = lines.Length -1; i >= 0; i--)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
