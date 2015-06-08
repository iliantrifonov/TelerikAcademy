namespace Log4Net
{
    using System;
    using log4net;
    using log4net.Config;

    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("Logger");

        public static void Main(string[] args)
        {
            Console.WriteLine("Testing log 4 net");
            BasicConfigurator.Configure();

            for (int i = 0; i < 3; i++)
            {
                DoNothing();
            }
        }

        public static void DoNothing()
        {
            // there should be logic here
            Log.Info("DoNothing() was called");
        }
    }
}
