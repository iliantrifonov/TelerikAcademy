namespace _02.ExtendIEnum
{
    using System;
    using System.Collections.Generic;

    public class TextClass
    {
        public static void Main(string[] args)
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(1);
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);
            int sum = que.Sum();
            Console.WriteLine("Sum is {0}", sum);
            int product = que.Product();
            Console.WriteLine("Product is {0}", product);
            int min = que.Min();
            Console.WriteLine("Min is {0}", min);
            int max = que.Max();
            Console.WriteLine("Max is {0}", max);
            int avarage = que.Avarage();
            Console.WriteLine("Avarage is {0}", avarage);
        }
    }
}