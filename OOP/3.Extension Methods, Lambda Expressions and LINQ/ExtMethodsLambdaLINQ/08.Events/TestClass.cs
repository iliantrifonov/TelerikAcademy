namespace _08.Events
{
    //8.* Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

    public class TestClass
    {
        public static void Main(string[] args)
        {
            Timer timer = new Timer(3, 3);
            Subscriber sub = new Subscriber();
            sub.Subscribe(timer, sub.PrintHello);// we subscribe to the event in timer, with the method PrintHello
            timer.Start();
        }
    }
}