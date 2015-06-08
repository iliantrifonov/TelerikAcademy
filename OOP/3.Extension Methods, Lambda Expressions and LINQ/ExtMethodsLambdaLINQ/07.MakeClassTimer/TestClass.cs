namespace _07.MakeClassTimer
{
    using System;

    public class TestClass
    {
        //7.Using delegates write a class Timer that has can execute certain method at each t seconds.
        public static void Main(string[] args)
        {
            Timer timer = new Timer(PrintHello, 3, 3);
            timer.Start();
        }

        public static void PrintHello()
        {
            Console.WriteLine("Hello I am a method");
        }
    }
}