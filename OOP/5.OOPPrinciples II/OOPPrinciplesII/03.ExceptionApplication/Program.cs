namespace _03.ExceptionApplication
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter number between 1 and 100");
            int number = int.Parse(Console.ReadLine());
            if (number < 1 || number >= 100)
            {
                throw new InvalidRangeException<int>("Number is not in range.", number, 1, 100);
            }
            DateTime min = new DateTime(1980, 1, 1);
            DateTime max = new DateTime(2013, 12, 31);
            Console.WriteLine("Enter date between 1.1.1980 … 31.12.2013");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < min || date > max)
            {
                throw new InvalidRangeException<DateTime>("Date is not in range.", date, min, max);
            }
        }
    }
}