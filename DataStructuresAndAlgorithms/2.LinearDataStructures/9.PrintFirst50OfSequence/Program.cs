namespace _9.PrintFirst50OfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    /// Sequence is:
    /// S1 = N;
    /// S2 = S1 + 1;
    /// S3 = 2*S1 + 1;
    /// S4 = S1 + 2;
    /// S5 = S2 + 1;
    /// S6 = 2*S2 + 1;
    /// S7 = S2 + 2;
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int n = 2;
            sequence.Enqueue(n);
            for (int i = 0; i < 50 / 3 - 1; i++)
            {
                int sValue = sequence.ElementAt(i);
                sequence.Enqueue(sValue + 1);
                sequence.Enqueue(2 * sValue + 1);
                sequence.Enqueue(sValue + 2);
            }

            foreach (var item in sequence)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
