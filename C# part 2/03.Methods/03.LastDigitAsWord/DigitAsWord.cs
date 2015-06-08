using System;

namespace _03.LastDigitAsWord
{
    //Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

    class DigitAsWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer number:");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitAsWord(num));
        }
        private static string LastDigitAsWord(int number)
        {
            int lastDigit = number % 10;
            switch (lastDigit)
            {
                case 0:
                    return "zero";
                    break;
                case 1:
                    return "one";
                    break;
                case 2:
                    return "two";
                    break;
                case 3:
                    return "three";
                    break;
                case 4:
                    return "four";
                    break;
                case 5:
                    return "five";
                    break;
                case 6:
                    return "six";
                    break;
                case 7:
                    return "seven";
                    break;
                case 8:
                    return "eight";
                    break;
                case 9:
                    return "nine";
                    break;
                default:
                    return "impossible";
                    break;
            }
        }
    }
}
