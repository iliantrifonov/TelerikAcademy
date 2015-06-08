namespace Methods
{
    using System;

    public static class MathHelper
    {
        public static double CalculateDistance(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Cannot find the max if no parameters are given");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("The input is not a digit");
            }
        }

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b < c)
            {
                throw new ArgumentException("The values of the sides of the triangle are invalid");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }
    }
}