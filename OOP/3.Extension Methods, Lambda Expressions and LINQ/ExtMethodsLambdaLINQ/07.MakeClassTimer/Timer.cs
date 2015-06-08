namespace _07.MakeClassTimer
{
    using System.Threading;

    //7.Using delegates write a class Timer that has can execute certain method at each t seconds.
    public delegate void TimerDelegate();

    public class Timer
    {
        private const int secToMilisec = 1000;

        public Timer(TimerDelegate method, int seconds, int timesToExecute)
        {
            this.method = method;
            this.seconds = seconds;
            this.timesToExecute = timesToExecute;
        }

        public TimerDelegate method { get; private set; }

        public int seconds { get; private set; }

        public int timesToExecute { get; private set; }

        public void Start()
        {
            for (int i = 0; i < this.timesToExecute; i++)
            {
                this.method();
                Thread.Sleep(this.seconds * secToMilisec);
            }
        }
    }
}