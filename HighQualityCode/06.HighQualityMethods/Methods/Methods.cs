namespace Methods
{
    using System;

    public class Methods
    {
        public static void PrintInFormat(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Format string was incorrect");
            }
        }

        public static void Main()
        {
            Console.WriteLine(MathHelper.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(MathHelper.NumberToDigit(5));

            Console.WriteLine(MathHelper.FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintInFormat(1.3, "f");
            PrintInFormat(0.75, "%");
            PrintInFormat(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(MathHelper.CalculateDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}