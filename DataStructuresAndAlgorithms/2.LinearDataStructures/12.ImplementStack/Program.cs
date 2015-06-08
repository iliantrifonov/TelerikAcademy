namespace _12.ImplementStack
{
    using System;

    /// <summary>
    /// Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i < 11; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());
            Console.WriteLine();
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
