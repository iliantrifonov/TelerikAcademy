namespace _01.PriorityQueue
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var prioQueue = new PriorityQueue<int>();

            prioQueue.Enqueue(2);
            prioQueue.Enqueue(3);
            prioQueue.Enqueue(2);
            prioQueue.Enqueue(1);
            prioQueue.Enqueue(2);

            while (prioQueue.Count > 0)
            {
                Console.WriteLine(prioQueue.Dequeue());
            }

            var stringPrioQueue = new PriorityQueue<string>();

            stringPrioQueue.Enqueue("a");
            stringPrioQueue.Enqueue("ab");
            stringPrioQueue.Enqueue("ab1");
            stringPrioQueue.Enqueue("ca");
            stringPrioQueue.Enqueue("ba");
            stringPrioQueue.Enqueue("b");
            stringPrioQueue.Enqueue("c1");

            while (stringPrioQueue.Count > 0)
            {
                Console.WriteLine(stringPrioQueue.Dequeue());
            }
        }
    }
}
