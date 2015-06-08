using System;

namespace _02.GetMax
{
    //Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

    class GetMaxOfTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write first number");
            int firstNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Write second number");
            int secondNum = int.Parse(Console.ReadLine());
            int maxNum = GetMax(firstNum, secondNum);
            Console.WriteLine("Write third number");
            int thirdNum = int.Parse(Console.ReadLine());
            Console.WriteLine("The biggest number is:");
            Console.WriteLine(GetMax(thirdNum, maxNum));

        }

        private static int GetMax(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
    }
}
