namespace RobotizedZombieCamel
{
    using System;
    using System.Linq;

    public class Program
    {
        public static ulong result = 0;

        public static void Main(string[] args)
        {
            int amountOfPoints = int.Parse(Console.ReadLine().Trim());

            uint[] lengthArray = new uint[amountOfPoints];
            for (int i = 0; i < amountOfPoints; i++)
            {
                var point = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(point))
                {
                    i--;
                    continue;
                }

                var xY = point.Split(' ');
                lengthArray[i] = (uint)(Math.Abs(int.Parse(xY[0])) + Math.Abs(int.Parse(xY[1])));
                result += lengthArray[i] * (ulong)(Math.Pow(2, amountOfPoints));
            }

            Console.WriteLine(result);
        }
    }
}
