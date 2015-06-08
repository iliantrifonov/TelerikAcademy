using System;
using System.Text;

namespace _07.ReverseDigits
{
    //Write a method that reverses the digits of given decimal number. Example: 256  652

    class RevDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number to reverse:");
            int num = int.Parse(Console.ReadLine());
            ReverseDigits(ref num);
            Console.WriteLine(num);
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
    }
}
