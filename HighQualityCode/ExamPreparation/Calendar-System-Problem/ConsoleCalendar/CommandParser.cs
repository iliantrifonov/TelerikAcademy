namespace ConsoleCalendar
{
    using System;

    public class CommandParser : ICommandParser
    {
        public Command Parse(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("The input must not be null");
            }
            
            int indexOfFirstSpace = input.IndexOf(' ');
            if (indexOfFirstSpace == -1)
            {
                throw new ArgumentException(string.Format("Invalid command: {0}", input));
            }

            string name = input.Substring(0, indexOfFirstSpace);
            string argumentsString = input.Substring(indexOfFirstSpace + 1);

            var commandArguments = argumentsString.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                argumentsString = commandArguments[i];
                commandArguments[i] = argumentsString.Trim();
            }

            var command = new Command(name, commandArguments);

            return command;
        }
    }
}
