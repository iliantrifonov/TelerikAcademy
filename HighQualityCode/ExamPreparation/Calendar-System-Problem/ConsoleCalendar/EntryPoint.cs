namespace ConsoleCalendar
{
    using System;
    using System.Linq;
    using System.Text;
    using CommandExecutor;

    public class EntryPoint
    {
        internal static void Main()
        {
            var eventManager = new EventsManager();
            var commandFactory = new CommandFactory(eventManager);
            var output = new StringBuilder();
            var parser = new CommandParser();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End" || input == null)
                {
                    break;
                }

                var currentCommand = parser.Parse(input);
                var commandExecutor = commandFactory.GetCommandExecutor(currentCommand.CommandName);
                var someStr = commandExecutor.Execute(currentCommand);
                output.AppendLine(someStr);
            }

            Console.Write(output.ToString());
        }
    }
}