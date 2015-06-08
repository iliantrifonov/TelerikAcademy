namespace DataGenerator
{
    using System;
    using System.Linq;

    public class ConsoleLogger : ILogger
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
