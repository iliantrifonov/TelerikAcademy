namespace ConsoleCalendar.CommandExecutor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class ListEventsCommand : AbstractCommand
    {
        public ListEventsCommand(IEventsManager eventsManager)
            : base(eventsManager)
        {
        }

        public override string Execute(Command command)
        {
            if (command.Arguments.Length != 2)
            {
                throw new ArgumentException(string.Format("Invalid number of command arguments {0}", command.Arguments.Length));
            }

            var date = DateTime.ParseExact(command.Arguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var count = int.Parse(command.Arguments[1]);
            var events = this.EventManager.ListEvents(date, count).ToList();
            var result = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var e in events)
            {
                result.AppendLine(e.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
