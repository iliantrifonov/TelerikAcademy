
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MethodReadNumber
{
    //Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers:
	//a1, a2, … a10, such that 1 < a1 < … < a10 < 100

    class MethodReadNumber
    {
        static void Main(string[] args)
        {
            try
            {
                int[] arrayOfNumbers = new int[10];
                int startNum = int.MinValue;
                int endNum = 100;
                for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
                    Console.WriteLine("Enter a number between {0} and {1}", startNum, endNum);
                    arrayOfNumbers[i] = ReadNumber(startNum, endNum);
                    startNum = arrayOfNumbers[i];
                }
                Console.WriteLine("The numbers are:");
                foreach (var item in arrayOfNumbers)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
        }

        private static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number< start || number > end)
            {
                throw new OverflowException();
            }
            return number;
        }
    }
}
