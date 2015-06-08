namespace ConsoleCalendar.CommandExecutor
{
    using System;
    using System.Collections.Generic;

    public class CommandFactory : ICommandFactory
    {
        private Dictionary<string, ICommandExecutor> commandsByName;

        public CommandFactory(IEventsManager eventsManager)
        {
            var addEventCommand = new AddEventCommand(eventsManager);
            var deleteEventsCommand = new DeleteEventsCommand(eventsManager);
            var listEventsCommand = new ListEventsCommand(eventsManager);

            this.commandsByName = new Dictionary<string, ICommandExecutor>();

            this.commandsByName.Add("AddEvent", addEventCommand);
            this.commandsByName.Add("DeleteEvents", deleteEventsCommand);
            this.commandsByName.Add("ListEvents", listEventsCommand);
        }

        public ICommandExecutor GetCommandExecutor(string commandName)
        {
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new ArgumentException(string.Format("Invalid command name {0}", commandName));
            }

            return this.commandsByName[commandName];
        }
    }
}
