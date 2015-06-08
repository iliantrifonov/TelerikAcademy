using System;

namespace _01.AskAndWriteName
{

    class AskAndWriteName
    {
        //Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

        static void Main(string[] args)
        {
            AskName();
        }

        private static void AskName()
        {
            Console.WriteLine("Please write your first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Hello {0}!", name);
        }
    }
}
