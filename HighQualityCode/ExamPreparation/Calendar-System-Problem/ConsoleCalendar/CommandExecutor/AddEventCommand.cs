namespace ConsoleCalendar.CommandExecutor
{
    using System;
    using System.Globalization;

    public class AddEventCommand : AbstractCommand
    {
        public AddEventCommand(IEventsManager eventsManager) 
            : base(eventsManager)
        {
        }

        public override string Execute(Command command)
        {
            if (command.Arguments.Length == 2)
            {
               return this.ExecuteWithoutLocation(command);
            }
            else if (command.Arguments.Length == 3)
            {
                return this.ExecuteWithLocation(command);
            }

            throw new ArgumentException(string.Format("Invalid number of command arguments {0}", command.Arguments.Length));
        }

        private string ExecuteWithoutLocation(Command command)
        {
            var date = DateTime.ParseExact(command.Arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var calendarEvent = new CalendarEvent(date, command.Arguments[1]);

            this.EventManager.AddEvent(calendarEvent);

            return "Event added";
        }

        private string ExecuteWithLocation(Command command)
        {
            var date = DateTime.ParseExact(command.Arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var calendarEvent = new CalendarEvent(date, command.Arguments[1], command.Arguments[2]);

            this.EventManager.AddEvent(calendarEvent);

            return "Event added";
        }
    }
}
