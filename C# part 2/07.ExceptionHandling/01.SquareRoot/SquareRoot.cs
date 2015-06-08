using System;

namespace _01.SquareRoot
{
    //Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter integer number: ");
                uint number = uint.Parse(Console.ReadLine());
                Console.WriteLine("The square root of {0} is {1}", number, Math.Sqrt(number));
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
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
