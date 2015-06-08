namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;

    public class UserInput : IUserInput
    {
        public IEnumerable<ICommand> GetCommands()
        {
            List<ICommand> commandList = new List<ICommand>();
            bool end = false;

            while (true)
            {
                string command = Console.ReadLine();
                end = command.Trim() == "End";
                if (end)
                {
                    break;
                }

                commandList.Add(new Command(command));
            }

            return commandList;
        }
    }
}
