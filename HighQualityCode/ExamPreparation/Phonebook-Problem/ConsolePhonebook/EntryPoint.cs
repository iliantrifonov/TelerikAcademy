namespace ConsolePhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Command;

    public class EntryPoint
    {
        private static void Main()
        {
            var data = new PhonebookRepository();
            var output = new Output();
            var converter = new PhoneConverter();
            var commandFactory = new CommandFactory(converter, data, output);

            while (true)
            {
                string currentInput = Console.ReadLine();
                if (currentInput == "End" || currentInput == null)
                {
                    break;
                }

                int indexOfFirstBracket = currentInput.IndexOf('(');

                if (indexOfFirstBracket == -1)
                {
                    throw new ArgumentException("The input is in an incorrect format");
                }

                if (!currentInput.EndsWith(")"))
                {
                    throw new ArgumentException("The input is in an incorrect format");
                }

                string currentCommand = currentInput.Substring(0, indexOfFirstBracket);

                string insideBracketsString = currentInput.Substring(indexOfFirstBracket + 1, currentInput.Length - indexOfFirstBracket - 2);
                string[] entries = insideBracketsString.Split(',');

                for (int i = 0; i < entries.Length; i++)
                {
                    entries[i] = entries[i].Trim();
                }

                var commandInstance = commandFactory.GetCommandInstance(currentCommand, entries.Length);
                commandInstance.Execute(entries);
            }

            Console.Write(output);
        }
    }
}
