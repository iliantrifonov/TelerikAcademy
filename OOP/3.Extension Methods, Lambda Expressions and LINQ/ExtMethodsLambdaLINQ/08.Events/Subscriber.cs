namespace _08.Events
{
    using System;

    //8.* Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

    internal class Subscriber
    {
        public void PrintHello(object sender, EventArgs e)
        {
            Console.WriteLine("Hello I am a method");
        }

        public void Subscribe(Timer timer, EventHandler method)
        {
            timer.ExecutedMethod += method;
        }
    }
}