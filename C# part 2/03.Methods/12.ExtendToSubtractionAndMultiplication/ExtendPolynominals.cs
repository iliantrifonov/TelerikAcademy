using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ExtendToSubtractionAndMultiplication
{
    //Extend the program to support also subtraction and multiplication of polynomials.

    class ExtendPolynominals
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
            Console.WriteLine("The result of the adding is:");
            PrintPolynomial(resultOfAdding);

            int[] resultOfSubtraction = SubtractPolynomial(firstPolynomial, secondPolynomial);
            Console.WriteLine("The result of the subtraction is:");
            PrintPolynomial(resultOfSubtraction);

            int[] resultOfMultiplication = MultiplyPolynomial(firstPolynomial, secondPolynomial);
            Console.WriteLine("The result of the multiplication is:");
            PrintPolynomial(resultOfMultiplication);
        }

        private static void PrintPolynomial(int[] polynomial)
        {
            for (int i = polynomial.Length - 1; i >= 1; i--)
            {
                if (polynomial[i] == 0)
                {
                    continue;
                }
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

        /// <summary>
        /// Subtracts two polynomials, as firstPoly - secondPoly = result
        /// </summary>
        /// <param name="firstPoly"></param>
        /// <param name="secondPoly"></param>
        /// <returns>Returns an array of integers</returns>
        private static int[] SubtractPolynomial(int[] firstPoly, int[] secondPoly)
        {
            int[] result = new int[firstPoly.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstPoly[i] - secondPoly[i];
            }
            return result;
        }

        private static int[] MultiplyPolynomial(int[] firstPoly, int[] secondPoly)
        {
            int[] result = new int[firstPoly.Length * secondPoly.Length];
            for (int i = 0; i < firstPoly.Length; i++)
            {
                result[i * i] = firstPoly[i] * secondPoly[i];
            }
            return result;
        }
    }
}
