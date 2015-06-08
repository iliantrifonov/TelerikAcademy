using System;
using System.Collections.Generic;

namespace _08.MakeAMethodThatAdds
{
    //Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

    class MakeAMethodThatAdds
    {
        static void Main(string[] args)
        {
            byte[] firstArr = new byte[] { 9, 9, 9 };
            byte[] secondArr = new byte[] { 1, 0, 1 };
            List<int> resultOfAdding = AddArraysOfDigits(firstArr, secondArr);
            PrintList(resultOfAdding);
        }

        private static List<int> AddArraysOfDigits(byte[] a, byte[] b)
        {
            List<int> result = new List<int>(Math.Max(a.Length, b.Length));

            int carry = 0;
            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                int currentDigit = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0) + carry; // we do a check if we have surpassed the lenght of any of the arrays , if so we put + 0 to the current digit, so we do not go out of range of the array.

                carry = currentDigit / 10;
                result.Add(currentDigit % 10);
            }
            if (carry == 1)
            {
                result.Add(1);
            }
            return result;
        }

         private static void PrintList(List<int> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
        }
    }
}
