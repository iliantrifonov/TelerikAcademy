using System;

namespace _11.AddPolynominals
{
    //Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    class Polynominals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the maximal power of X:");
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the coefficients of the first polynomial:");
            int[] firstPolynomial = new int[power + 1];
            EnterPolynomial(firstPolynomial);
            PrintPolynomial(firstPolynomial);
            Console.WriteLine("Enter the coefficients of the first polynomial:");
            int[] secondPolynomial = new int[power + 1];
            EnterPolynomial(secondPolynomial);
            PrintPolynomial(secondPolynomial);
            int[] resultOfAdding = AddPolynomial(firstPolynomial, secondPolynomial);

            Console.WriteLine("The result of the adding is:" );
            PrintPolynomial(resultOfAdding);
        }

        private static void PrintPolynomial(int[] polynomial)
        {
            for (int i = polynomial.Length - 1; i >= 1; i--)
            {
                Console.Write("{0}*X^{1} + ", polynomial[i], i);
            }
            Console.WriteLine("{0} = 0", polynomial[0]);
        }

        private static void EnterPolynomial(int[] firstPolynominal)
        {
            for (int i = 0; i < firstPolynominal.Length; i++)
            {
                Console.Write("Enter X^{0}: ", i);
                firstPolynominal[i] = int.Parse(Console.ReadLine());
            }
        }

        private static int[] AddPolynomial(int[] firstPoly, int[] secondPoly)
        {
            int[] result = new int[firstPoly.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstPoly[i] + secondPoly[i];
            }
            return result;
        }
    }
}
