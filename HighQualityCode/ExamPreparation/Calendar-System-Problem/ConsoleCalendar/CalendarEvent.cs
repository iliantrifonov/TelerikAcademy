namespace ConsoleCalendar
{
    using System;

    public class CalendarEvent : IComparable<CalendarEvent>
    {
        public CalendarEvent(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public CalendarEvent(DateTime date, string title)
            : this(date, title, null)
        {
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(CalendarEvent other)
        {
            int result = DateTime.Compare(this.Date, other.Date);

            if (result == 0)
            {
                result = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, other.Location, StringComparison.Ordinal);
            }

            return result;
        }
    }
}