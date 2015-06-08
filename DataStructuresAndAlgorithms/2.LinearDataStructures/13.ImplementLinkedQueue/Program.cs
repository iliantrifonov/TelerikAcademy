namespace _13.ImplementLinkedQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedQueue<char> queue = new LinkedQueue<char>();

            for (int i = 65; i < 80; i++)
            {
                queue.Enqueue((char)i);
            }

            Console.WriteLine(queue.Peek());
            Console.WriteLine();
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());  
        }
    }
}
