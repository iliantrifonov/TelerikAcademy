using System;

namespace _09.BinaryFloat
{
    //* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a FLOAT number to convert: ");
            float numberToConvert = float.Parse(Console.ReadLine());
            int sign = 0;
            if (numberToConvert < 0)
            {
                sign = 1;
            }
            numberToConvert = Math.Abs(numberToConvert);
            int exponent = 0;
            float decimalPart = numberToConvert - (int)numberToConvert;
            string mantissaNormalized = (int)numberToConvert == 0 ? "" : Convert.ToString((int)numberToConvert, 2);
            // calculate mantissa
            while (decimalPart != 0)
            {
                decimalPart *= 2f;
                mantissaNormalized += (int)decimalPart;
                decimalPart -= (int)decimalPart;
            }
            mantissaNormalized = mantissaNormalized.TrimStart('0');
            // calculating exponent
            decimalPart = numberToConvert - (int)numberToConvert;
            if ((int)numberToConvert == 0)
            {
                while (decimalPart < 1 && exponent > -127)
                {
                    exponent--;
                    decimalPart *= 2;
                }
            }
            else 
            {
                while (numberToConvert >= 2)
                {
                    exponent++;
                    numberToConvert /= 2;
                }
            }
            Console.WriteLine("sign = {0} exponent = {1} mantissa = {2}", sign, Convert.ToString(exponent + 127, 2).PadLeft(8, '0'), mantissaNormalized.PadRight(24, '0').Substring(1));
        }
    }
}
