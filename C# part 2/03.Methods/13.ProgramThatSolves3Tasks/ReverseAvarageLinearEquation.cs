using System;
using System.Numerics;
using System.Text;

namespace _13.ProgramThatSolves3Tasks
{
    //    Write a program that can solve these tasks:
    //Reverses the digits of a number
    //Calculates the average of a sequence of integers
    //Solves a linear equation a * x + b = 0
    //        Create appropriate methods.
    //        Provide a simple text-based menu for the user to choose which task to solve.
    //        Validate the input data:
    //The decimal number should be non-negative
    //The sequence should not be empty
    //a should not be equal to 0

    class ReverseAvarageLinearEquation
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to reverse digits of a number, 2 to calculate the avarage of a sequense of integers, 3 to solve a linear equation, or 4 to exit this program: ");
                int userInput = int.Parse(Console.ReadLine());
                if (userInput == 4)
                {
                    break;
                }
                else if (userInput == 1)
                {
                    CallReverseDigits();
                }
                else if (userInput == 2)
                {
                    CallAvarage();
                }
                else if (userInput == 3)
                {
                    CallLinear();
                }
            }
        }

        private static int LinearEquation(int a, int b)
        {
            return (-b) / a;
        }
        private static BigInteger AvarageOfArray(int[] array)
        {
            BigInteger result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            result = result / array.Length;
            return result;
        }

        private static void ReverseDigits(ref int number)
        {
            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                int digit = number % 10;
                result.Append(digit);
                number /= 10;
            }
            number = int.Parse(result.ToString());
        }

        //Intput
        private static void CallReverseDigits()
        {
            while (true)
            {
                Console.WriteLine("Enter number to reverse:");
                int num;
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num < 0)
                    {
                        continue;
                    }
                    ReverseDigits(ref num);
                    Console.WriteLine(num);
                    break;
                }
                Console.WriteLine("Invalid input, try again: ");
            }
        }

        private static void CallAvarage()
        {
            int sequenceLenght;
            while (true)
            {
                Console.WriteLine("Enter how many numbers you want the sequence to hold:");
                if (int.TryParse(Console.ReadLine(), out sequenceLenght))
                {
                    if (sequenceLenght < 0)
                    {
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Invalid input, try again: ");
            }

            int[] numberArray = new int[sequenceLenght];
            for (int i = 0; i < numberArray.Length; i++)
            {
                while (true)
                {
                    Console.WriteLine("Enter {0} element of the sequence:", i + 1);
                    if (int.TryParse(Console.ReadLine(), out numberArray[i]))
                    {
                        if (numberArray[i] < 0)
                        {
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("Invalid input, try again: ");
                }
            }
            BigInteger result = AvarageOfArray(numberArray);

            Console.WriteLine("The avarage of the array is {0}" , result);
        }

        private static void CallLinear()
        {
            Console.WriteLine("For a * x + b = 0");
            int a;
            while (true)
            {
                Console.WriteLine("Enter a:");
                if (int.TryParse(Console.ReadLine(), out a))
                {
                    if (a <= 0)
                    {
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Invalid input, try again: ");
            }
            int b;
            while (true)
            {
                Console.WriteLine("Enter b:");
                if (int.TryParse(Console.ReadLine(), out b))
                {
                    if (b <= 0)
                    {
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Invalid input, try again: ");
            }
            Console.WriteLine("X = {0}", LinearEquation(a,b));
        }
    }
}
