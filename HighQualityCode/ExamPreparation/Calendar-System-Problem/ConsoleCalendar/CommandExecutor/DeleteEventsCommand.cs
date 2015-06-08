namespace ConsoleCalendar.CommandExecutor
{
    using System;

    public class DeleteEventsCommand : AbstractCommand
    {
        public DeleteEventsCommand(IEventsManager eventsManager)
            : base(eventsManager)
        {
        }

        public override string Execute(Command command)
        {
            if (command.Arguments.Length != 1)
            {
                throw new ArgumentException(string.Format("Invalid number of command arguments {0}", command.Arguments.Length));
            }

            int deletedEvents = this.EventManager.DeleteEventsByTitle(command.Arguments[0]);

            if (deletedEvents == 0)
            {
                return "No events found";
            }

            return string.Format("{0} events deleted", deletedEvents);
        }
    }
}
