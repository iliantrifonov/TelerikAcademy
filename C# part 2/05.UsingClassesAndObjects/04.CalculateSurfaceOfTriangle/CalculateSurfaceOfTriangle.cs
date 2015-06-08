using System;

namespace _04.CalculateSurfaceOfTriangle
{
    //Write methods that calculate the surface of a triangle by given:
    //Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

    class CalculateSurfaceOfTriangle
    {
        static void Main(string[] args)
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double height = 3;
            float angle = 1f;

            Console.WriteLine("By height and base: {0}", SurfaceOfTriangle(sideA, height));
            Console.WriteLine("By 3 sides: {0}", SurfaceOfTriangle(sideA, sideB,sideC));
            Console.WriteLine("By 2 sides and angle between them in radians: {0}", SurfaceOfTriangle(sideA, sideB, angle));
        }

        /// <summary>
        /// Calculates the surface by given parameters
        /// </summary>
        /// <param name="a">One of the sides</param>
        /// <param name="b">One of the sides></param>
        /// <param name="c">One of the sides</param>
        /// <returns>Floating point value of the surface</returns>
        private static double SurfaceOfTriangle(double a, double b, double c)
        {
            double semiPeremeter = 0.5 * (a + b + c);
            return Math.Sqrt((semiPeremeter * (semiPeremeter - a) * (semiPeremeter - b) * (semiPeremeter - c)));
        }

        /// <summary>
        /// Calculates the surface by given parameters
        /// </summary>
        /// <param name="a">One of the sides</param>
        /// <param name="b">One of the sides</param>
        /// <param name="angle">Angle between the two sides, in radians</param>
        /// <returns>Floating point value of the surface</returns>
        private static double SurfaceOfTriangle(double a, double b, float angle)
        {
            return 0.5 * a * b * Math.Sin(angle);
        }

        /// <summary>
        /// Calculates the surface by given parameters
        /// </summary>
        /// <param name="a">Base of the triangle</param>
        /// <param name="height">Height to the base of the triangle</param>
        /// <returns>Floating point value of the surface</returns>
        private static double SurfaceOfTriangle(double a, double height)
        {
            return 0.5 * a * height;
        }
    }
}
