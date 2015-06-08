namespace RefactorVariableNaming
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var square = new Figure(2, 2);
            var rotatedSquare = square.GetRotatedFigure(12);
            Console.WriteLine(rotatedSquare.Height);
        }
    }
}