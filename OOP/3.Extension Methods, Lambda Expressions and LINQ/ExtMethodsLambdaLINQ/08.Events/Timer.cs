namespace _08.Events
{
    using System;
    using System.Threading;

    //8.* Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

    public class Timer
    {
        public EventArgs e = null;

        private const int secToMilisec = 1000;

        public Timer(int seconds, int timesToExecute)
        {
            this.seconds = seconds;
            this.timesToExecute = timesToExecute;
        }

        public event EventHandler ExecutedMethod;

        public int seconds { get; private set; }

        public int timesToExecute { get; private set; }

        public void Start()
        {
            for (int i = 0; i < this.timesToExecute; i++)
            {
                OnExecutedMethod();
                Thread.Sleep(this.seconds * secToMilisec);
            }
        }

        protected void OnExecutedMethod()
        {
            if (ExecutedMethod != null)
            {
                Console.WriteLine("Method has been executed");//there is supposed to be some kind of code logic here, that after it triggers, we call the event
                ExecutedMethod(this, e);
            }
        }
    }
}