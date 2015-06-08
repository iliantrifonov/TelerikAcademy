namespace _06.DivisibleBy7And3
{
    using System;
    using System.Linq;

    //6.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    public class TestClass
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i + 1;
            }
            //lambda
            var divisibleByLambda = arr.Where(st => st % 7 == 0 && st % 3 == 0);
            Console.WriteLine("Divisible by 7 and 3 Lambda:");
            foreach (var num in divisibleByLambda)
            {
                Console.WriteLine(num);
            }
            //LINQ
            var divisibleByLINQ =
                from num in arr
                where num % 7 == 0 && num % 3 == 0
                select num;
            Console.WriteLine("Divisible by 7 and 3 LINQ:");
            foreach (var num in divisibleByLINQ)
            {
                Console.WriteLine(num);
            }
        }
    }
}