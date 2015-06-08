using System;

namespace _06.CalculateSumOfString
{
    class CalculateSumOfString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string of integer numbers separated by spaces: ");
            string numbers = Console.ReadLine();
            string[] arrayOfNumbers = numbers.Split(' ');
            int sum = 0;
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                sum += int.Parse(arrayOfNumbers[i]);
            }
            Console.WriteLine("The sum of the numbers is {0}", sum);
        }
    }
}
